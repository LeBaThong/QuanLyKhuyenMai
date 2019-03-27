using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LOAISANPHAM_DAL
    {

        public static List<LOAISANPHAM> LoadLoaiSanPham()
        {

            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstLoaiSP = db.LOAISANPHAMs.ToList();
            return lstLoaiSP;
        }
    }
}
