using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagement
{
    public partial class FormMain : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();

        private int idUser;
        public FormMain(int id)
        {
            InitializeComponent();
            idUser = id;
        }

        private void buttongiangvien_Click(object sender, EventArgs e)
        {

        }

        private void buttonsinhvien_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            FormListStudent FormListStudent = new FormListStudent(2);

            // Hiển thị form
            FormListStudent.Show();

            // Ẩn form hiện tại
            //this.Hide();
        }

        private void buttondanhsachtaikhoan_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            FormListUsers FormListUsers = new FormListUsers();

            // Hiển thị form
            FormListUsers.Show();

            // Ẩn form hiện tại
            //this.Hide();
        }

        private void buttonmonhoc_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            //FormListSubject FormListSubject = new FormListSubject();
            // Hiển thị form
            //FormListSubject.Show();
            // Ẩn form hiện tại
            //this.Hide();
        }

        private void buttonlophoc_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            //FormListClassrom FormListClassrom = new FormListClassrom();
            // Hiển thị form
            //FormListClassrom.Show();
            // Ẩn form hiện tại
            //this.Hide();
        }

        private void buttontaikhoan_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            User FormUser = new User(2030);
            // Hiển thị form
            FormUser.Show();
            // Ẩn form hiện tại
            //this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //textBoxlop.Text = "ĐH10C3";
            var User = db.Account.Find(idUser);
            try
            {
                /*
                textBox2.Text = User.FullName;
                comboBox1.SelectedItem = User.Gender;
                textBox3.Text = User.Phone;
                textBox4.Text = User.Email;*/

                label11.Text = User.FullName;
                label12.Text = User.Gender;
                label13.Text = User.Phone;
                label14.Text = User.Email;
                DateTime dateTime = DateTime.ParseExact(User.DateOfBirth, "dd/MM/yyyy", null);
                dateTimePicker1.Value = dateTime;
            }
            catch
            {
            }
           
        }
    }
}
