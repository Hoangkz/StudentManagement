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
    public partial class formquanlygiangvien : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public formquanlygiangvien()
        {
            InitializeComponent();
            LoadDataTeacher();
        }
        private void LoadDataTeacher()
        {
            var listTeacher = from c in db.Account
                              join u in db.Teacher
                              on c.Id equals u.idUser
                              select new
                              {
                                  u.IdTeacher,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,
                                  
                              };
            dgvGV.DataSource = listTeacher.ToList();
            db.SaveChanges();
           
           
                                  
                             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Id = 0;
            try
            {
                Id = int.Parse(textBox1.Text);
            }
            catch
            { }
            var listTeacher = from c in db.Account
                              join u in db.Teacher
                              on c.Id equals u.idUser
                          
                              where (c.Role.Replace(" ", "").ToLower() == "giangvien" && c.isUser == true)
                              select new
                              {
                                  u.IdTeacher,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,
                                 
                              };


            string fullName = textBox2.Text;


            if (Id != 0)
            {
                listTeacher = listTeacher.Where(c => c.IdTeacher == Id);
            }

            if (fullName != "")
            {
                listTeacher = listTeacher.Where(c => c.FullName.Contains(fullName));
            }

            dgvGV.DataSource = listTeacher.ToList();
            dgvGV.Columns["FullName"].HeaderText = "Họ và tên";
            dgvGV.Columns["Gender"].HeaderText = "Giới tính";
            dgvGV.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvGV.Columns["Class"].HeaderText = "Lớp";


        }

        private void button5_Click(object sender, EventArgs e)
        {
              formquanlygiangvien  button5 = new formquanlygiangvien ();
            button5.ShowDialog();
            LoadDataTeacher ();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(dgvGV.SelectedRows[0].Cells[0].Value.ToString());
                FormUpdateUser formUpdateUser = new FormUpdateUser(Id);
                formUpdateUser.ShowDialog();
            }
            catch { }
        }
        private void ExportToExcel (DataGridView dataGridView, string text="excel")
        { }
        private void button2_Click(Object sender, EventArgs e )
        {
            string Text = label1.Text;
                ExportToExcel(dgvGV, Text);
        }

        private void formquanlygiangvien_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
