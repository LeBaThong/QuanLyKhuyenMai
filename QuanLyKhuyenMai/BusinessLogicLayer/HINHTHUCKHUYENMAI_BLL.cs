using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class HINHTHUCKHUYENMAI_BLL
    {
        public static List<object> LoadHinhThucKhuyenMai()
        {
            return HINHTHUCKHUYENMAI_DAL.LoadHinhThucKhuyenMai();
        }
    }
}
