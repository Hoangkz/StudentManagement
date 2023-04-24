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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        StudentManagementEntities db = new StudentManagementEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fullname = textBox3.Text;
                string gender = comboBox2.Text;
                string dateOfbirth = dateTimePicker1.Value.ToShortDateString().ToString();
                string sothich = "";
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                {

                    if (checkBox1.Checked)
                    {
                        sothich = "Đọc sách";
                    }

                    if (checkBox2.Checked)
                    {
                        sothich = sothich + "," + "Đi du lịch";
                    }

                    if (checkBox2.Checked)
                    {
                        sothich = sothich + "," + "Chơi thể thao";
                    }
                }
                else
                {
                    sothich = "Khác";
                }

                string quoctich = comboBox1.Text;
                Console.WriteLine(dateOfbirth);
                Console.WriteLine(sothich);
                Console.WriteLine(quoctich);
                sinhvien sinhVien = new sinhvien()
                {
                    Fullname = fullname
                };
                db.sinhvien.Add(sinhVien);
                db.SaveChanges();
                Console.WriteLine("vao day");
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Lỗi server!", "Thông báo");
            }

        }

    }
}
