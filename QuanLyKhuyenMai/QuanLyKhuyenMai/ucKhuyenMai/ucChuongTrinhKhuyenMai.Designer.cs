namespace QuanLyKhuyenMai.ucKhuyenMai
{
    partial class ucChuongTrinhKhuyenMai
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChuongTrinhKhuyenMai));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mPanelTieuDe = new MetroFramework.Controls.MetroPanel();
            this.mLblTieuDe = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.mPanelTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.mPanelTieuDe, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mPanelTieuDe
            // 
            this.mPanelTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.mPanelTieuDe.Controls.Add(this.mLblTieuDe);
            this.mPanelTieuDe.Controls.Add(this.pictureBox1);
            this.mPanelTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanelTieuDe.HorizontalScrollbarBarColor = true;
            this.mPanelTieuDe.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanelTieuDe.HorizontalScrollbarSize = 10;
            this.mPanelTieuDe.Location = new System.Drawing.Point(3, 3);
            this.mPanelTieuDe.Name = "mPanelTieuDe";
            this.mPanelTieuDe.Size = new System.Drawing.Size(914, 46);
            this.mPanelTieuDe.TabIndex = 0;
            this.mPanelTieuDe.UseCustomBackColor = true;
            this.mPanelTieuDe.VerticalScrollbarBarColor = true;
            this.mPanelTieuDe.VerticalScrollbarHighlightOnWheel = false;
            this.mPanelTieuDe.VerticalScrollbarSize = 10;
            // 
            // mLblTieuDe
            // 
            this.mLblTieuDe.AutoSize = true;
            this.mLblTieuDe.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLblTieuDe.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLblTieuDe.ForeColor = System.Drawing.Color.White;
            this.mLblTieuDe.Location = new System.Drawing.Point(56, 13);
            this.mLblTieuDe.Name = "mLblTieuDe";
            this.mLblTieuDe.Size = new System.Drawing.Size(213, 25);
            this.mLblTieuDe.TabIndex = 3;
            this.mLblTieuDe.Text = "Chương trình khuyến mãi";
            this.mLblTieuDe.UseCustomBackColor = true;
            this.mLblTieuDe.UseCustomForeColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ucChuongTrinhKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucChuongTrinhKhuyenMai";
            this.Size = new System.Drawing.Size(920, 524);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mPanelTieuDe.ResumeLayout(false);
            this.mPanelTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel mPanelTieuDe;
        private MetroFramework.Controls.MetroLabel mLblTieuDe;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
