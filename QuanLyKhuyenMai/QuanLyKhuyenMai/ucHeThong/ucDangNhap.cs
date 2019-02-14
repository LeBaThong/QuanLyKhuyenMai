using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuyenMai.ucHeThong
{
    public partial class ucDangNhap : UserControl
    {
        public ucDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ucManHinhChinh ucManHinhChinh = new ucManHinhChinh();
            ucManHinhChinh.Dock = DockStyle.Fill;
            //Add ucManHinhChinh vào panel chính của frm
            FormMain.FrmMain.MetroContainer.Controls.Add(ucManHinhChinh);
            FormMain.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
            //Duyệt để xóa chỉ định phần tử trong FormChinh
            foreach (ucDangNhap uc in FormMain.FrmMain.MetroContainer.Controls.OfType<ucDangNhap>())
            {
                FormMain.FrmMain.MetroContainer.Controls.Remove(uc);
            }
        }
    }
}
