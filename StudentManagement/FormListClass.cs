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
    public partial class FormListClass : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public FormListClass()
        {
            InitializeComponent();
            LoadListClass();
        }

        private void FormListClass_Load(object sender, EventArgs e)
        {
        }


        private void LoadListClass()
        {
            var listClassRoom = from c in db.ClassRoom
                                join u in db.Teacher
                                on c.IdTeacher equals u.IdTeacher
                                join acc in db.Account on u.idUser equals acc.Id 
                                select new { c.IdClass, c.ClassName, acc.FullName };
                                dbLopHocShow.DataSource = listClassRoom.ToList();
                                dbLopHocShow.Columns["IdClass"].HeaderText = "ID";
                                dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
                                dbLopHocShow.Columns["FullName"].HeaderText = " Giảng Viên ";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int classID = 0;
            try
            {
                classID = int.Parse(txtIdClass.Text);
            }
            catch { }
            string teacherName = txtTeacher.Text;
            string ClassName = txtClassname.Text;

            var listClassRoom = from c in db.ClassRoom
                                join u in db.Teacher
                                on c.IdTeacher equals u.IdTeacher
                                join acc in db.Account on u.idUser equals acc.Id

                                select new { c.IdClass, c.ClassName, acc.FullName };

            
            if (classID != 0)
            {
                listClassRoom = listClassRoom.Where(c => c.IdClass == classID);
            }

            if (ClassName != "")
            {
                listClassRoom = listClassRoom.Where(c => c.ClassName.Contains(ClassName));
            }
            if (teacherName != "")
            {
                listClassRoom = listClassRoom.Where(c => c.FullName.Contains(teacherName));
            }

            dbLopHocShow.DataSource = listClassRoom.ToList();
            dbLopHocShow.Columns["IdClass"].HeaderText = "ID";
            dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
            dbLopHocShow.Columns["FullName"].HeaderText = " Giảng Viên ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddClass classAddNew = new FormAddClass();
            classAddNew.ShowDialog();
            LoadListClass();
            var listClassRoom = from c in db.ClassRoom
                                join u in db.Teacher on c.IdTeacher equals u.IdTeacher
                                join acc in db.Account on u.idUser equals acc.Id
                                select new { c.IdClass, c.ClassName, acc.FullName };
            dbLopHocShow.DataSource = listClassRoom.ToList();
            dbLopHocShow.Columns["IdClass"].HeaderText = "ID";
            dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
            dbLopHocShow.Columns["FullName"].HeaderText = " Giảng Viên ";
        }
    }

}


