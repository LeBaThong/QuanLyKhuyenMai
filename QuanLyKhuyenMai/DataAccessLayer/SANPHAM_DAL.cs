using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataTransferObject;

namespace DataAccessLayer
{
    public class SANPHAM_DAL
    {
        
        //load tat ca san pham
        public static List<SANPHAM> LoadSanPham()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstSP = db.SANPHAMs.ToList();
            return lstSP;
        }
        //load sản phẩm lên combobox theo loại sản phẩm 
        public static List<SANPHAM_DTO> LoadSanPham(string tenLSP)
        {
            List<SANPHAM_DTO> lsSP_CANTIM = new List<SANPHAM_DTO>();
            List<SANPHAM_DTO> lstSP_DTO = new List<SANPHAM_DTO>();
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstSP = db.SANPHAMs.ToList();
            SANPHAM_DTO spDTO;
            foreach (var item in lstSP)
            {
                spDTO = new SANPHAM_DTO();
                spDTO.MASP = item.MASP;
                spDTO.TENSP = item.TENSP;
                spDTO.MALSP = item.MALSP;
                spDTO.TENLSP = item.LOAISANPHAM.TENLSP;
                lstSP_DTO.Add(spDTO);
            }
            foreach (var item in lstSP_DTO)
            {
                if (item.TENLSP ==tenLSP)
                {
                    lsSP_CANTIM.Add(item);
                }
            }
            return lsSP_CANTIM;
        }
        public static SANPHAM TimSanPham(int masp)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            SANPHAM sp = db.SANPHAMs.Find(masp);
            return sp;
        }
    }
}
