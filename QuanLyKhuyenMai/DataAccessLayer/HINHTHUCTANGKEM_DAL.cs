using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class HINHTHUCTANGKEM_DAL
    {
        public static List<HINHTHUCTANGKEM> LoadHinhThucTangKem()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstHTTK = db.HINHTHUCTANGKEMs.ToList();
            return lstHTTK;
        }
        public static HINHTHUCTANGKEM TimHTTK(int mahttk)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var HTTK = db.HINHTHUCTANGKEMs.Find(mahttk);
            return HTTK;
        }
    }
}
