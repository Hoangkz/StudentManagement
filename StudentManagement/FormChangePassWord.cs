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
    public partial class FormChangePassWord : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        private int idUser;
        public FormChangePassWord(int id)
        {
            idUser = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string newPassword = textBox2.Text;
            string comfimPassword = textBox5.Text;
            if (newPassword != comfimPassword)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không giống nhau", "Thông báo");
            }
            else
            {
                var User = db.Account.Find(idUser);
                if(User.PassWord == password)
                {
                    User.PassWord = newPassword;
                    db.SaveChanges();
                    MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác", "Thông báo");
                }
            }
        }
    }
}
