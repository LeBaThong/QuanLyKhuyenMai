using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class KHACHHANG_BLL
    {
        public static KHACHHANG TimKhachHang(int id)
        {
            return KHACHHANG_DAL.TimKhachHang(id);
        }
    }
}
