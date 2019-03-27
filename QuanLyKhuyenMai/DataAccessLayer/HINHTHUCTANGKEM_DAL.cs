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
    }
}
