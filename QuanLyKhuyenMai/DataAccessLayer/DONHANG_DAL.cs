using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
namespace DataAccessLayer
{
    public class DONHANG_DAL
    {
        public static DONHANG_DTO ThemDonHang(DONHANG dh)
        {
            QuanLyKhuyenMaiEntities db = DataProvider.dbContext;
            dh = db.DONHANGs.Add(dh);
            db.SaveChanges();
            DONHANG_DTO dhDTO = CapNhatDonHangThanhDonHangDTO(dh);
            return dhDTO;
        }
        public static DONHANG_DTO CapNhatDonHangThanhDonHangDTO(DONHANG dh)
        {
            DONHANG_DTO dhDTO = new DONHANG_DTO();
            dhDTO.MADH = dh.MADH;
            dhDTO.NGAYTAO = dh.NGAYTAO;
            dhDTO.PHUONGTHUCTT = dh.PHUONGTHUCTT;
            dhDTO.COKM = dh.COKM;
            dhDTO.SOLUONG = dh.SOLUONG;
            dhDTO.TRANGTHAI = dh.TRANGTHAI;
            dhDTO.MAKH = dh.MAKH;
            dhDTO.MAKM = dh.MAKM;
            dhDTO.TENKH = dh.KHACHHANG.TENKH;
            dhDTO.TENKM = dh.KHUYENMAI.TENKM;

            return dhDTO;
        }
    }
}
