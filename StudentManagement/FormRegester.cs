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
    public partial class FormRegester : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        private int[] ArrFaculty = new int[100];
        public FormRegester()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaitk = comboBox1.SelectedItem.ToString().Replace(" ", "").ToLower();
            if (loaitk == "giảngviên")
            {
                comboBox3.Enabled = true;
                if(comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox3.Enabled = false;
                comboBox3.Text = ""
;            }
        }

        private void FormRegester_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            var query = from c in db.Faculty
                        select new {id = c.IdFaculty, Khoa = c.FacultyName };
            Console.WriteLine(query.ToArray());
            for(int i = 0; i < query.Count(); i++)
            {
                ArrFaculty[i] = query.ToArray()[i].id;
                comboBox3.Items.Add(query.ToArray()[i].Khoa);
            }
        }

        private void buttonRegester_Click(object sender, EventArgs e)
        {
             string username = textBox1.Text;
            string password = textBox2.Text;
            string role = comboBox1.SelectedItem.ToString();
          
            string fullname = textBox3.Text;
            string gender = comboBox2.SelectedItem.ToString();
            string dateOfbirth = dateTimePicker1.Value.ToShortDateString().ToString();
            string tell = textBox4.Text;
            string email = textBox5.Text;
            if (username.Length >= 5 && password.Length >= 5 && role!="" && fullname.Length>0)
            { 
                var query = db.Account.Where(a => a.UserName == username);
                if (query.Count() > 0)
                {
                    MessageBox.Show("Tên tài khoản đã có người sử dụng!", "Thông báo");
                }
                else
                {
                    Account newAccount = new Account()
                    {
                        UserName = username,
                        PassWord = password,
                        Role = role,
                        FullName = fullname,
                        Gender = gender,
                        DateOfBirth = dateOfbirth,
                        Phone = tell,
                        Email = email,
                        isUser = false,
                    };
                    db.Account.Add(newAccount);
                    db.SaveChanges();
                    if(role.Replace(" ","").ToLower() == "sinhviên")
                    {
                        Student student = new Student()
                        {
                            idUser = newAccount.Id
                        };
                        db.Student.Add(student);
                        db.SaveChanges();

                    }
                    else if (role.Replace(" ", "").ToLower() == "giảngviên")
                    {
                        int idFaculty = ArrFaculty[comboBox3.SelectedIndex];
                        Teacher teacher = new Teacher()
                        {
                            idUser = newAccount.Id,
                            IdFaculty = idFaculty
                        };
                        db.Teacher.Add(teacher);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Đăng ký tài khoản thành công, hãy chờ cấp quyền truy cập!", "Thông báo");
                    this.Close();
                }
            }
            else if (username.Length < 5 && password.Length < 5)
            {
                MessageBox.Show("Tài tài khoản và mật khẩu phải có ít nhất 5 ký tự!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hãy nhập thông tin của bạn!", "Thông báo");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
