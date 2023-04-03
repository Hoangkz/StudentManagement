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

            var listAccount = from c in db.Account
                              join u in db.Student
                              on c.Id equals u.idUser
                              join classRoomJoin in db.ClassRoom on u.IdClass equals classRoomJoin.IdClass into classRoomGroup
                              from classRoom in classRoomGroup.DefaultIfEmpty()
                              where (c.Role.Replace(" ", "").ToLower() == "sinhviên" && c.isUser == true)
                              select new
                              {
                                  c.Id,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,
                                  Class = classRoom != null ? classRoom.ClassName : "Chưa xếp lớp"
                              };
            

            string fullName = textBox1.Text;


            if (Id != 0)
            {
                listAccount = listAccount.Where(c => c.Id == Id);
            }
            if (fullName != "")
            {
                listAccount = listAccount.Where(c => c.FullName.Contains(fullName));
            }

            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["Gender"].HeaderText = "Giới tính";
            dgvAccount.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvAccount.Columns["Class"].HeaderText = "Lớp";

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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resuilt;
            resuilt = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Thông tin", MessageBoxButtons.YesNo);
            if (resuilt.ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void FormListStudent_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resuilt;
            resuilt = MessageBox.Show("Bạn chắc chắn muốn đóng", "Thông tin", MessageBoxButtons.YesNo);
            if(resuilt.ToString() == "Yes")
            {
                this.Close();
            }        
        }
    }
}
