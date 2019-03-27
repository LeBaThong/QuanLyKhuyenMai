using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class HINHTHUCVOUCHER_BLL
    {
        public static List<HINHTHUCVOUCHER> LoadHinhThucVoucher()
        {
            return HINHTHUCVOUCHER_DAL.LoadHinhThucVoucher();
        }
    }
}
