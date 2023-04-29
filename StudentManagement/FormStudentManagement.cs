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
    public partial class FormStudentManagement : Form
    {
        private int idUser;
        StudentManagementEntities db = new StudentManagementEntities();
        public FormStudentManagement(int id)
        {
            idUser = id;
            InitializeComponent();
            FormMain formMain = new FormMain(idUser);
            AddForm(formMain);
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {
            var User = db.Account.Find(idUser);
            string role = User.Role.Replace(" ", "").ToLower();
            if (role =="admin")
            {
                dangKyToolStripMenuItem.Visible = false;
                DiemThanhPhanToolStripMenuItem.Visible=false;
                DiemThiToolStripMenuItem.Visible=false;
                traCuuDiemToolStripMenuItem.Visible = false;
                myClassToolStripMenuItem.Visible = false;
            }
            else
            {
                if (role=="giảngviên")//nếu là giáo viên
                {
                    dangKyToolStripMenuItem.Visible = false;
                    dangkymonhocClassHọcToolStripMenuItem.Visible=false;
                    danhSachTaiKhoanToolStripMenuItem.Visible = false;
                    giaoVienToolStripMenuItem1.Visible = false;
                    traCuuDiemToolStripMenuItem.Visible = false;
                    var teacher = db.Teacher.FirstOrDefault(c=>c.idUser==idUser);
                    if(teacher.IdClass==null)
                    {
                        myClassToolStripMenuItem.Visible = false;
                    }
                    
                }
                else if(role== "sinhviên")//chỉ còn lại trường hợp là sinh viên
                {
                    dangkymonhocClassHọcToolStripMenuItem.Visible = false;
                    danhSachTaiKhoanToolStripMenuItem.Visible = false;
                    quanLyToolStripMenuItem.Visible = false;
                    DiemThanhPhanToolStripMenuItem.Visible = false;
                    DiemThiToolStripMenuItem.Visible = false;
                    myClassToolStripMenuItem.Visible = false;
                }
            }
        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListUsers formListUsers = new FormListUsers();
            AddForm(formListUsers);
        }
        private void AddForm(Form form)
        {
            this.pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Text = form.Text;
            this.pnlContent.Controls.Add(form);
            this.Width = form.Width+10;
            this.Height = form.Height+50;
            form.Show();
            Screen screen = Screen.FromControl(this);
            int x = (screen.WorkingArea.Width - this.Width) / 2 + screen.WorkingArea.Left;
            int y = (screen.WorkingArea.Height - this.Height) / 2 + screen.WorkingArea.Top;
            this.Location = new Point(x, y);


        }
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User user = new User(idUser);
            AddForm(user);
            //user.ShowDialog();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain(idUser);
            AddForm(formMain);
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var User = db.Account.Find(idUser);
            string role = User.Role.Replace(" ", "").ToLower();
            int checkRole = 0;
            if(role == "giảngviên")
            {
                checkRole = User.Id;
            }
            FormListStudent formListStudent = new FormListStudent(checkRole);
            AddForm(formListStudent);
        }

        private void lopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListClass formListClass = new FormListClass();
            AddForm(formListClass);
        }

        private void dangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegesterSubject formRegesterSubject = new FormRegesterSubject(idUser);
            AddForm(formRegesterSubject);
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListSubject formListSubject = new FormListSubject();
            AddForm(formListSubject);
        }

        private void giaoVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormListTeacher formlistTeacher = new FormListTeacher();
            AddForm(formlistTeacher);
        }

        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegesterSubjectClass formRegesterSubjectClass = new FormRegesterSubjectClass(idUser);
            AddForm(formRegesterSubjectClass);
        }

        private void DiemThanhPhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormScores formScores = new FormScores(idUser);
            AddForm(formScores);
        }

        private void DiemThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExam formExam = new FormExam(idUser);
            AddForm(formExam);  
        }

        private void traCuuDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var User = db.Account.Find(idUser);
            string role = User.Role.Replace(" ", "").ToLower();
            int checkRole = 0;
            if (role == "sinhviên")
            {
                checkRole = User.Id;
            }
            FormCheckScores formCheckScores = new FormCheckScores(checkRole);
            AddForm(formCheckScores);
        }

        private void lớpHọcCủaTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var User = db.Teacher.FirstOrDefault(c=>c.idUser==idUser);
            string role = User.Account.Role.Replace(" ", "").ToLower();
            int idGiangVien = 0;
            if (role == "giảngviên")
            {
                if (User.IdClass != null)
                {
                    idGiangVien = User.IdTeacher;
                    FormMyClass formMyClass = new FormMyClass(idGiangVien);
                    AddForm(formMyClass);
                }
            }
        }
    }
}
