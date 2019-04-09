using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
namespace DataAccessLayer
{
    public class DONHANG_DAL
    {
        public static DONHANG ThemDonHang(DONHANG dh)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            dh = db.DONHANGs.Add(dh);
            db.SaveChanges();           
            return dh;
        }
        public static List<DONHANG> LoadDonHang()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstDH = db.DONHANGs.ToList();
            return lstDH;
        }
        public static bool XoaDonHang(int id)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            DONHANG dh = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(dh);
            db.SaveChanges();
            return true;
        }
    }
}
