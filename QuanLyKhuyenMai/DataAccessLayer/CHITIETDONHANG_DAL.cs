using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CHITIETDONHANG_DAL
    {
        public static bool ThemChiTietDonHang(CHITIETDONHANG ctdh)
        {

            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            ctdh = db.CHITIETDONHANGs.Add(ctdh);
            db.SaveChanges();
            return true;
        }
        public static bool XoaChiTietDonHang(int mactdh)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstCtdh = db.CHITIETDONHANGs.ToList();
            foreach (CHITIETDONHANG item in lstCtdh)
            {
                if (item.MADH == mactdh)
                {
                    db.CHITIETDONHANGs.Remove(item);
                    db.SaveChanges();
                }
            }
            return true;
        }
    }
}
