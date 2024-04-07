using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class BrandController : Controller
    {
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: Brand
        public ActionResult Index(int id)
        {
            var product = db.Products.Where(n => n.BrandID == id).ToList().Take(8);
            ViewBag.BrandProd = db.Brands.FirstOrDefault(n => n.BrandID == id);
            ViewBag.IdBrand = id;
            return View(product);
        }

    }
}