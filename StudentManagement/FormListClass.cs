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

        private int[] ArrIdTeacher = new int[100];

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
            var listTeacher = from c in db.Teacher
                              join u in db.Account
                              on c.idUser equals u.Id
                              select new { c.IdTeacher, u.FullName };
           
           
            var listClassRoom = from c in db.ClassRoom
                                        join t in db.Teacher on c.IdClass equals t.IdClass into teachers
                                        from teacher in teachers.DefaultIfEmpty()
                                        select new
                                        {
                                            c.IdClass,
                                            c.ClassName,
                                            IdTeacher = teacher != null ? teacher.IdTeacher.ToString() : "",
                                            TeacherName = teacher != null ? teacher.Account.FullName : ""
                                        };

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tên giảng viên");
            comboBox1.SelectedIndex = 0;
            for (int i = 0; i < listTeacher.Count(); i++)
            {
                ArrIdTeacher[i] = listTeacher.ToArray()[i].IdTeacher;
                comboBox1.Items.Add(listTeacher.ToArray()[i].FullName);
            }
            dbLopHocShow.DataSource = listClassRoom.ToList();
            dbLopHocShow.Columns["IdClass"].HeaderText = "ID Class";
            dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
            dbLopHocShow.Columns["IdTeacher"].HeaderText = "ID Teacher";
            dbLopHocShow.Columns["TeacherName"].HeaderText = " Giảng Viên ";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int classID = 0;
            try
            {
                classID = int.Parse(txtIdClass.Text);
            }
            catch { }
            
            string teacherName = comboBox1.Text;
            string ClassName = txtClassname.Text;

            var listClassRoom = from c in db.ClassRoom
                                join t in db.Teacher on c.IdClass equals t.IdClass into teachers
                                from teacher in teachers.DefaultIfEmpty()
                                select new
                                {
                                    c.IdClass,
                                    c.ClassName,
                                    IdTeacher = teacher != null ? teacher.IdTeacher.ToString() : "",
                                    TeacherName = teacher != null ? teacher.Account.FullName : ""
                                };

            if (classID != 0)
            {
                listClassRoom = listClassRoom.Where(c => c.IdClass == classID);
            }


            if (ClassName != "")
            {
                listClassRoom = listClassRoom.Where(c => c.ClassName.Contains(ClassName));
            }
            
            if (teacherName != "" && teacherName!="Tên giảng viên")
            {
                listClassRoom = listClassRoom.Where(c => c.TeacherName.Contains(teacherName));
            }

            dbLopHocShow.DataSource = listClassRoom.ToList();
            dbLopHocShow.Columns["IdClass"].HeaderText = "ID Class";
            dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
            dbLopHocShow.Columns["IdTeacher"].HeaderText = "ID Teacher";
            dbLopHocShow.Columns["TeacherName"].HeaderText = " Giảng Viên ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int indexGv = comboBox1.SelectedIndex - 1;

                string className = txtClassname.Text;
                if (className != "")
                {
                    var listClass = db.ClassRoom.Where(c => c.ClassName== className);
                    if (listClass.Count() > 0)
                    {
                        string text = "Tên lớp đã tồn tại!";
                        MessageBox.Show(text);
                    }
                    else
                    {
                        ClassRoom classRoom = new ClassRoom()
                        {
                            ClassName = className,
                        };
                        string message = "Bạn có chắc chắn muốn thêm lớp: " + classRoom.ClassName +"?";

                        string textMessage = "Thêm lớp " + className;
                        DialogResult result = MessageBox.Show(message, textMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Thêm lớp: " + className + " thành công!";
                            db.ClassRoom.Add(classRoom);
                            if (comboBox1.SelectedIndex > 0)
                            {
                                var teacher = db.Teacher.Find(ArrIdTeacher[indexGv]);
                                teacher.IdClass = classRoom.IdClass;
                            }
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadListClass();
                        }
                    }
                }
                else
                {
                    string text = "Tên lớp không hợp lệ";
                    MessageBox.Show(text);
                }
            }
            catch
            {
                string text = "Lỗi server";
                MessageBox.Show(text);
            }
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dbLopHocShow.SelectedRows.Count > 0)
            {
                try
                {
                    int IdClassDelete = int.Parse(dbLopHocShow.SelectedRows[0].Cells[0].Value.ToString());
                    
                    var deleteClass = db.ClassRoom.Find(IdClassDelete);
                   
                    string message = "Bạn có chắc chắn muốn xóa danh sách lớp đã chọn hay không?";

                    DialogResult result = MessageBox.Show(message, "Delete List Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var teachersToUpdate = db.Teacher.Where(t => t.IdClass == IdClassDelete);
                        foreach (var teacher in teachersToUpdate)
                        {
                            teacher.IdClass = null;
                        }
                        db.SaveChanges();

                        string text = "Danh sách class trên đã xoá thành công!";
                        db.ClassRoom.Remove(deleteClass);
                        db.SaveChanges();
                        MessageBox.Show(text);
                        LoadListClass();
                    }

                }
                catch { string text = "Lỗi server"; MessageBox.Show(text); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idclass = int.Parse(dbLopHocShow.SelectedRows[0].Cells[0].Value.ToString());
            FormUpdateClass formUpdateClass = new FormUpdateClass(idclass);    
            formUpdateClass.ShowDialog();
        }

        private void dbLopHocShow_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdClass.Text = "";
            txtClassname.Text = "";
            comboBox1.SelectedIndex = 0;
            LoadListClass();
        }

        private void dbLopHocShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}


