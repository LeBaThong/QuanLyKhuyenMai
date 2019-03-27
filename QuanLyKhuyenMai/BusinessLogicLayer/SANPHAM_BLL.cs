using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SANPHAM_BLL
    {
        //load sản phẩm theo mã loại  sản phẩm
        public static List<SANPHAM_DTO> LoadSanPham(string tenLSP)
        {
            return SANPHAM_DAL.LoadSanPham(tenLSP);
        }
        //load tất cả sản phẩm
        public static List<SANPHAM> LoadSanPham()
        {
            return SANPHAM_DAL.LoadSanPham();
        }
    }
}
