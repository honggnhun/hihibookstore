using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sach01.Models;

namespace Sach00.Controllers
{
    public class HomeController : Controller
    {
        Sach01Entities _db = new Sach01Entities();

        public ActionResult Index()
        {
            return View(_db.Saches.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}