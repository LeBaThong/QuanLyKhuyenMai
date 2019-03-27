using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataTransferObject;
using DataAccessLayer;


namespace QuanLyKhuyenMai.ucKhuyenMai
{
    public partial class ucDonHang : UserControl
    {
        public ucDonHang()
        {
            InitializeComponent();
            dtpNgayTaoDH.Value = DateTime.Now;

        }
        List<DONHANG_DTO> lstDH_DTO = new List<DONHANG_DTO>();
        List<SANPHAM_DTO> dsSanPhamDonHang = new List<SANPHAM_DTO>();
        protected override void OnLoad(EventArgs e)
        {
            //load combobox loai loại sản phẩm
            mCmbLoaiSanPham.DataSource = LOAISANPHAM_BLL.LoadLoaiSanPham();
            mCmbLoaiSanPham.DisplayMember = "TENLSP";
            mCmbLoaiSanPham.ValueMember = "MALSP";

            //load san pham lên combobox san pham

            mCmbSanPham.DataSource = SANPHAM_BLL.LoadSanPham(mCmbLoaiSanPham.Text.Trim());
            mCmbSanPham.DisplayMember = "TENSP";
            mCmbSanPham.ValueMember = "MASP";
        }

        private void mCmbLoaiSanPham_TextChanged(object sender, EventArgs e)
        {

            if (mCmbLoaiSanPham.Text != "")
            {
                mCmbSanPham.DataSource = SANPHAM_BLL.LoadSanPham(mCmbLoaiSanPham.Text.Trim());
                mCmbSanPham.DisplayMember = "TENSP";
                mCmbSanPham.ValueMember = "MASP";
            }

        }

        private void mbtnThem_Click(object sender, EventArgs e)
        {
            SANPHAM_DTO spDTO = new SANPHAM_DTO();
            spDTO.MASP = Convert.ToInt32(mCmbSanPham.SelectedValue);
            spDTO.TENSP = mCmbSanPham.Text.Trim();
            spDTO.MALSP = Convert.ToInt32(mCmbLoaiSanPham.SelectedValue);
            spDTO.TENLSP = mCmbLoaiSanPham.Text.Trim();
            spDTO.SOLUONG = Convert.ToInt32(numSL.Value);
            dsSanPhamDonHang.Add(spDTO);
            LoadSP_DH();
        }
        public void LoadSP_DH()
        {
            dgvSP_DH.DataSource = typeof(List<SANPHAM_DTO>);
            dgvSP_DH.DataSource = dsSanPhamDonHang;
        }
        public void LoadDH()
        {
            mDgvDonHang.DataSource = typeof(List<DONHANG_DTO>);
            mDgvDonHang.DataSource = lstDH_DTO;
        }

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = KHACHHANG_BLL.TimKhachHang(Convert.ToInt32(txtMaKH.Text));

            DONHANG dh = new DONHANG();
            dh.MAKH = kh.MAKH;
            dh.NGAYTAO = dtpNgayTaoDH.Value;
            dh.PHUONGTHUCTT = txtPTTT.Text;
            dh.COKM = true;
            dh.SOLUONG = 5;
            if (rdbHoanThanh.Checked)
            {
                dh.TRANGTHAI = true;
            }
            else
            {
                dh.TRANGTHAI = false;
            }
            dh.MAKM = Convert.ToInt32(txtVoucher.Text);


            DONHANG_DTO dhDTO = DONHANG_BLL.ThemDonHang(dh);
            if (dhDTO != null)
            {
                lstDH_DTO.Add(dhDTO);

            }



            CHITIETDONHANG ctdh = new CHITIETDONHANG();
            bool i;
            foreach (var item in dsSanPhamDonHang)
            {
                ctdh.MADH = dhDTO.MADH;
                ctdh.MASP = item.MASP;
                i = CHITIETDONHANG_BLL.ThemChiTietDonHang(ctdh);
            }
            if ( i =true && lstDH_DTO != null)
            {
                LoadDH();
                LoadSP_DH();
                MessageBox.Show("Thêm đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            

        }
    }
}
