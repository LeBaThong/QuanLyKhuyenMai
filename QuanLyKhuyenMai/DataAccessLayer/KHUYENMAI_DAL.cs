using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace DataAccessLayer
{
    public class KHUYENMAI_DAL
    {

        public static List<KHUYENMAI_DTO> LoadKhuyenMai()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var lstKhuyenMai = db.KHUYENMAIs;
            var lstLoaiKH = db.LOAIKHACHHANGs;
            var lstHTGG = db.HINHTHUCGIAMGIAs;
            var lstHTTK = db.HINHTHUCTANGKEMs;
            var lstHTVC = db.HINHTHUCVOUCHERs;
            var lstLoaiSP = db.LOAISANPHAMs;

            List<KHUYENMAI_DTO> lstKhuyenMaiDTO = new List<KHUYENMAI_DTO>();
            KHUYENMAI_DTO kmDTO;
            foreach (var item in lstKhuyenMai)
            {
                kmDTO = new KHUYENMAI_DTO();
                kmDTO.MAKM = item.MAKM;
                kmDTO.TENKM = item.TENKM;
                kmDTO.MALKH = item.MALKH;
                kmDTO.MALSP = item.MALSP;
                kmDTO.MAHTGG = item.MAHTGG;
                kmDTO.MAHTTK = item.MAHTTK;
                kmDTO.MAHTVC = item.MAHTVC;
                kmDTO.NGAYBATDAU = item.NGAYBATDAU;
                Convert.ToDateTime(kmDTO.NGAYBATDAU).ToShortDateString();
                kmDTO.NGAYKETTHUC = item.NGAYKETTHUC;
                Convert.ToDateTime(kmDTO.NGAYKETTHUC).ToShortDateString();
                kmDTO.MOTA = item.MOTA;
                kmDTO.TRANGTHAI = item.TRANGTHAI;
                LOAIKHACHHANG lkh = lstLoaiKH.SingleOrDefault(n => n.MALKH == kmDTO.MALKH);
                LOAISANPHAM lsp = lstLoaiSP.SingleOrDefault(n => n.MALSP == kmDTO.MALSP);
                if (lkh != null)
                {
                    kmDTO.TENLKH = lkh.TENLKH.ToString();
                }
                if (lsp !=null)
                {
                    kmDTO.TENLSP = lsp.TENLSP.ToString();
                }
                HINHTHUCGIAMGIA htgg = lstHTGG.SingleOrDefault(n => n.MAHTGG == kmDTO.MAHTGG);

                HINHTHUCTANGKEM httk = lstHTTK.SingleOrDefault(n => n.MAHTTK == kmDTO.MAHTTK);

                HINHTHUCVOUCHER htvc = lstHTVC.SingleOrDefault(n => n.MAHTVC == kmDTO.MAHTVC);

                if (htvc != null)
                {
                    kmDTO.TENHT = htvc.TENVC.ToString();
                }
                else if (htgg != null)
                {
                    kmDTO.TENHT = htgg.TENHTGG.ToString();
                }
                else if (httk != null)
                {
                    kmDTO.TENHT = httk.TENHTTK.ToString();
                }


                lstKhuyenMaiDTO.Add(kmDTO);

            }
            return lstKhuyenMaiDTO;

        }
        //ADD
        public static KHUYENMAI_DTO ThemKhuyenMai(KHUYENMAI km)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            km = db.KHUYENMAIs.Add(km);
            db.SaveChanges();
            KHUYENMAI_DTO kmDTO = CapNhatKhuyenMaiThanhKhuyenMaiDTO(km);
            return kmDTO;
        }

        //UPDATE
        public static KHUYENMAI_DTO SuaKhuyenMai(KHUYENMAI km)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            KHUYENMAI kmUpdate = db.KHUYENMAIs.SingleOrDefault(n => n.MAKM == km.MAKM);
            if (kmUpdate == null)
            {
                return null;
            }
            kmUpdate.TENKM = km.TENKM;
            kmUpdate.MALKH = km.MALKH;
            kmUpdate.MALSP = km.MALSP;
            kmUpdate.MAHTGG = km.MAHTGG;
            kmUpdate.MAHTTK = km.MAHTTK;
            kmUpdate.MAHTVC = km.MAHTVC;
            kmUpdate.NGAYBATDAU = km.NGAYBATDAU;
            kmUpdate.NGAYKETTHUC = km.NGAYKETTHUC;
            kmUpdate.MOTA = km.MOTA;
            kmUpdate.TRANGTHAI = km.TRANGTHAI;
            db.SaveChanges();
            KHUYENMAI_DTO kmDTO = CapNhatKhuyenMaiThanhKhuyenMaiDTO(kmUpdate);
            return kmDTO;
        }
        //DELETE
        public static bool XoaKhuyenMai(int maKM)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            KHUYENMAI km = db.KHUYENMAIs.SingleOrDefault(n => n.MAKM == maKM);
            if (km == null)
            {
                return false;
            }
            db.KHUYENMAIs.Remove(km);
            db.SaveChanges();
            return true;
           
        }
        //UPDATE KM TO KMDTO
        public static KHUYENMAI_DTO CapNhatKhuyenMaiThanhKhuyenMaiDTO(KHUYENMAI km)
        {
            KHUYENMAI_DTO kmDTO = new KHUYENMAI_DTO();
            kmDTO.MAKM = km.MAKM;
            kmDTO.TENKM = km.TENKM;

            kmDTO.MALKH = km.MALKH;
            kmDTO.MALSP = km.MALSP;

            kmDTO.MAHTGG = km.MAHTGG;
            kmDTO.MAHTTK = km.MAHTTK;
            kmDTO.MAHTVC = km.MAHTVC;
            if (km.MAHTGG != null)
            {
                kmDTO.TENHT = km.HINHTHUCGIAMGIA.TENHTGG;
            }
            else if (km.MAHTTK != null)
            {
                kmDTO.TENHT = km.HINHTHUCTANGKEM.TENHTTK;
            }
            else if (km.MAHTVC != null)
            {
                kmDTO.TENHT = km.HINHTHUCVOUCHER.TENVC;
            }

            kmDTO.NGAYBATDAU = km.NGAYBATDAU;
            kmDTO.NGAYKETTHUC = km.NGAYKETTHUC;
            kmDTO.MOTA = km.MOTA;
            kmDTO.TRANGTHAI = km.TRANGTHAI;
            kmDTO.TENLKH = km.LOAIKHACHHANG.TENLKH;
            kmDTO.TENLSP = km.LOAISANPHAM.TENLSP;
            return kmDTO;
        }
        public static KHUYENMAI TimKhuyenMaiMax()
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            List<KHUYENMAI> lstKM = db.KHUYENMAIs.ToList();
            int makmMax = lstKM.Max(n => n.MAKM);
            KHUYENMAI km = lstKM.Single(n => n.MAKM == makmMax);
            return km;
            
        }
        public static KHUYENMAI TimKhuyenMai(int makm)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            var km = db.KHUYENMAIs.Find(makm);           
            return km;
        }
    }
}
