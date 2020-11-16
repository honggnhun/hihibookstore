using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sach01.Models;

namespace Sach00.Controllers
{
    public class DanhMucController : Controller
    {
        Sach01Entities _db = new Sach01Entities();
        // GET: DanhMuc
        public ActionResult Index()
        {
            return View(_db.DanhMucs.ToList());
        }

        // GET: DanhMuc/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.DanhMucs.Where(s => s.IdDanhMuc == id).FirstOrDefault());
        }

        // GET: DanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMuc/Create
        [HttpPost]
        public ActionResult Create(DanhMuc dm)
        {
            try
            {
                // TODO: Add insert logic here
                _db.DanhMucs.Add(dm);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMuc/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_db.DanhMucs.Where(s => s.IdDanhMuc == id).FirstOrDefault());
        }

        // POST: DanhMuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DanhMuc dm)
        {
            try
            {
                // TODO: Add update logic here
                _db.Entry(dm).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.DanhMucs.Where(s => s.IdDanhMuc == id).FirstOrDefault());
        }

        // POST: DanhMuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DanhMuc dm)
        {
            try
            {
                // TODO: Add delete logic here
                dm = _db.DanhMucs.Where(s => s.IdDanhMuc == id).FirstOrDefault();
                _db.DanhMucs.Remove(dm);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("IdDanhMuc đang sử dụng");
            }
        }
    }
}
