using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DONHANG_BLL
    {
        public static DONHANG ThemDonHang(DONHANG dh)
        {
            return DONHANG_DAL.ThemDonHang(dh);
        }
        public static List<DONHANG> LoadDonHang()
        {
            return DONHANG_DAL.LoadDonHang();
        }
        public static bool XoaDonHang(int id)
        {
            return DONHANG_DAL.XoaDonHang(id);
        }
    }
}
