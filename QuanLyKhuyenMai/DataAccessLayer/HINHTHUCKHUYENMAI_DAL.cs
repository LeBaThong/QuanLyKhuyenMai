using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace DataAccessLayer
{
    public class HINHTHUCKHUYENMAI_DAL
    {
        //public static List<HINHTHUCKHUYENMAI_DTO> LoadHinhThucKhuyenMai()
        //{
        //    QuanLyKhuyenMaiEntities db = DataProvider.dbContext;

        //    var lstHTGG = db.HINHTHUCGIAMGIAs;
        //    var lstHTTK = db.HINHTHUCTANGKEMs;
        //    var lstHTVC = db.HINHTHUCVOUCHERs;

        //    List<HINHTHUCKHUYENMAI_DTO> lstHTKM_DTO = new List<HINHTHUCKHUYENMAI_DTO>();
        //    HINHTHUCKHUYENMAI_DTO htkmDTO;
        //    foreach (var item in lstHTGG)
        //    {
        //        htkmDTO = new HINHTHUCKHUYENMAI_DTO();
        //        htkmDTO.TENHTKM = item.TENHTGG;
        //        lstHTKM_DTO.Add(htkmDTO);
        //    }
        //    foreach (var item in lstHTTK)
        //    {
        //        htkmDTO = new HINHTHUCKHUYENMAI_DTO();
        //        htkmDTO.TENHTKM = item.TENHTTK;
        //        lstHTKM_DTO.Add(htkmDTO);
        //    }
        //    foreach (var item in lstHTVC)
        //    {
        //        htkmDTO = new HINHTHUCKHUYENMAI_DTO();
        //        htkmDTO.TENHTKM = item.TENVC;
        //        lstHTKM_DTO.Add(htkmDTO);
        //    }
        //    return lstHTKM_DTO;
        //}

        public static List<object> LoadHinhThucKhuyenMai()
        {
            List<object> lstHTKM = new List<object>();
            lstHTKM.Add(HINHTHUCKHUYENMAI_DTO.GIAM_GIA);
            lstHTKM.Add(HINHTHUCKHUYENMAI_DTO.TANG_KEM);
            lstHTKM.Add(HINHTHUCKHUYENMAI_DTO.VOUCHER);
            return lstHTKM;
        }

    }
}
