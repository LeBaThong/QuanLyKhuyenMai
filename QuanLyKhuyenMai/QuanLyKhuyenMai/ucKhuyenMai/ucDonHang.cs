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

        static List<DONHANG_DTO> lstDH_DTO = new List<DONHANG_DTO>();
        static List<SANPHAM_DTO> lsSanPhamDonHang = new List<SANPHAM_DTO>();
        KHUYENMAI kmDH = new KHUYENMAI();
        int soTienVC = 0;
        bool coKM = false;



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
            //load phuong thuc thanh toan
            mCmbPTTT.DataSource = PHUONGTHUCTHANHTOAN_BLL.LoadPTTT();


        }

        //Load sản phẩm khi chọn loại sản phẩm
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
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
            }
            if (numSL.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng", "Thông báo");
                return;
            }
            DateTime NgayTaoDH = dtpNgayTaoDH.Value;
            DateTime NgayBatDauKM;
            DateTime NgayKetThucKM;

            // lấykhuyến mãi cuối cùng
            KHUYENMAI km = KHUYENMAI_BLL.TimKhuyenMaiMax();

            //Lấy ngày bắt đầu và ngày kết thúc khuyến mãi
            NgayBatDauKM = Convert.ToDateTime(km.NGAYBATDAU);
            NgayKetThucKM = Convert.ToDateTime(km.NGAYKETTHUC);

            //so sánh ngày tạo đơn hàng với ngày bắt đầu và ngày kêt thúc
            int a = DateTime.Compare(NgayBatDauKM, NgayTaoDH);
            int b = DateTime.Compare(NgayKetThucKM, NgayTaoDH);

            //Tìm khách hàng
            int maKH = Convert.ToInt32(txtMaKH.Text.Trim());
            KHACHHANG kh = KHACHHANG_BLL.TimKhachHang(maKH);

            //Xử lý thêm sản phẩm
            int masp = Convert.ToInt32(mCmbSanPham.SelectedValue);
            SANPHAM sp = SANPHAM_BLL.TimSanPham(masp);



            if (a <= 0 && b >= 0)//kiểm tra ngày tạo đơn hàng có nằm trong ngày khuyến mãi
            {
                if (kh != null && kh.MALKH == km.MALKH)//kiem3 tra khách hàng có được khuyến mãi
                {
                    if (sp.MALSP == km.MALSP)//kiểm tra sản phẩm đươc thêm vào có thuộc loại sản phẩm được km
                    {
                        kmDH = KHUYENMAI_BLL.TimKhuyenMai(km.MAKM);
                        if (TimSPtrongList(masp) == true)//kiểm tra xem sản phẩm có trong list sản phẩm không
                        {

                            if (km.MAHTGG != null)//nếu dúng thì xử lý khuyến mãi giảm giá
                            {
                                SANPHAM_DTO spDTOupdate = lsSanPhamDonHang.SingleOrDefault(n => n.MASP == masp);
                                spDTOupdate.SOLUONG += Convert.ToInt32(numSL.Value);
                                int phantramGG = km.HINHTHUCGIAMGIA.GIAMGIA.Value;
                                float gia = (float)sp.GIABAN;
                                int sl = (int)numSL.Value;
                                spDTOupdate.GIA += sl * (gia - gia * ((float)phantramGG / 100));

                                MessageBox.Show("Sản phẩm được khuyến mãi giảm giá " + spDTOupdate.GIA + " nghìn đồng", "Thông báo");
                                coKM = true;
                            }
                            else if (km.MAHTTK != null)//nếu đúng thì xử lý khuyến mãi tặng kèm
                            {
                                HINHTHUCTANGKEM httk = HINHTHUCTANGKEM_BLL.TimHTTK((int)km.MAHTTK);
                                if (km.HINHTHUCTANGKEM.MASP != null) //trường hợp khuyến mãi tặng 1 sản phẩm cụ thể
                                {
                                    SANPHAM_DTO sptk = TimSanPhamTK((int)km.HINHTHUCTANGKEM.MASP);
                                    SANPHAM_DTO spUpdate = TimSanPhamDuocKMTK(masp);
                                    spUpdate.SOLUONG += (int)numSL.Value;
                                    spUpdate.GIA += (float)sp.GIABAN * (int)numSL.Value;
                                    sptk.SOLUONG += (int)numSL.Value;
                                }
                                else//trường hợp mua 2 tặng 1
                                {
                                    SANPHAM_DTO sptk = TimSanPhamTK(masp);
                                    SANPHAM_DTO spUpdate = TimSanPhamDuocKMTK(masp);
                                    spUpdate.SOLUONG += (int)numSL.Value;
                                    spUpdate.GIA += (float)sp.GIABAN * (int)numSL.Value;
                                    sptk.SOLUONG += (int)numSL.Value;

                                }
                                coKM = true;
                            }
                            else if (km.MAHTVC != null)//xử lý khuyến mãi voucher
                            {

                                SANPHAM_DTO spDTOupdate = lsSanPhamDonHang.SingleOrDefault(n => n.MASP == masp);
                                spDTOupdate.SOLUONG += Convert.ToInt32(numSL.Value);

                                float gia = (float)sp.GIABAN;
                                int sl = (int)numSL.Value;
                                spDTOupdate.GIA += sl * gia;
                                if (txtVoucher.Text == "")
                                {
                                    MessageBox.Show("Đơn hàng được khuyến mãi voucher vui lòng nhập mã voucher", "Thông báo");
                                }


                                coKM = true;
                            }

                        }
                        else//sản phẩm vẫn chưa được thêm vào list sản phẩm của đơn hàng
                        {
                            SANPHAM_DTO spDTO = new SANPHAM_DTO();
                            spDTO.MASP = sp.MASP;
                            spDTO.TENSP = sp.TENSP;
                            spDTO.SOLUONG = Convert.ToInt32(numSL.Value);
                            spDTO.MALSP = sp.MALSP;
                            spDTO.TENLSP = sp.LOAISANPHAM.TENLSP;

                            if (km.MAHTGG != null) //lấy phần trăm khuyến mãi và xử lý giảm trên môi sản phẩm
                            {
                                int phantramGG = km.HINHTHUCGIAMGIA.GIAMGIA.Value;
                                float gia = (float)sp.GIABAN;
                                int sl = (int)numSL.Value;
                                spDTO.GIA = sl * (gia - gia * ((float)phantramGG / 100));

                                MessageBox.Show("Sản phẩm được khuyến mãi giảm giá", "Thông báo");
                                coKM = true;
                            }
                            else if (km.MAHTVC != null)
                            {

                                float gia = (float)sp.GIABAN;
                                int sl = (int)numSL.Value;
                                spDTO.GIA = sl * gia;
                                if (txtVoucher.Text == "")
                                {
                                    MessageBox.Show("Đơn hàng được khuyến mãi voucher vui lòng nhập mã voucher", "Thông báo");
                                }

                                coKM = true;
                            }
                            else if (km.MAHTTK != null)//xử lý theo khuyến mãi tặng kèm
                            {
                                if (km.HINHTHUCTANGKEM.MASP != null)//tặng kèm một sản phẩm cụ thể
                                {
                                    SANPHAM spTK = new SANPHAM();
                                    if (TimSanPhamTKTRueFALSE((int)km.HINHTHUCTANGKEM.MASP) == false)
                                    {
                                        //lấy mã của sản phẩm tặng kèm
                                        int msp = (int)km.HINHTHUCTANGKEM.MASP;
                                        //lấy sản phẩm tặng kèm trong SANPHAM
                                        spTK = SANPHAM_BLL.TimSanPham(msp);

                                        //tính giá bán của sản phẩm thêm vào
                                        spDTO.GIA = (float)sp.GIABAN;

                                        //lấy số lượng của sản phẩm tặng kèm
                                        int sl = (int)numSL.Value;


                                        //gán sản phẩm tặng kèm cho sp tặng kèm DTO
                                        SANPHAM_DTO spDTOTK = new SANPHAM_DTO();
                                        spDTOTK.MASP = spTK.MASP;
                                        spDTOTK.TENSP = spTK.TENSP;
                                        spDTOTK.SOLUONG = sl;
                                        spDTOTK.MALSP = spTK.MALSP;
                                        spDTOTK.TENLSP = spTK.LOAISANPHAM.TENLSP;
                                        spDTOTK.GIA = 0;
                                        MessageBox.Show("Sản phẩm được khuyến mãi tặng kèm " + spTK.TENSP, "Thông báo");
                                        lsSanPhamDonHang.Add(spDTOTK);

                                    }
                                    else//tặng kèm mua 2 tính tiền 1
                                    {
                                        SANPHAM_DTO sptkupdate = TimSanPhamTK((int)km.HINHTHUCTANGKEM.MASP);
                                        sptkupdate.SOLUONG += (int)numSL.Value;
                                        spDTO.GIA = (float)sp.GIABAN * (int)numSL.Value;
                                        MessageBox.Show("Sản phẩm được khuyến mãi tặng kèm " + spTK.TENSP, "Thông báo");

                                    }

                                }
                                if (km.HINHTHUCTANGKEM.MASP == null)
                                {

                                    MessageBox.Show("Sản phẩm được khuyến mãi tặng thêm 1 sản phẩm", "Thông báo");
                                    //tính giá bán của sản phẩm thêm vào
                                    spDTO.GIA = (float)sp.GIABAN;
                                    int sl = (int)km.HINHTHUCTANGKEM.SOLUONG;

                                    SANPHAM_DTO spDTOTK = new SANPHAM_DTO();
                                    spDTOTK.MASP = sp.MASP;
                                    spDTOTK.TENSP = sp.TENSP;
                                    spDTOTK.SOLUONG = sl;
                                    spDTOTK.MALSP = sp.MALSP;
                                    spDTOTK.TENLSP = sp.LOAISANPHAM.TENLSP;
                                    spDTOTK.GIA = 0;
                                    lsSanPhamDonHang.Add(spDTOTK);
                                }
                                coKM = true;
                            }
                            lsSanPhamDonHang.Add(spDTO);
                        }
                    }

                }

            }
            //Sản phẩm không thuộc chương trình khuyến mãi
            if ((sp.MALSP != km.MALSP) || kh.MALKH != km.MALKH || a > 0 || b < 0)
            {
                if (TimSPtrongList(masp) == true)//Sản phẩm đã tồn tại trong list sản phẩm
                {
                    SANPHAM_DTO spDTOupdate = lsSanPhamDonHang.Single(n => n.MASP == masp);
                    spDTOupdate.SOLUONG += Convert.ToInt32(numSL.Value);
                    spDTOupdate.GIA += Convert.ToInt32(numSL.Value) * (float)sp.GIABAN;
                }
                else//sản phẩm vẫn chưa được thêm vào list sản phẩm
                {
                    SANPHAM_DTO spDTO = new SANPHAM_DTO();
                    spDTO.MASP = sp.MASP;
                    spDTO.TENSP = sp.TENSP;
                    spDTO.SOLUONG = Convert.ToInt32(numSL.Value);
                    spDTO.GIA = Convert.ToInt32(numSL.Value) * (float)sp.GIABAN;
                    spDTO.MALSP = sp.MALSP;
                    spDTO.TENLSP = sp.LOAISANPHAM.TENLSP;
                    coKM = false;
                    lsSanPhamDonHang.Add(spDTO);
                }

            }
            LoadSP_DH();
        }
        public static SANPHAM_DTO TimSanPhamTK(int masptk)
        {
            SANPHAM_DTO sptk = new SANPHAM_DTO();
            foreach (var item in lsSanPhamDonHang)
            {
                if (item.MASP == masptk && item.GIA == 0)
                {
                    sptk = item;
                }
            }
            return sptk;
        }

        //Tìm sản phẩm tk vào trả về true false
        public bool TimSanPhamTKTRueFALSE(int masptk)
        {
            SANPHAM_DTO sptk = new SANPHAM_DTO();
            foreach (var item in lsSanPhamDonHang)
            {
                if (item.MASP == masptk && item.GIA == 0)
                {
                    sptk = item;
                    return true;
                }
            }
            return false;

        }
        //Tìm sản phẩm được khuyến mãi trong list sản phẩm và tả về sản phẩm
        public static SANPHAM_DTO TimSanPhamDuocKMTK(int maspdtk)
        {
            SANPHAM_DTO spdtk = new SANPHAM_DTO();
            foreach (SANPHAM_DTO item in lsSanPhamDonHang)
            {
                if (item.MASP == maspdtk && item.GIA > 0)
                {
                    spdtk = item;
                }
            }
            return spdtk;
        }
        //Tìm sp được thêm vào  trong list sp 
        public bool TimSPtrongList(int masp)
        {
            if (lsSanPhamDonHang.Count > 0)
            {
                foreach (var item in lsSanPhamDonHang)
                {
                    if (item.MASP == masp)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //load sản phẩm trên đơn hàng
        public void LoadSP_DH()
        {
            dgvSP_DH.DataSource = typeof(List<SANPHAM_DTO>);
            dgvSP_DH.DataSource = lsSanPhamDonHang;
        }
        //load đơn hàng
        public void LoadDH()
        {
            mDgvDonHang.DataSource = typeof(List<DONHANG_DTO>);
            mDgvDonHang.DataSource = lstDH_DTO;
        }

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            //lấy đối tượng khách hàng
            KHACHHANG kh = KHACHHANG_BLL.TimKhachHang(Convert.ToInt32(txtMaKH.Text));
            //tạo đơn hàng từ giao diện
            DONHANG dh = new DONHANG();
            dh.MAKH = kh.MAKH;

            dh.NGAYTAO = dtpNgayTaoDH.Value;

            //Lấy tổng số lượng trên list sản phẩm
            int sl = 0;
            foreach (var item in lsSanPhamDonHang)
            {

                sl += item.SOLUONG;

            }
            dh.SOLUONG = sl;
            dh.PHUONGTHUCTT = mCmbPTTT.Text;
            if (coKM == true)
            {
                dh.COKM = true;

            }
            else
            {
                dh.COKM = false;
            }
            //gán mã khuyến mãi cho đơn hàng
            if (kmDH != null)
            {
                dh.MAKM = kmDH.MAKM;
            }
            if (rdbHoanThanh.Checked)
            {
                dh.TRANGTHAI = true;
            }
            else
            {
                dh.TRANGTHAI = false;
            }
            //lấy số tiền giam của voucher
            if (txtVoucher.Text != "")
            {
                HINHTHUCVOUCHER htvc = HINHTHUCVOUCHER_BLL.TimHinhThucVoucher(Convert.ToInt32(txtVoucher.Text.Trim()));
                soTienVC = (int)htvc.TIENGIAM;
            }
            //cập nhật đơn hàng thành đơn hàng DTO
            DONHANG dhAdded = DONHANG_BLL.ThemDonHang(dh);
            if (dhAdded != null)
            {
                DONHANG_DTO dhDTO = CapNhatDHThanhDHDTO(dh);
                lstDH_DTO.Add(dhDTO);
            }

            //Lưu chi tiết đơn hàng với giá một sản phẩm và số lượng
            CHITIETDONHANG ctdh = new CHITIETDONHANG();
            bool i;
            foreach (var item in lsSanPhamDonHang)
            {
                ctdh.MADH = dh.MADH;
                ctdh.MASP = item.MASP;
                ctdh.GIA = item.GIA / item.SOLUONG;
                ctdh.SOLUONG = item.SOLUONG;
                i = CHITIETDONHANG_BLL.ThemChiTietDonHang(ctdh);
            }
            //kiểm tra nếu thêm chi tiết đơn hàng thành công và list đơn hàng khác null thì load lại đơn hàng
            if (i = true && lstDH_DTO != null)
            {
                LoadDH();
                LoadSP_DH();
                MessageBox.Show("Thêm đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Cập nhật đơn hàng thành đơn hàng DTO để lưu vào list hiển thị lên màn hình
        public DONHANG_DTO CapNhatDHThanhDHDTO(DONHANG dh)
        {
            DONHANG_DTO dhDTO = new DONHANG_DTO();
            dhDTO.MADH = dh.MADH;
            dhDTO.NGAYTAO = dh.NGAYTAO;
            dhDTO.PHUONGTHUCTT = dh.PHUONGTHUCTT;
            dhDTO.SOLUONG = dh.SOLUONG;
            dhDTO.TRANGTHAI = dh.TRANGTHAI;
            dhDTO.MAKH = dh.MAKH;
            dhDTO.TENKH = dh.KHACHHANG.TENKH;
            dhDTO.COKM = dh.COKM;
            if (kmDH != null)
            {
                dhDTO.MAKM = dh.MAKM;
                dhDTO.TENKM = dh.KHUYENMAI.TENKM;
            }
            //tính tổng thành tiền
            double tt = 0;
            foreach (var item in lsSanPhamDonHang)
            {
                tt += item.GIA;
            }
            //nếu khuyến mãi voucher được áp dụng thì sotienvc !=0
            if (soTienVC != 0)
            {
                dhDTO.THANHTIEN = tt - soTienVC;  
                MessageBox.Show("Đơn hàng được giảm giá voucher " + soTienVC +" đồng");
            }
            else
            {
                dhDTO.THANHTIEN = tt;
            }

            return dhDTO;
        }
        //thông tin sẽ hiển thị lên control khi click vào đơn hàng
        private void mDgvDonHang_Click(object sender, EventArgs e)
        {
            if (mDgvDonHang.SelectedRows != null)
            {
                //Lấy ra dòng được chọn gán vào các control phía trên
                DataGridViewRow dr = mDgvDonHang.SelectedRows[0];
                txtMaKH.Text = dr.Cells["MAKH"].Value.ToString();
                dtpNgayTaoDH.Value = (DateTime)dr.Cells["NGAYTAO"].Value;
                mCmbPTTT.Text = dr.Cells["PHUONGTHUCTT"].Value.ToString();
                if (txtVoucher.Text != "")
                {

                }
                if ((bool)dr.Cells["TRANGTHAI"].Value == true)
                {
                    rdbHoanThanh.Checked = true;
                }
                else
                {
                    rdbDangCho.Checked = true;
                }
            }
        }
        //khi click vào sản phẩm sản phẩm sẽ hiển thị lên các control
        private void dgvSP_DH_Click(object sender, EventArgs e)
        {
            if (dgvSP_DH.SelectedRows != null)
            {
                DataGridViewRow dr = dgvSP_DH.SelectedRows[0];
                mCmbLoaiSanPham.SelectedValue = dr.Cells["MALSP"].Value;
                mCmbSanPham.SelectedValue = dr.Cells["MASP"].Value;
                numSL.Value = (int)dr.Cells["SOLUONG"].Value;
            }
        }


        //Xóa sản phẩm trên đơn hàng
        private void mbtnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr;
            if (dgvSP_DH.SelectedRows.Count > 0)
            {
                dr = dgvSP_DH.SelectedRows[0];
                int maSP = (int)dr.Cells["MASP"].Value;
                SANPHAM_DTO spDTO = lsSanPhamDonHang.Single(n => n.MASP == maSP);
                lsSanPhamDonHang.Remove(spDTO);
                LoadSP_DH();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa", "Thông báo");
            }
        }
        //Xóa đơn hàng
        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn đơn hàng cần xóa !", "Thông báo");
                return;
            }
            if (mDgvDonHang.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = mDgvDonHang.SelectedRows[0];
                int madh = (int)dr.Cells["MADH"].Value;
                //Xử lý xóa database             
                if (CHITIETDONHANG_BLL.XoaChiTietDonHang(madh) == true && DONHANG_BLL.XoaDonHang(madh) == true)
                {
                    //Xóa trên list đơn hàng
                    DONHANG_DTO dhDTO = lstDH_DTO.Single(n => n.MADH == madh);
                    lstDH_DTO.Remove(dhDTO);
                    LoadDH();
                    MessageBox.Show("Xóa thành công !", "Thông báo");
                    return;
                }
                MessageBox.Show("Xóa không thành công !", "Thông báo");
            }
        }
        // làm mới đơn hàng
        private void metroButton4_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtVoucher.Text = "";
            mCmbPTTT.DataSource = PHUONGTHUCTHANHTOAN_BLL.LoadPTTT();
            int n = lsSanPhamDonHang.Count();
            foreach (var item in lsSanPhamDonHang.ToList())
            {
                lsSanPhamDonHang.Remove(item);
            }
            foreach (var item in lstDH_DTO.ToList())
            {
                lstDH_DTO.Remove(item);
            }

            LoadDH();
            LoadSP_DH();
            numSL.Value = 0;
            kmDH = null;
            soTienVC = 0;
            coKM = false;
        }
    }
}
