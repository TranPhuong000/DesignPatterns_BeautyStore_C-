using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class MenuNavPartialController : Controller
    {
        // GET: MenuNavPartial
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: MenuNavPartial
        public ActionResult MenuNav()
        {
            ViewBag.CategoryNavList = db.Categories.ToList();
            return PartialView();
        }
    }
}