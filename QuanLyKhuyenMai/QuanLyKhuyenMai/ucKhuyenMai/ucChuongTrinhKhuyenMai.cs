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
    public partial class ucChuongTrinhKhuyenMai : UserControl
    {
        public ucChuongTrinhKhuyenMai()
        {
            InitializeComponent();
        }
        List<KHUYENMAI_DTO> lstKhuyenMaiDTO;

        protected override void OnLoad(EventArgs e)
        {
            //load chuong trinh khuyen mai
            lstKhuyenMaiDTO = KHUYENMAI_BLL.LoadKhuyenMai();
            mDgvChuongTrinhKhuyenMai.DataSource = typeof(KHUYENMAI_DTO);
            mDgvChuongTrinhKhuyenMai.DataSource = lstKhuyenMaiDTO;
            //load combobox loai khach hang
            mCmbLoaiKH.DataSource = LOAIKHACHHANG_BLL.LoadLoaiKhachHang();
            mCmbLoaiKH.DisplayMember = "TENLKH";
            mCmbLoaiKH.ValueMember = "MALKH";
            //load loại sản phẩm
            cmbLSP.DataSource = LOAISANPHAM_BLL.LoadLoaiSanPham();
            cmbLSP.DisplayMember = "TENLSP";
            cmbLSP.ValueMember = "MALSP";
            //load combobox hinh thuc khuyen mai
            mCmbHTKM.DataSource = HINHTHUCKHUYENMAI_BLL.LoadHinhThucKhuyenMai();
            SetDoRongCot();

        }

        private void mCmbHTKM_TextChanged(object sender, EventArgs e)
        {
            if (mCmbHTKM.Text == "TANG_KEM")
            {
                mCmbTenHTKM.DataSource = HINHTHUCTANGKEM_BLL.LoadHinhThucTangKem();
                mCmbTenHTKM.DisplayMember = "TENHTTK";
                mCmbTenHTKM.ValueMember = "MAHTTK";
            }
            else if (mCmbHTKM.Text == "GIAM_GIA")
            {
                mCmbTenHTKM.DataSource = HINHTHUCGIAMGIA_BLL.LoadHinhThucGiamGia();
                mCmbTenHTKM.DisplayMember = "TENHTGG";
                mCmbTenHTKM.ValueMember = "MAHTGG";
            }
            else if (mCmbHTKM.Text == "VOUCHER")
            {
                mCmbTenHTKM.DataSource = HINHTHUCVOUCHER_BLL.LoadHinhThucVoucher();
                mCmbTenHTKM.DisplayMember = "TENVC";
                mCmbTenHTKM.ValueMember = "MAHTVC";
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KHUYENMAI km = new KHUYENMAI();
            km.TENKM = txtTenKM.Text;
            km.MALKH = Convert.ToInt32(mCmbLoaiKH.SelectedValue);
            km.MALSP = Convert.ToInt32(cmbLSP.SelectedValue);
            km.NGAYBATDAU = dtpNgayBatDau.Value;
            km.NGAYKETTHUC = dtpNgayKetThuc.Value;
            km.MOTA = txtMoTa.Text;


            if (rdbThucHien.Checked)
            {
                km.TRANGTHAI = true;
            }
            else
            {
                km.TRANGTHAI = false;
            }


            if (mCmbHTKM.Text == "TANG_KEM")
            {
                km.MAHTTK = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }
            else if (mCmbHTKM.Text == "GIAM_GIA")
            {
                km.MAHTGG = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }
            else if (mCmbHTKM.Text == "VOUCHER")
            {
                km.MAHTVC = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }

            KHUYENMAI_DTO kmDTO = KHUYENMAI_BLL.ThemKhuyenMai(km);
            if (kmDTO != null)
            {
                lstKhuyenMaiDTO.Add(kmDTO);

            }
            if (lstKhuyenMaiDTO != null)
            {
                LoadDGVKhuyenMai();
                MessageBox.Show("Thêm khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public void LoadDGVKhuyenMai()
        {
            mDgvChuongTrinhKhuyenMai.DataSource = typeof(List<KHUYENMAI_DTO>);
            mDgvChuongTrinhKhuyenMai.DataSource = lstKhuyenMaiDTO;
            SetDoRongCot();
        }

        private void mDgvChuongTrinhKhuyenMai_Click(object sender, EventArgs e)
        {
            if (mDgvChuongTrinhKhuyenMai.SelectedRows != null)
            {
                DataGridViewRow dr = mDgvChuongTrinhKhuyenMai.SelectedRows[0];
                mLblMaKM.Text = dr.Cells["MAKM"].Value.ToString();
                txtTenKM.Text = dr.Cells["TENKM"].Value.ToString();
                mCmbLoaiKH.SelectedValue = dr.Cells["MALKH"].Value;
                cmbLSP.SelectedValue = dr.Cells["MALSP"].Value;
                if (dr.Cells["MAHTGG"].Value != null)
                {
                    mCmbHTKM.Text = HINHTHUCKHUYENMAI_DTO.GIAM_GIA.ToString();

                    mCmbTenHTKM.SelectedValue = dr.Cells["MAHTGG"].Value;
                }
                else if (dr.Cells["MAHTTK"].Value != null)
                {
                    mCmbHTKM.Text = HINHTHUCKHUYENMAI_DTO.TANG_KEM.ToString();
                    mCmbTenHTKM.SelectedValue = dr.Cells["MAHTTK"].Value;
                }
                else if (dr.Cells["MAHTVC"].Value != null)
                {
                    mCmbHTKM.Text = HINHTHUCKHUYENMAI_DTO.VOUCHER.ToString();
                    mCmbTenHTKM.SelectedValue = dr.Cells["MAHTVC"].Value;
                }

                dtpNgayBatDau.Value = Convert.ToDateTime(dr.Cells["NGAYBATDAU"].Value);
                dtpNgayKetThuc.Value = Convert.ToDateTime(dr.Cells["NGAYKETTHUC"].Value);
                txtMoTa.Text = dr.Cells["MOTA"].Value.ToString();
                if ((bool)dr.Cells["TRANGTHAI"].Value == true)
                {
                    rdbThucHien.Checked = true;
                }
                else
                {
                    rdbKetThuc.Checked = true;
                }
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (mLblMaKM.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn khuyến mãi cần sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Xử lý cập nhật database

            KHUYENMAI km = new KHUYENMAI();
            km.MAKM = Convert.ToInt32(mLblMaKM.Text);
            km.TENKM = txtTenKM.Text;
            km.MALKH = Convert.ToInt32(mCmbLoaiKH.SelectedValue);
            km.MALSP = Convert.ToInt32(cmbLSP.SelectedValue);
            km.NGAYBATDAU = dtpNgayBatDau.Value;
            km.NGAYKETTHUC = dtpNgayKetThuc.Value;
            km.MOTA = txtMoTa.Text;


            if (rdbThucHien.Checked)
            {
                km.TRANGTHAI = true;
            }
            else
            {
                km.TRANGTHAI = false;
            }


            if (mCmbHTKM.Text == "TANG_KEM")
            {
                km.MAHTTK = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }
            else if (mCmbHTKM.Text == "GIAM_GIA")
            {
                km.MAHTGG = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }
            else if (mCmbHTKM.Text == "VOUCHER")
            {
                km.MAHTVC = Convert.ToInt32(mCmbTenHTKM.SelectedValue);
            }


            //Gọi phương thức cập nhật dữ liệu truyền vào đối tượng
            KHUYENMAI_DTO kmDTOUpdate = KHUYENMAI_BLL.SuaKhuyenMai(km);


            if (kmDTOUpdate == null)
            {
                MessageBox.Show("Mã khuyến mãi không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            //Xử lý cập nhật trên giao diện datagridview
            //Lấy ra khuyến mãi  được chọn trên lstKhuyenMaiDTO
            KHUYENMAI_DTO kmDTO = lstKhuyenMaiDTO.Single(n => n.MAKM == km.MAKM);
            kmDTO.TENKM = kmDTOUpdate.TENKM;
            kmDTO.MALKH = kmDTOUpdate.MALKH;
            kmDTO.TENLKH = kmDTOUpdate.TENLKH;
            kmDTO.MALSP = kmDTOUpdate.MALSP;
            kmDTO.TENLSP = kmDTOUpdate.TENLSP;
            kmDTO.MAHTTK = kmDTOUpdate.MAHTTK;
            kmDTO.MAHTGG = kmDTOUpdate.MAHTGG;
            kmDTO.MAHTVC = kmDTOUpdate.MAHTVC;
            kmDTO.TENHT = kmDTOUpdate.TENHT;
            kmDTO.NGAYBATDAU = kmDTOUpdate.NGAYBATDAU;
            kmDTO.NGAYKETTHUC = kmDTOUpdate.NGAYKETTHUC;
            kmDTO.MOTA = kmDTOUpdate.MOTA;
            kmDTO.TRANGTHAI = kmDTOUpdate.TRANGTHAI;
            LoadDGVKhuyenMai();
            MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (mLblMaKM.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn 1 khuyến mãi cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Xử lý xóa database
            int maKM = Convert.ToInt32(mLblMaKM.Text);
            if (KHUYENMAI_BLL.XoaKhuyenMai(maKM) == true)
            {
                //Xử lý xóa trên giao diện
                //Xóa phần tử trên lstKhuyenMaiDTO
                KHUYENMAI_DTO kmDTO = lstKhuyenMaiDTO.Single(n => n.MAKM == maKM);
                lstKhuyenMaiDTO.Remove(kmDTO);//remove phần được chọn từ lstKhuyenMaiDTO
                LoadDGVKhuyenMai();
                MessageBox.Show("Xóa khuyến mãi thành công !", "Thông báo");
                return;
            }
            MessageBox.Show("Xóa khuyến mãi không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetDoRongCot()
        {
            mDgvChuongTrinhKhuyenMai.Columns[0].Visible = false;
            //mDgvChuongTrinhKhuyenMai.Columns[0].Visible = true;
            mDgvChuongTrinhKhuyenMai.Columns[1].Width = 150;
            mDgvChuongTrinhKhuyenMai.Columns[2].Visible = false;
            mDgvChuongTrinhKhuyenMai.Columns[3].Visible = false;
            mDgvChuongTrinhKhuyenMai.Columns[4].Visible = false;
            mDgvChuongTrinhKhuyenMai.Columns[5].Visible = false;
            mDgvChuongTrinhKhuyenMai.Columns[6].Visible = false;
            //mDgvChuongTrinhKhuyenMai.Columns[2].Visible = true;
            //mDgvChuongTrinhKhuyenMai.Columns[3].Visible = true;
            //mDgvChuongTrinhKhuyenMai.Columns[4].Visible = true;
            //mDgvChuongTrinhKhuyenMai.Columns[5].Visible = true;
            mDgvChuongTrinhKhuyenMai.Columns[6].Width = 130;
            mDgvChuongTrinhKhuyenMai.Columns[7].Width = 120;
            mDgvChuongTrinhKhuyenMai.Columns[8].Width = 125;
            mDgvChuongTrinhKhuyenMai.Columns[9].Width = 125;
            mDgvChuongTrinhKhuyenMai.Columns[10].Width = 110;
            mDgvChuongTrinhKhuyenMai.Columns[11].Width = 110;

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
