using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class FiltProductController : TemplateMethodFilt
    {
        //Áp dụng mẫu TemplateMethod cho toàn bộ

        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: FiltProduct
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Under200lAllProduct(int id)
        {
            return FilterProducts(products => products.OrderByDescending(item => item.ProductID), products => id == 0 ? products.Where(item => item.Price < 200000) : products.Where(item => item.Price < 200000 && item.CategoryID == id), id);
        }

        //từ 4 củ tới 8 củ
        public ActionResult From200To400AllProduct(int id)
        {
            return FilterProducts(products => products.OrderByDescending(item => item.ProductID), products => id == 0 ? products.Where(item => item.Price >= 200000 && item.Price <= 400000) : products.Where(item => item.Price >= 200000 && item.Price <= 400000 && item.CategoryID == id), id);
        }
        //từ 8 củ tới 12 củ
        public ActionResult From400To600AllProduct(int id)
        {
            return FilterProducts(products => products.OrderByDescending(item => item.ProductID), products => id == 0 ? products.Where(item => item.Price >= 400000 && item.Price <= 600000) : products.Where(item => item.Price >= 400000 && item.Price <= 600000 && item.CategoryID == id), id);

        }
        //trên 12 củ
        public ActionResult Over600AllProduct(int id)
        {
            return FilterProducts(products => products.OrderByDescending(item => item.ProductID), products => id == 0 ? products.Where(item => item.Price >= 600000) : products.Where(item => item.Price >= 600000 && item.CategoryID == id), id);
        }

        //giá thấp -> cao
        public ActionResult IncreaseWithPrice(int id)
        {
            return FilterProducts(products => products.OrderBy(item => item.Price), products => id == 0 ? products : products.Where(item => item.CategoryID == id), id);
        }


        //giá cao -> thấp
        public ActionResult DescreaseWithPrice(int id)
        {
            return FilterProducts(products => products.OrderByDescending(item => item.Price), products => id == 0 ? products : products.Where(item => item.CategoryID == id), id);
        }

    }
}