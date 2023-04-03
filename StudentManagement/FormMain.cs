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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttongiangvien_Click(object sender, EventArgs e)
        {

        }

        private void buttonsinhvien_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của form muốn chuyển đến
            FormListStudent FormListStudent = new FormListStudent();

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
            //FormUser FormUser = new FormUser();
            // Hiển thị form
            //FormUser.Show();
            // Ẩn form hiện tại
            //this.Hide();
        }
    }
}
