using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using QuanLyKhuyenMai.ucHeThong;

namespace QuanLyKhuyenMai
{
    public partial class FormMain : MetroForm
    {
        private static FormMain _frmMain;
        public static FormMain FrmMain
        {
            get
            {
                if (_frmMain == null)
                    _frmMain = new FormMain();
                return _frmMain;
            }
        }
        public MetroPanel MetroContainer
        {
            get
            {
                return this.mPanelChinh;
            }
            set
            {
                this.mPanelChinh = value;
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Gán thuộc tính frm = chính nó
            _frmMain = this;
            //Khởi tạo ucDangNhap
            ucDangNhap ucDN = new ucDangNhap();
            ucDN.Dock = DockStyle.Fill;
            //Add ucDangNhap vào panelChinh từ frm
            _frmMain.MetroContainer.Controls.Add(ucDN);
            _frmMain.MetroContainer.Controls["ucDangNhap"].BringToFront();
        }
    }
}
