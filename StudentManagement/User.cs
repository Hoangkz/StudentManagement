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
    public partial class User : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();

        private int idUser;
        public User(int id)
        {
            idUser = id;
            InitializeComponent();
            loadata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadata()
        {
            var User = db.Account.Find(idUser);
            try
            {
                textBox1.Text = User.UserName;
                textBox2.Text = User.FullName;
                comboBox1.SelectedItem = User.Gender;
                textBox3.Text = User.Phone;
                textBox4.Text = User.Email;
                DateTime dateTime = DateTime.ParseExact(User.DateOfBirth, "dd/MM/yyyy", null);
                dateTimePicker1.Value = dateTime;
            }
            catch
            {
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormChangePassWord formChangePassWord = new FormChangePassWord(idUser);
            formChangePassWord.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "Lưu")
            {
                try
                {
                    string FullName = textBox2.Text;
                    object Gender = comboBox1.SelectedItem;
                    
                    string Phone = textBox3.Text;
                    string Email = textBox4.Text;
                    string DateOfBirth = dateTimePicker1.Value.ToShortDateString();
                    var User = db.Account.Find(idUser);
                    User.FullName = FullName;
                    User.Gender = (string)Gender;
                    User.Phone = Phone;
                    User.Email = Email;
                    User.DateOfBirth = DateOfBirth;
                    db.SaveChanges();

                    button1.Text = "Cập nhật";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    comboBox1.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Lỗi server", "Thông báo");
                }
            }
            else if(button1.Text == "Cập nhật")
            {
                button1.Text = "Lưu";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Lỗi server", "Thông báo");
            }
        }
    }
}
