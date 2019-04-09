using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PHUONGTHUCTHANHTOAN_BLL
    {
        public static List<object> LoadPTTT()
        {
            return PHUONGTHUCTHANHTOAN_DAL.LoadPhuongThucThanhToan();
        }
    }
}
