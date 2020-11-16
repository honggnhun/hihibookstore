using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sach01.Models;

namespace Sach00.Controllers
{
    public class LoginController : Controller
    {
        Sach01Entities _db = new Sach01Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //method Login
        [HttpPost]
        public ActionResult Authen(User _user)
        {
            var check = _db.Users.Where(s => s.Email.Equals(_user.Email) && s.Password.Equals(_user.Password)).FirstOrDefault();
            if (check == null)
            {
                _user.LogInErrorMessage = "Lỗi email hoặc password! Thử nhập lại";
                return View("Index", _user);
            }
            else
            {
                var test = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (test.Email != "admin@gmail.com") //Nếu là user
                {
                    Session["IdUser"] = _user.IdUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("Index", "Home");
                }
                else //Nếu là admin
                {
                    return RedirectToAction("Index", "DanhMuc");
                }
            }
        }

        //method SignUp
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null) //Nếu Email đang sử dụng chưa được đăng ký trước đó
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("Index"); //Nếu thành công nó điều hướng về trang chủ
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại! Vui lòng sử dụng email khác!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}