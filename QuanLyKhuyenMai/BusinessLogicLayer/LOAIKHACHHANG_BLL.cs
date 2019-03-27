using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class LOAIKHACHHANG_BLL
    {
        public static List<LOAIKHACHHANG> LoadLoaiKhachHang()
        {
            return LOAIKHACHHANG_DAL.LoadLoaiKhachHang();
        }
    }
}
