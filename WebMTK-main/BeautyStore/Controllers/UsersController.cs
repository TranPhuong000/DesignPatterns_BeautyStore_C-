using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.DesignPattern;
using BeautyStore.Interfaces;
using BeautyStore.Models;

namespace BeautyStore.Controllers
{
    public class UsersController : Controller
    {
        private BeautyStoreEntities1 db;
        private IAccountValidator _accountValidator;

        public UsersController()
        {
            db = new BeautyStoreEntities1();
            _accountValidator = new AccountValidatorProxy(db);
        }
       
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                var account = _accountValidator.ValidateAccountLogin(cust.UserEmail, cust.UserPassword);

                if (account != null)
                {
                    Session["Account"] = account;

                    if (account is AdminAccount)
                    {
                        return RedirectToAction("Index", "Admin/AdminHome");
                    }
                    else if (account is Customer)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ThongBao = "*Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["MyCart"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail([Bind(Include = "UserID,UserName,UserEmail,PhoneNumber,UserPassword,AvatarImage")] Customer customer, HttpPostedFileBase ImageUser)
        {
            if (ModelState.IsValid)
            {
                if (ImageUser != null)
                {
                    //Lấy tên file của hình được up lên

                    var fileName = Path.GetFileName(ImageUser.FileName);

                    //Tạo đường dẫn tới file

                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    //Lưu tên

                    customer.AvatarImage = fileName;
                    //Save vào Images Folder
                    ImageUser.SaveAs(path);

                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Detail", "Users");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection customer)
        {
            if (customer["userPassword"] != customer["rePassword"])
            {
                @ViewBag.Notification = "Mật khẩu xác nhận không chính xác";
                return View();
            }
            else
            {
                // Sử dụng Proxy để kiểm tra tính hợp lệ của tài khoản trước khi tạo mới
                //trước khi tạo mới một tài khoản, chúng ta sẽ sử dụng Proxy để kiểm tra email đã có người sử dụng hay chưa,
                ////đảm bảo rằng không có tài khoản nào khác tồn tại với cùng một địa chỉ email và cùng một mật khẩu.
                var account = _accountValidator.ValidateAccountSignup(customer["userEmail"]);

                if (account != null)
                {
                    ViewBag.NotificationEmail = "Đã tồn tại tài khoản có cùng email";
                    return View();
                }
                else
                {
                    // Tạo CustomerBuilder từ FormCollection
                    var builder = new CustomerBuilder()
                        //Thiết lập thuộc tính username trong CustomerBuilder

                        .WithUserName(customer["userName"])
                        //Thiết lập thuộc tính userEmail trong CustomerBuilder

                        .WithUserEmail(customer["userEmail"])
                        //Thiết lập thuộc tính phoneNumber trong CustomerBuilder

                        .WithPhoneNumber(customer["phoneNumber"])
                        //Thiết lập thuộc tính userPassword trong CustomerBuilder

                        .WithUserPassword(customer["userPassword"]);


                    // Tạo Customer từ CustomerBuilder
                    var accout = builder.Build();

                    db.Customers.Add(accout);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Users");
                }
            }

        }

    }
}