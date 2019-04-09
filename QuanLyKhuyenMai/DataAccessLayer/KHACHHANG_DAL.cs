using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KHACHHANG_DAL
    {
        public static KHACHHANG TimKhachHang(int id)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            KHACHHANG kh = db.KHACHHANGs.Find(id);
                     
            return kh;
        }
        //public static KHACHHANG TimKhachHang(int makh)
        //{
        //    QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
        //    KHACHHANG kh = db.KHACHHANGs.Find(makh);
        //    return kh;
        //}
    }
}
