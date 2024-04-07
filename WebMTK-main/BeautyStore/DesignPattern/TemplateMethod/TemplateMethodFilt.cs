using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyStore.DesignPattern
{
    public abstract class TemplateMethodFilt : Controller
    {
        protected BeautyStoreEntities1 db = new BeautyStoreEntities1();
        protected ActionResult FilterProducts(Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy, Func<IQueryable<Product>, IQueryable<Product>> filter, int categoryId)
        {
            var product = filter(db.Products);
            product = orderBy(product);

            ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == categoryId);
            ViewBag.IdCategory = categoryId;
            return View(product.ToList());
        }
    }
}