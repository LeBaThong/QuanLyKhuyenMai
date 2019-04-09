using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CHITIETDONHANG_BLL
    {
        public static bool ThemChiTietDonHang(CHITIETDONHANG ctdh)
        {
            return CHITIETDONHANG_DAL.ThemChiTietDonHang(ctdh);
        }
        public static bool XoaChiTietDonHang(int mactdh)
        {
            return CHITIETDONHANG_DAL.XoaChiTietDonHang(mactdh);
        }
    }
}
