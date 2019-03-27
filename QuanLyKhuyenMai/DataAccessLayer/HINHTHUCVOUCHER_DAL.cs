using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HINHTHUCVOUCHER_DAL
    {
        public static List<HINHTHUCVOUCHER> LoadHinhThucVoucher()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstHTVC = db.HINHTHUCVOUCHERs.ToList();
            return lstHTVC;
        }
    }
}
