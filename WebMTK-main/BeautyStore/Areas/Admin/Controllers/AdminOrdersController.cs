using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();


        // GET: Admin/AdminOrders
        public ActionResult Index()
        {
            var orders = (from order in db.Orders orderby order.IdOrder descending select order).ToList();
            return View(orders.ToList());
        }

        //Iterator
        // GET: Admin/AdminOrders/Details/5
        public ActionResult Details(int? id)
        {
            /* foreach (var item in listProdOrder)
            {
                finalPrice += (decimal)item.FinalPrice;
            }*/

            //lấy danh sách các chi tiết đơn hàng
            var listProdOrder = db.OrderDetails.Where(order => order.IdOrder == id).ToList();
            var orderDetailIterator = new PatternIterator<OrderDetail>(listProdOrder);
            decimal finalPrice = 0;

            //Bắt đầu từ phần tử đầu tiên
            var firstItem = orderDetailIterator.First();
            while (firstItem != null)
            {   
                finalPrice += (decimal)firstItem.FinalPrice;
                firstItem = orderDetailIterator.Next();
            }
           
            ViewBag.FinalPrice = finalPrice;
            ViewBag.Address = db.Orders.FirstOrDefault(o => o.IdOrder == id).Address;
            ViewBag.Date = db.Orders.FirstOrDefault(o => o.IdOrder == id).DateOrder;
            ViewBag.Id = db.Orders.FirstOrDefault(o => o.IdOrder == id).IdOrder;
            ViewBag.Status = db.Orders.FirstOrDefault(o => o.IdOrder == id).StatusOrder;

            ViewBag.CusInfor = db.Orders.FirstOrDefault(o => o.IdOrder == id);

            return View(listProdOrder);
        }
        public ActionResult Confirm(int id)
        {
            var prodListOrder = db.OrderDetails.Where(o => o.IdOrder == id).ToList();

            /* foreach (var item in prodListOrder)
             {
                 var product = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                 product.amount -= (int)item.Quantity;
                 db.SaveChanges();
             }*/

            var prodListOrderIterator = new PatternIterator<OrderDetail>(prodListOrder);

            while (!prodListOrderIterator.IsDone)
            {
                var item = prodListOrderIterator.CurrentIT as OrderDetail;

                var product = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                if (product != null)
                {
                    product.amount -= (int)item.Quantity;
                }
                prodListOrderIterator.Next();

                db.SaveChanges();
            }

            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 3;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 2;
            db.SaveChanges();

            int idUser = order.UserID.GetValueOrDefault();
            return RedirectToAction("Index");
        }

    }
}
