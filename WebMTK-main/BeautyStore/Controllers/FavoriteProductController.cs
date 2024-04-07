using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class FavoriteProductController : TemplateMethodFavorite
    {
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: FavoriteProduct
        public ActionResult FavoriteList(int id)
        {
            /*  var product = db.FavoriteProducts.Where(n => n.UserID == id).ToList();

              ViewBag.ProductInfor = new List<Product>();
              foreach (var item in product)
              {
                  Product prod = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                  ViewBag.ProductInfor.Add(prod);
              }*/

            //Áp dụng mẫu TemplateMethod
            var product = GetFavoriteProducts(id);
            ViewBag.ProductInfor = new List<Product>();
            foreach (var item in product) 
            {
                Product prod = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                ViewBag.ProductInfor.Add(prod);
            }
            return View(product);
        }



        [HttpPost]
        public ActionResult InsertListFavorite(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var productAvail = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                if (productAvail != null)
                    return RedirectToAction("Index", "Details", new { id = favoriteProd.ProductID} );
                else
                {

                    db.FavoriteProducts.Add(favoriteProd);
                    db.SaveChanges();
                    //Áp dụng mẫu TemplateMethod
                    return RedirectedToFavoriteList(favoriteProd.UserID.GetValueOrDefault());
                }
            }
            return View("Index", "Details", new { id = favoriteProd.ProductID });
        }

        public ActionResult DeleteProduct(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var prod = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                db.FavoriteProducts.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
        }
    }
}