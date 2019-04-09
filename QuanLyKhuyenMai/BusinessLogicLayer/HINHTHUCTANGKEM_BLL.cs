using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HINHTHUCTANGKEM_BLL
    {
        public static List<HINHTHUCTANGKEM> LoadHinhThucTangKem()
        {
            return HINHTHUCTANGKEM_DAL.LoadHinhThucTangKem();
        }
        public static HINHTHUCTANGKEM TimHTTK(int mahttk)
        {
            
            return HINHTHUCTANGKEM_DAL.TimHTTK(mahttk);
        }
    }
}
