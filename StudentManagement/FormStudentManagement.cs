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
            FormMain formMain = new FormMain(2030);
            AddForm(formMain);
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {
            var User = db.Account.Find(idUser);
            string role = User.Role.Replace(" ", "").ToLower();
            if (role =="admin")
            {
                Console.WriteLine("admin");

                //nếu là admin
                //ẩn 2 menu chấm điểm và đăng ký môn học
                //chỉ để lại menu quản lý
                //chamDiemToolStripMenuItem.Visible = false;
                //chucNangToolStripMenuItem.Visible = false;
            }
            else
            {
                //nếu không phải admin thì ẩn menu quản lý
                //quanLyToolStripMenuItem.Visible = false;
                if (role=="giảngviên")//nếu là giáo viên
                {
                    Console.WriteLine("Giảng Viên");

                    //ẩn menu đăng ký học -> cái này chỉ dành riêng cho sinh viên
                    //chucNangToolStripMenuItem.Visible = false;
                }
                else if(role== "sinhviên")//chỉ còn lại trường hợp là sinh viên
                {
                    Console.WriteLine("Sinh viên");

                    //chamDiemToolStripMenuItem.Visible = false;//ẩn menu chấm điểm<-chức năng của gv
                }
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
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
            FormMain formMain = new FormMain(2030);
            AddForm(formMain);
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListStudent formListStudent = new FormListStudent();
            AddForm(formListStudent);
        }

        private void lopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListClass formListClass = new FormListClass();
            AddForm(formListClass);
        }

        private void dangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
