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
        public static DONHANG_DTO ThemDonHang(DONHANG dh)
        {
            return DONHANG_DAL.ThemDonHang(dh);
        }
    }
}
