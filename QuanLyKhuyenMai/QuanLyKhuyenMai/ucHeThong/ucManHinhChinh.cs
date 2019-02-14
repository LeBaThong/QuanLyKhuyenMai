using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhuyenMai.ucKhuyenMai;

namespace QuanLyKhuyenMai.ucHeThong
{
    public partial class ucManHinhChinh : UserControl
    {
        public ucManHinhChinh()
        {
            InitializeComponent();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            templateKhuyenMai tmpKhuyenMai = new templateKhuyenMai();
            tmpKhuyenMai.Dock = DockStyle.Fill;

            FormMain.FrmMain.MetroContainer.Controls.Add(tmpKhuyenMai);
            FormMain.FrmMain.MetroContainer.Controls["templateKhuyenMai"].BringToFront();

            foreach (ucManHinhChinh uc in FormMain.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinh>())
            {
                FormMain.FrmMain.MetroContainer.Controls.Remove(uc);
            }
        }
    }
}
