using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormLogin : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username.Length>0 && password.Length>0)
            {
                var query = db.Account.Where(a => a.UserName == username && a.PassWord == password).FirstOrDefault();
                if (query != null)
                {
                    if (query.isUser)
                    {
                        string Role = query.Role.Replace(" ", "").ToLower();
                        if (Role == "admin")
                        {
                            textBox2.Text = "";
                            this.Hide();
                            FormStudentManagement st = new FormStudentManagement(query.Id);
                            st.ShowDialog();
                            this.Show();
                        }
                        else if(Role == "nhânviên")
                        {
                            string text = "Nhân viên " + query.UserName;
                            MessageBox.Show(text, "Thông báo");
                        }
                        else if (Role == "giảngviên")
                        {
                            string text = "Giảng viên: " + query.UserName;
                            MessageBox.Show(text, "Thông báo");
                        }
                        else if (Role == "sinhviên")
                        {
                            string text = "Sinh viên " + query.UserName;
                            MessageBox.Show(text, "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản của bạn chưa được cấp quyền truy cập", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản của bạn chưa được cấp quyền truy cập", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo");
                }

            }
            else
            {
               MessageBox.Show("Hãy nhập tên tài khoản và mật khẩu!","Thông báo");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
             if(MessageBox.Show("Bạn muốn thoát chương trình?","Thoát chương trình", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            this.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
