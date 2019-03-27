using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class KHUYENMAI_BLL
    {
        public static List<KHUYENMAI_DTO> LoadKhuyenMai()
        {
            return KHUYENMAI_DAL.LoadKhuyenMai();
        }
        public static KHUYENMAI_DTO ThemKhuyenMai(KHUYENMAI km)
        {
            return KHUYENMAI_DAL.ThemKhuyenMai(km);
        }
        public static KHUYENMAI_DTO SuaKhuyenMai(KHUYENMAI km)
        {
            return KHUYENMAI_DAL.SuaKhuyenMai(km);
        }
        public static bool XoaKhuyenMai(int maKM)
        {
            return KHUYENMAI_DAL.XoaKhuyenMai(maKM);
        }
    }
}
