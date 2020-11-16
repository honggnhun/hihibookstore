using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sach01.Models;

namespace Sach01.Controllers
{
    public class GioMuaHangController : Controller
    {
        Sach01Entities _db = new Sach01Entities();
        // GET: GioHang
        public GioHang GetGioHang()
        {
            GioHang giohang = Session["GioHang"] as GioHang;
            if (giohang == null || Session["GioHang"] == null)
            {
                giohang = new GioHang();
                Session["GioHang"] = giohang;
            }
            return giohang;
        }

        // Phương thức thêm item vào giỏ hàng
        public ActionResult ThemVaoGio(int id)
        {
            var sach = _db.Saches.SingleOrDefault(s => s.IdSach == id);
            if (sach != null)
            {
                GetGioHang().Them(sach);
            }
            return RedirectToAction("HienThiGioHang", "GioMuaHang");
        }

        //Trang giỏ hàng
        public ActionResult HienThiGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("HienThiGioHang", "GioMuaHang");
            }
            GioHang giohang = Session["GioHang"] as GioHang;
            return View(giohang);
        }

        public ActionResult CapNhatSoLuongGH(FormCollection form)
        {
            GioHang giohang = Session["GioHang"] as GioHang;
            int id_sach = int.Parse(form["IdSach"]);
            int soluong = int.Parse(form["SoLuong"]);
            giohang.CapNhatSoLuongMH(id_sach, soluong);

            return RedirectToAction("HienThiGioHang", "GioMuaHang");
        }

        public ActionResult XoaGioHang(int id)
        {
            GioHang giohang = Session["GioHang"] as GioHang;
            giohang.XoaItemGioHang(id);

            return RedirectToAction("HienThiGioHang", "GioMuaHang");
        }

        public PartialViewResult TuiGioHang()
        {
            int _tongitem = 0;
            GioHang giohang = Session["GioHang"] as GioHang;
            if (giohang != null)
            {
                _tongitem = giohang.TongSoLuong();
            }
            ViewBag.infoGioHang = _tongitem;
            return PartialView("TuiGioHang");
        }

        
    }
}