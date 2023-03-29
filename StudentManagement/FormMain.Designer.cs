
namespace StudentManagement
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttongiangvien = new System.Windows.Forms.Button();
            this.buttonlophoc = new System.Windows.Forms.Button();
            this.buttontaikhoan = new System.Windows.Forms.Button();
            this.buttonmonhoc = new System.Windows.Forms.Button();
            this.buttonsinhvien = new System.Windows.Forms.Button();
            this.buttondanhsachtaikhoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lý sinh viên";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhóm 5";
            // 
            // buttongiangvien
            // 
            this.buttongiangvien.Location = new System.Drawing.Point(141, 149);
            this.buttongiangvien.Name = "buttongiangvien";
            this.buttongiangvien.Size = new System.Drawing.Size(220, 58);
            this.buttongiangvien.TabIndex = 1;
            this.buttongiangvien.Text = "Quản lý giảng viên\r\n\r\nĐặng Ngọc Sang\r\n";
            this.buttongiangvien.UseVisualStyleBackColor = true;
            this.buttongiangvien.Click += new System.EventHandler(this.buttongiangvien_Click);
            // 
            // buttonlophoc
            // 
            this.buttonlophoc.Location = new System.Drawing.Point(141, 232);
            this.buttonlophoc.Name = "buttonlophoc";
            this.buttonlophoc.Size = new System.Drawing.Size(220, 58);
            this.buttonlophoc.TabIndex = 1;
            this.buttonlophoc.Text = "Quản lý lớp học\r\n\r\nPhạm Đức Hiệp\r\n";
            this.buttonlophoc.UseVisualStyleBackColor = true;
            this.buttonlophoc.Click += new System.EventHandler(this.buttonlophoc_Click);
            // 
            // buttontaikhoan
            // 
            this.buttontaikhoan.Location = new System.Drawing.Point(141, 312);
            this.buttontaikhoan.Name = "buttontaikhoan";
            this.buttontaikhoan.Size = new System.Drawing.Size(220, 58);
            this.buttontaikhoan.TabIndex = 1;
            this.buttontaikhoan.Text = "Tài Khoản";
            this.buttontaikhoan.UseVisualStyleBackColor = true;
            this.buttontaikhoan.Click += new System.EventHandler(this.buttontaikhoan_Click);
            // 
            // buttonmonhoc
            // 
            this.buttonmonhoc.Location = new System.Drawing.Point(447, 149);
            this.buttonmonhoc.Name = "buttonmonhoc";
            this.buttonmonhoc.Size = new System.Drawing.Size(220, 58);
            this.buttonmonhoc.TabIndex = 1;
            this.buttonmonhoc.Text = "Quản lý môn học\r\n\r\nNguyễn Đăng Khoa\r\n";
            this.buttonmonhoc.UseVisualStyleBackColor = true;
            this.buttonmonhoc.Click += new System.EventHandler(this.buttonmonhoc_Click);
            // 
            // buttonsinhvien
            // 
            this.buttonsinhvien.Location = new System.Drawing.Point(447, 232);
            this.buttonsinhvien.Name = "buttonsinhvien";
            this.buttonsinhvien.Size = new System.Drawing.Size(220, 58);
            this.buttonsinhvien.TabIndex = 1;
            this.buttonsinhvien.Text = "Quản lý sinh viên \r\n\r\nPhạm Thị Hương Trà";
            this.buttonsinhvien.UseVisualStyleBackColor = true;
            this.buttonsinhvien.Click += new System.EventHandler(this.buttonsinhvien_Click);
            // 
            // buttondanhsachtaikhoan
            // 
            this.buttondanhsachtaikhoan.Location = new System.Drawing.Point(447, 312);
            this.buttondanhsachtaikhoan.Name = "buttondanhsachtaikhoan";
            this.buttondanhsachtaikhoan.Size = new System.Drawing.Size(220, 58);
            this.buttondanhsachtaikhoan.TabIndex = 1;
            this.buttondanhsachtaikhoan.Text = "Danh sách tài khoản";
            this.buttondanhsachtaikhoan.UseVisualStyleBackColor = true;
            this.buttondanhsachtaikhoan.Click += new System.EventHandler(this.buttondanhsachtaikhoan_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 520);
            this.Controls.Add(this.buttondanhsachtaikhoan);
            this.Controls.Add(this.buttontaikhoan);
            this.Controls.Add(this.buttonsinhvien);
            this.Controls.Add(this.buttonmonhoc);
            this.Controls.Add(this.buttonlophoc);
            this.Controls.Add(this.buttongiangvien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "Hệ thống quản lý sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttongiangvien;
        private System.Windows.Forms.Button buttonlophoc;
        private System.Windows.Forms.Button buttontaikhoan;
        private System.Windows.Forms.Button buttonmonhoc;
        private System.Windows.Forms.Button buttonsinhvien;
        private System.Windows.Forms.Button buttondanhsachtaikhoan;
    }
}