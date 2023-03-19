
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
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoVienToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lopHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chucNangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangKyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCuuDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 30);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 420);
            this.pnlContent.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quanLyToolStripMenuItem,
            this.chucNangToolStripMenuItem,
            this.danhSáchTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem1,
            this.thoatToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 26);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // tàiKhoảnToolStripMenuItem1
            // 
            this.tàiKhoảnToolStripMenuItem1.Name = "tàiKhoảnToolStripMenuItem1";
            this.tàiKhoảnToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.tàiKhoảnToolStripMenuItem1.Text = "Tài khoản";
            this.tàiKhoảnToolStripMenuItem1.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem1_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.thoatToolStripMenuItem.Text = "Đăng xuất";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // quanLyToolStripMenuItem
            // 
            this.quanLyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinhVienToolStripMenuItem,
            this.monHocToolStripMenuItem,
            this.giaoVienToolStripMenuItem1,
            this.lopHocToolStripMenuItem});
            this.quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            this.quanLyToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.quanLyToolStripMenuItem.Text = "Quản lý";
            // 
            // sinhVienToolStripMenuItem
            // 
            this.sinhVienToolStripMenuItem.Name = "sinhVienToolStripMenuItem";
            this.sinhVienToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sinhVienToolStripMenuItem.Text = "Sinh viên";
            // 
            // monHocToolStripMenuItem
            // 
            this.monHocToolStripMenuItem.Name = "monHocToolStripMenuItem";
            this.monHocToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.monHocToolStripMenuItem.Text = "Môn học";
            // 
            // giaoVienToolStripMenuItem1
            // 
            this.giaoVienToolStripMenuItem1.Name = "giaoVienToolStripMenuItem1";
            this.giaoVienToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.giaoVienToolStripMenuItem1.Text = "Giáo viên";
            // 
            // lopHocToolStripMenuItem
            // 
            this.lopHocToolStripMenuItem.Name = "lopHocToolStripMenuItem";
            this.lopHocToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lopHocToolStripMenuItem.Text = "Lớp học";
            // 
            // chucNangToolStripMenuItem
            // 
            this.chucNangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangKyToolStripMenuItem,
            this.traCuuDiemToolStripMenuItem});
            this.chucNangToolStripMenuItem.Name = "chucNangToolStripMenuItem";
            this.chucNangToolStripMenuItem.Size = new System.Drawing.Size(93, 26);
            this.chucNangToolStripMenuItem.Text = "Chức năng";
            // 
            // dangKyToolStripMenuItem
            // 
            this.dangKyToolStripMenuItem.Name = "dangKyToolStripMenuItem";
            this.dangKyToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.dangKyToolStripMenuItem.Text = "Đăng ký môn học";
            // 
            // traCuuDiemToolStripMenuItem
            // 
            this.traCuuDiemToolStripMenuItem.Name = "traCuuDiemToolStripMenuItem";
            this.traCuuDiemToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.traCuuDiemToolStripMenuItem.Text = "Tra cứu điểm";
            // 
            // danhSáchTàiKhoảnToolStripMenuItem
            // 
            this.danhSáchTàiKhoảnToolStripMenuItem.Name = "danhSáchTàiKhoảnToolStripMenuItem";
            this.danhSáchTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.danhSáchTàiKhoảnToolStripMenuItem.Text = "Danh sách tài khoản";
            this.danhSáchTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.danhSáchTàiKhoảnToolStripMenuItem_Click);
            // 
            // FormStudentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giaoVienToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lopHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chucNangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangKyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCuuDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchTàiKhoảnToolStripMenuItem;
    }
}