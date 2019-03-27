using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HINHTHUCGIAMGIA_DAL
    {
        public static List<HINHTHUCGIAMGIA> LoadHinhThucGiamGia()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstHTGG = db.HINHTHUCGIAMGIAs.ToList();
            return lstHTGG;
        }
    }
}
