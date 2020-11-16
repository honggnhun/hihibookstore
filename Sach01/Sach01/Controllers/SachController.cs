using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sach01.Models;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace Sach01.Controllers
{
    public class SachController : Controller
    {
        Sach01Entities _db = new Sach01Entities();
        // GET: Sach
        public ActionResult Index(string searchBy,string search)
        {
            if (searchBy == "TenSach")
                return View(_db.Saches.Where(s=>s.TenSach.StartsWith(search)).ToList());
            else if(searchBy == "Available")
                return View(_db.Saches.Where(s => s.Available==search).ToList());
            else // None
            return View(_db.Saches.ToList());
        }

        // GET: Sach/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Saches.Where(s => s.IdSach == id).FirstOrDefault());
        }

        // GET: Sach/Create
        public ActionResult Create()
        {
            Sach sach = new Sach();
            return View(sach);
        }

        // POST: Sach/Create
        [HttpPost]
        public ActionResult Create(Sach sach)
        {
            try
            {
                // TODO: Add insert logic here
                if (sach.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sach.ImageUpload.FileName);
                    string extension = Path.GetExtension(sach.ImageUpload.FileName);
                    fileName = fileName + extension;
                    sach.HinhAnh = "~/images/" + fileName;
                    sach.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/"), fileName));
                }
                _db.Saches.Add(sach);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sach/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.Saches.Where(s => s.IdSach == id).FirstOrDefault());
        }

        // POST: Sach/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sach sach)
        {
            try
            {
                // TODO: Add update logic here
                if (sach.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sach.ImageUpload.FileName);
                    string extension = Path.GetExtension(sach.ImageUpload.FileName);
                    fileName = fileName + extension;
                    sach.HinhAnh = "~/images/" + fileName;
                    sach.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/"), fileName));
                }
                _db.Entry(sach).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sach/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Saches.Where(s => s.IdSach == id).FirstOrDefault());
        }

        // POST: Sach/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sach sach)
        {
            try
            {
                // TODO: Add delete logic here
                sach = _db.Saches.Where(s => s.IdSach == id).FirstOrDefault();
                _db.Saches.Remove(sach);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ChonDanhMuc()
        {
            DanhMuc dm = new DanhMuc();
            dm.DSDanhMuc = _db.DanhMucs.ToList<DanhMuc>();
            return PartialView(dm);
        }
    }
}
