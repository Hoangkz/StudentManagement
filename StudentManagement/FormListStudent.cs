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
    public partial class FormListStudent : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();

        public FormListStudent()
        {
            InitializeComponent();
            LoadDataAccount();
        }


        private void LoadDataAccount()
        {
            var listAccount = from c in db.Account
                              join u in db.Student 
                              on c.Id equals u.idUser
                              join classRoomJoin in db.ClassRoom on u.IdClass equals classRoomJoin.IdClass into classRoomGroup
                              from classRoom in classRoomGroup.DefaultIfEmpty()
                              where (c.Role.Replace(" ","").ToLower() =="sinhviên" && c.isUser==true)
                              select new { c.Id, c.FullName, c.Gender, c.DateOfBirth, c.Phone, c.Email,
                                  Class = classRoom != null ? classRoom.ClassName : "Chưa xếp lớp"
                              };
            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["Gender"].HeaderText = "Giới tính";
            dgvAccount.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvAccount.Columns["Class"].HeaderText = "Lớp";

            db.SaveChanges();

        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            int Id = 0;
            try
            {
                Id = int.Parse(txtID.Text);
            }
            catch
            { }

            string fullName = textBox1.Text;

            var account = from c in db.Account
                          where (c.Role.Replace(" ", "").ToLower() == "sinhviên" && c.isUser == true)
                          select c;

            if (Id != 0)
            {
                account = account.Where(c => c.Id == Id);
            }
            if (fullName != "")
            {
                account = account.Where(c => c.FullName.Contains(fullName));
            }

            dgvAccount.DataSource = account.ToList();
            dgvAccount.Columns["Role"].HeaderText = "Loại TK";

            dgvAccount.Columns["Student"].Visible = false;
            dgvAccount.Columns["Teacher"].Visible = false;
            dgvAccount.Columns["PassWord"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            LoadDataAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDetailStudent formDetailStudent = new FormDetailStudent(dgvAccount.SelectedRows[0]);
            formDetailStudent.ShowDialog();
        }
    }
}
