using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sach01.Models
{
    public class GioHangItem
    {
        public Sach _sach { get; set; }
        public int _soluong { get; set; }
    }

    // Giỏ hàng
    public class GioHang
    {
        List<GioHangItem> items = new List<GioHangItem>();
        public IEnumerable<GioHangItem> Items
        {
            get { return items; }
        }
        public void Them(Sach _s, int _sl = 1)
        {
            var item = items.FirstOrDefault(s => s._sach.IdSach == _s.IdSach);
            if (item == null)
            {
                items.Add(new GioHangItem
                {
                    _sach = _s,
                    _soluong = _sl
                });
            }
            else
            {
                item._soluong += _sl;
            }    
        }

        public void CapNhatSoLuongMH(int id, int _soluong)
        {
            var item = items.Find(s => s._sach.IdSach == id);
            if (item != null)
            {
                item._soluong = _soluong;
            }    
        }
        
        public double TongTien()
        {
            var tong = items.Sum(s => s._sach.UnitGia * s._soluong);
            return (double)tong;
        }

        public void XoaItemGioHang(int id)
        {
            items.RemoveAll(s => s._sach.IdSach == id);
        }

        //Tổng số lượng mua hàng
        public int TongSoLuong()
        {
            return items.Sum(s => s._soluong);
        }
        
        public void XoaGioHang()
        {
            items.Clear(); //Xóa giỏ hàng để thực hiện mua hàng mới
        }
    }
}