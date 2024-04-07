using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern.Facade
{
    public class BrandFacade
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        public List<Brand> GetAllBrands()
        {
            return db.Brands.ToList();
        }

        public Brand GetBrand(int id)
        {
            return db.Brands.Find(id);
        }

        public void CreateBrand(Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ImgBrand != null && ImgBrand.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImgBrand.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/image"), fileName);
                brand.BrandImage = fileName;
                ImgBrand.SaveAs(path);
            }
            db.Brands.Add(brand);
            db.SaveChanges();
        }

        public void EditBrand(Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ImgBrand != null && ImgBrand.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImgBrand.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/image"), fileName);
                brand.BrandImage = fileName;
                ImgBrand.SaveAs(path);
            }
            db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
        }
    }
}