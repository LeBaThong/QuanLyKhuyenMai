using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace DataAccessLayer
{
    public class PHUONGTHUCTHANHTOAN_DAL
    {
        public static List<object> LoadPhuongThucThanhToan()
        {
            List<object> lstPTTT = new List<object>();
            lstPTTT.Add(PHUONGTHUCTHANHTOAN_DTO.DIEM);
            lstPTTT.Add(PHUONGTHUCTHANHTOAN_DTO.TIEN_MAT);
            lstPTTT.Add(PHUONGTHUCTHANHTOAN_DTO.THE_NGAN_HANG);
            lstPTTT.Add(PHUONGTHUCTHANHTOAN_DTO.THE_VISA);
            return lstPTTT;
        }
    }
}
