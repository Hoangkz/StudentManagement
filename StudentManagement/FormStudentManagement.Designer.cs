
namespace StudentManagement
{
    partial class FormStudentManagement
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trangChuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taikhoanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoVienToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lopHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chucNangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangkymonhocClassHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangKyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiemThanhPhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiemThiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCuuDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSachTaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 28);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 422);
            this.pnlContent.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongToolStripMenuItem,
            this.quanLyToolStripMenuItem,
            this.chucNangToolStripMenuItem,
            this.danhSachTaiKhoanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChuToolStripMenuItem,
            this.taikhoanToolStripMenuItem1,
            this.thoatToolStripMenuItem});
            this.heThongToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.heThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // trangChuToolStripMenuItem
            // 
            this.trangChuToolStripMenuItem.Name = "trangChuToolStripMenuItem";
            this.trangChuToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.trangChuToolStripMenuItem.Text = "Trang chủ";
            this.trangChuToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // taikhoanToolStripMenuItem1
            // 
            this.taikhoanToolStripMenuItem1.Name = "taikhoanToolStripMenuItem1";
            this.taikhoanToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.taikhoanToolStripMenuItem1.Text = "Tài khoản";
            this.taikhoanToolStripMenuItem1.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem1_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.thoatToolStripMenuItem.Text = "Đăng xuất";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // quanLyToolStripMenuItem
            // 
            this.quanLyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myClassToolStripMenuItem,
            this.sinhVienToolStripMenuItem,
            this.monHocToolStripMenuItem,
            this.giaoVienToolStripMenuItem1,
            this.lopHocToolStripMenuItem});
            this.quanLyToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            this.quanLyToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.quanLyToolStripMenuItem.Text = "Quản lý";
            // 
            // myClassToolStripMenuItem
            // 
            this.myClassToolStripMenuItem.Name = "myClassToolStripMenuItem";
            this.myClassToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.myClassToolStripMenuItem.Text = "Lớp học của tôi";
            this.myClassToolStripMenuItem.Click += new System.EventHandler(this.lớpHọcCủaTôiToolStripMenuItem_Click);
            // 
            // sinhVienToolStripMenuItem
            // 
            this.sinhVienToolStripMenuItem.Name = "sinhVienToolStripMenuItem";
            this.sinhVienToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sinhVienToolStripMenuItem.Text = "Sinh viên";
            this.sinhVienToolStripMenuItem.Click += new System.EventHandler(this.sinhVienToolStripMenuItem_Click);
            // 
            // monHocToolStripMenuItem
            // 
            this.monHocToolStripMenuItem.Name = "monHocToolStripMenuItem";
            this.monHocToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.monHocToolStripMenuItem.Text = "Môn học";
            this.monHocToolStripMenuItem.Click += new System.EventHandler(this.monHocToolStripMenuItem_Click);
            // 
            // giaoVienToolStripMenuItem1
            // 
            this.giaoVienToolStripMenuItem1.Name = "giaoVienToolStripMenuItem1";
            this.giaoVienToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.giaoVienToolStripMenuItem1.Text = "Giáo viên";
            this.giaoVienToolStripMenuItem1.Click += new System.EventHandler(this.giaoVienToolStripMenuItem1_Click);
            // 
            // lopHocToolStripMenuItem
            // 
            this.lopHocToolStripMenuItem.Name = "lopHocToolStripMenuItem";
            this.lopHocToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lopHocToolStripMenuItem.Text = "Lớp học";
            this.lopHocToolStripMenuItem.Click += new System.EventHandler(this.lopHocToolStripMenuItem_Click);
            // 
            // chucNangToolStripMenuItem
            // 
            this.chucNangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangkymonhocClassHọcToolStripMenuItem,
            this.dangKyToolStripMenuItem,
            this.DiemThanhPhanToolStripMenuItem,
            this.DiemThiToolStripMenuItem,
            this.traCuuDiemToolStripMenuItem});
            this.chucNangToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.chucNangToolStripMenuItem.Name = "chucNangToolStripMenuItem";
            this.chucNangToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.chucNangToolStripMenuItem.Text = "Chức năng";
            // 
            // dangkymonhocClassHọcToolStripMenuItem
            // 
            this.dangkymonhocClassHọcToolStripMenuItem.Name = "dangkymonhocClassHọcToolStripMenuItem";
            this.dangkymonhocClassHọcToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.dangkymonhocClassHọcToolStripMenuItem.Text = "Đăng ký môn học cho lớp";
            this.dangkymonhocClassHọcToolStripMenuItem.Click += new System.EventHandler(this.đăngKýMônHọcToolStripMenuItem_Click);
            // 
            // dangKyToolStripMenuItem
            // 
            this.dangKyToolStripMenuItem.Name = "dangKyToolStripMenuItem";
            this.dangKyToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.dangKyToolStripMenuItem.Text = "Đăng ký môn học";
            this.dangKyToolStripMenuItem.Click += new System.EventHandler(this.dangKyToolStripMenuItem_Click);
            // 
            // DiemThanhPhanToolStripMenuItem
            // 
            this.DiemThanhPhanToolStripMenuItem.Name = "DiemThanhPhanToolStripMenuItem";
            this.DiemThanhPhanToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.DiemThanhPhanToolStripMenuItem.Text = "Nhập điểm thành phần";
            this.DiemThanhPhanToolStripMenuItem.Click += new System.EventHandler(this.DiemThanhPhanToolStripMenuItem_Click);
            // 
            // DiemThiToolStripMenuItem
            // 
            this.DiemThiToolStripMenuItem.Name = "DiemThiToolStripMenuItem";
            this.DiemThiToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.DiemThiToolStripMenuItem.Text = "Nhập điểm thi";
            this.DiemThiToolStripMenuItem.Click += new System.EventHandler(this.DiemThiToolStripMenuItem_Click);
            // 
            // traCuuDiemToolStripMenuItem
            // 
            this.traCuuDiemToolStripMenuItem.Name = "traCuuDiemToolStripMenuItem";
            this.traCuuDiemToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.traCuuDiemToolStripMenuItem.Text = "Tra cứu điểm";
            this.traCuuDiemToolStripMenuItem.Click += new System.EventHandler(this.traCuuDiemToolStripMenuItem_Click);
            // 
            // danhSachTaiKhoanToolStripMenuItem
            // 
            this.danhSachTaiKhoanToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.danhSachTaiKhoanToolStripMenuItem.Name = "danhSachTaiKhoanToolStripMenuItem";
            this.danhSachTaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.danhSachTaiKhoanToolStripMenuItem.Text = "Danh sách tài khoản";
            this.danhSachTaiKhoanToolStripMenuItem.Click += new System.EventHandler(this.danhSáchTàiKhoảnToolStripMenuItem_Click);
            // 
            // FormStudentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormStudentManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý sinh viên";
            this.Load += new System.EventHandler(this.FormStudentManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giaoVienToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lopHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chucNangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangKyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCuuDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taikhoanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhSachTaiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trangChuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangkymonhocClassHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiemThanhPhanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiemThiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myClassToolStripMenuItem;
    }
}