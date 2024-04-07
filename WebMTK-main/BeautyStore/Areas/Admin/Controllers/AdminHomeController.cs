using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            ViewBag.CountUser = db.Customers.Count();
            ViewBag.CountProduct = db.Products.Count();
            ViewBag.CountOrder = db.Orders.Count();
            ViewBag.totalRevenue = CalculateTotalRevenue();
            ViewBag.OrderList = (from order in db.Orders orderby order.IdOrder descending select order).ToList().Take(10);

            var today = DateTime.Now.Date;
            ViewBag.OrderToday = db.Orders.Where(order => order.DateOrder == today).Count();
            ViewBag.DebtOrder = db.Orders.Where(order => order.StatusOrder == 0).Count();
            ViewBag.PaidOrder = db.Orders.Where(order => order.StatusOrder == 2).Count();
            

            ViewBag.CancelOrder = db.Orders.Where(order => order.StatusOrder == 3).Count();
           // ViewBag.TongDT = db.Orders.Where(order => order.StatusOrder == 2).Sum(order => order.QuantityProduct * order.Final)
            // tính tổng doanh thu
         

            return View();
        }
        private decimal CalculateTotalRevenue()
        {
            // Lấy danh sách các chi tiết đơn hàng đã được xác nhận
            var confirmedOrderDetails = db.OrderDetails
                .Where(orderDetail => orderDetail.Order.StatusOrder == 2)
                .ToList();

            decimal totalRevenue = 0;

            // Duyệt qua từng chi tiết đơn hàng và tính tổng doanh thu
            /*foreach (var orderDetail in confirmedOrderDetails)
            {
                totalRevenue += (decimal)(orderDetail.Quantity * orderDetail.FinalPrice);
            }

            return totalRevenue;*/

            //Sử dụng Iterator cho danh sách OrderDetail
            var orderDetailIterator = new PatternIterator<OrderDetail>(confirmedOrderDetails);

            // Duyệt qua từng chi tiết đơn hàng và tính tổng doanh thu
            while (!orderDetailIterator.IsDone)
            {
                var orderDetail = orderDetailIterator.CurrentIT;
                totalRevenue += (decimal)(orderDetail.Quantity * orderDetail.Product.IntialPrice);

                orderDetailIterator.Next();
            }
            return totalRevenue;
        }
    }
}