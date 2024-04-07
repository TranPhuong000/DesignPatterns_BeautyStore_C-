using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminCategoriesController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        // GET: Admin/AdminCategories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/AdminCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase ImgCate)
        {
            if (ModelState.IsValid)
            {
                if (ImgCate != null)
                {
                    var fileName = Path.GetFileName(ImgCate.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    category.CategoryImage = fileName;
                    ImgCate.SaveAs(path);
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase ImgCate)
        {
            if (ModelState.IsValid)
            {
                if (ImgCate != null)
                {
                    var fileName = Path.GetFileName(ImgCate.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    category.CategoryImage = fileName;
                    ImgCate.SaveAs(path);
                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Copy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Copy/5
        [HttpPost, ActionName("Copy")]
        [ValidateAntiForgeryToken]
        public ActionResult Copy(int id)
        {
            Category category = db.Categories.Find(id);


            if (category == null)
            {
                return HttpNotFound();
            }

            Category cloneCategory = category.Clone() as Category;

            //Category cloneCategory = new Category
            //{
            //    CategoryName = category.CategoryName,
            //    CategoryImage = category.CategoryImage
            //};

            // Thêm bản sao vào DbSet và lưu thay đổi
            db.Categories.Add(cloneCategory);
            db.SaveChanges();

            foreach (var productItem in category.Products)
            {
                var clonedProductItem = new Product
                {
                    ProductName = productItem.ProductName,
                    Technology = productItem.Technology,
                    IntialPrice = productItem.IntialPrice,
                    Price = productItem.Price,
                    Desciption = productItem.Desciption,
                    BrandID = productItem.BrandID,
                    OriginOfBrand = productItem.OriginOfBrand,
                    OriginOfProduction = productItem.OriginOfProduction,
                    SkinType = productItem.SkinType,
                    Attribute = productItem.Attribute,
                    Sex = productItem.Sex,
                    SkinProblem = productItem.SkinProblem,
                    MainIngredients = productItem.MainIngredients,
                    FullIngredients = productItem.FullIngredients,
                    amount = productItem.amount,
                    CategoryID = cloneCategory.CategoryID,
                };

                db.Products.Add(clonedProductItem);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
