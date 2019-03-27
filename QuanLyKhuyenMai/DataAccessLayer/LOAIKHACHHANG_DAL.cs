using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LOAIKHACHHANG_DAL
    {
        public static List<LOAIKHACHHANG> LoadLoaiKhachHang()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstLoaiKH = db.LOAIKHACHHANGs.ToList();
            return lstLoaiKH;

        }
    }
}
