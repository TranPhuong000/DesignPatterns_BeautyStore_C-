using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class NewsController : Controller
    {
        BeautyStoreEntities1 db = new BeautyStoreEntities1();
        // GET: News
        public ActionResult Index()
        {
            var newsList = db.News.ToList();
            return View(newsList);
        }

        public ActionResult News(int id)
        {
            var news = db.News.FirstOrDefault(n => n.NewsID == id);
            ViewBag.IndexOfDot = news.NewsContent.IndexOf(".");
            return View(news);
        }
    }
}