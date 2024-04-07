using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyStore.DesignPattern
{
    public abstract class TemplateMethodFavorite : Controller
    {
        protected BeautyStoreEntities1 db = new BeautyStoreEntities1();
        protected List<FavoriteProduct> GetFavoriteProducts(int userID) 
        {
            return db.FavoriteProducts.Where(n => n.UserID == userID).ToList();
        }

        protected ActionResult RedirectedToFavoriteList(int userID) 
        {
            return RedirectToAction("FavoriteList", "FavoriteProduct", new { id = userID });
        }
    }
}