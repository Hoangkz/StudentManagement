using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagement
{
    public partial class FormExam : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        private int idTeacher;
        public FormExam(int id)
        {
            var teacher = db.Teacher.FirstOrDefault(c => c.idUser == id);
            idTeacher = teacher.IdTeacher;
            InitializeComponent();
            LoadDataAccount();
        }
        private void LoadDataAccount()
        {
            var listClassName = db.ClassRoom;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chọn lớp học");
            foreach (var ClassName in listClassName)
            {
                comboBox1.Items.Add(ClassName.ClassName.ToString());
            }

            txtID.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            var listAccount = from c in db.Mark
                              where c.IdTeacher == idTeacher && c.Scores1 !=null && c.Scores2!=null 
                              select new
                              {
                                  c.Id,
                                  c.Student.IdStudent,
                                  c.Student.Account.FullName,
                                  c.Student.ClassRoom.ClassName,
                                  c.Subject.SubjectName,
                                  c.Examscores,
                              };
            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["Id"].Visible = false;
            dgvAccount.Columns["IdStudent"].HeaderText = "ID";
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["ClassName"].HeaderText = "Lớp";
            dgvAccount.Columns["SubjectName"].HeaderText = "Môn học";
            dgvAccount.Columns["Examscores"].HeaderText = "Điểm thi";

            db.SaveChanges();

        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            int idStudent = 0;
            try
            {
                idStudent = int.Parse(txtID.Text);
            }
            catch { }

            var listClassName = db.ClassRoom;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chọn lớp học");
            foreach (var ClassName in listClassName)
            {
                comboBox1.Items.Add(ClassName.ClassName.ToString());
            }

            String StudentName = textBox1.Text;
            String SubjectName = textBox2.Text;
            String ClassNameCombobox = comboBox1.Text;
            var listAccount = from c in db.Mark
                              where c.IdTeacher == idTeacher
                              where c.IdTeacher == idTeacher && c.Scores1 != null && c.Scores2 != null
                              select new
                              {
                                  c.Id,
                                  c.Student.IdStudent,
                                  c.Student.Account.FullName,
                                  c.Student.ClassRoom.ClassName,
                                  c.Subject.SubjectName,
                                  c.FinalGrade,
                              };

            if (idStudent != 0)
            {
                listAccount = listAccount.Where(c => c.IdStudent == idStudent);
            }

            if (StudentName != "")
            {
                listAccount = listAccount.Where(c => c.FullName.Contains(StudentName));
            }

            if (SubjectName != "")
            {
                listAccount = listAccount.Where(c => c.SubjectName.Contains(SubjectName));
            }
            if (ClassNameCombobox != "Chọn lớp học")
            {
                listAccount = listAccount.Where(c => c.ClassName.Contains(ClassNameCombobox));
            }


            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["IdStudent"].HeaderText = "ID";
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["ClassName"].HeaderText = "Lớp";
            dgvAccount.Columns["SubjectName"].HeaderText = "Môn học";
            dgvAccount.Columns["FinalGrade"].HeaderText = "Điểm thi";

            db.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadDataAccount();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInputExam formInputExam = new FormInputExam(dgvAccount.SelectedRows[0]);
            formInputExam.ShowDialog();
            LoadDataAccount();
        }


        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
