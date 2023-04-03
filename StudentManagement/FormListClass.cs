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
        private int idClass = 0;

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
                                select new { c.IdClass, c.ClassName,u.IdTeacher, acc.FullName };
                                dbLopHocShow.DataSource = listClassRoom.ToList();
                                dbLopHocShow.Columns["IdClass"].HeaderText = "ID Class";
                                dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
                                dbLopHocShow.Columns["IdTeacher"].HeaderText = "ID Teacher";
                                dbLopHocShow.Columns["FullName"].HeaderText = " Giảng Viên ";

            var listTeacher = from c in db.Teacher
                              join u in db.Account
                              on c.idUser equals u.Id
                              select new { c.IdTeacher, u.FullName};
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tên giảng viên");
            comboBox1.SelectedIndex = 0;
            for (int i = 0; i < listTeacher.Count(); i++)
            {
                ArrIdTeacher[i] = listTeacher.ToArray()[i].IdTeacher;
                comboBox1.Items.Add(listTeacher.ToArray()[i].FullName);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int classID = 0;
            try
            {
                classID = int.Parse(txtIdClass.Text);
            }
            catch { }
            int teacherID = 0;
            try
            {
                teacherID = int.Parse(textBox1.Text);
            }
            catch { }
            string teacherName = comboBox1.Text;
            string ClassName = txtClassname.Text;

            var listClassRoom = from c in db.ClassRoom
                                join u in db.Teacher
                                on c.IdTeacher equals u.IdTeacher
                                join acc in db.Account on u.idUser equals acc.Id

                                select new { c.IdClass, c.ClassName,u.IdTeacher, acc.FullName };

            
            if (classID != 0)
            {
                listClassRoom = listClassRoom.Where(c => c.IdClass == classID);
            }

            if (teacherID != 0)
            {
                listClassRoom = listClassRoom.Where(c => c.IdTeacher == teacherID);
            }

            if (ClassName != "")
            {
                listClassRoom = listClassRoom.Where(c => c.ClassName.Contains(ClassName));
            }
            
            if (teacherName != "" && teacherName!="Tên giảng viên")
            {
                listClassRoom = listClassRoom.Where(c => c.FullName.Contains(teacherName));
            }

            dbLopHocShow.DataSource = listClassRoom.ToList();
            dbLopHocShow.Columns["IdClass"].HeaderText = "ID Class";
            dbLopHocShow.Columns["ClassName"].HeaderText = "Tên Lớp";
            dbLopHocShow.Columns["IdTeacher"].HeaderText = "ID Teacher";
            dbLopHocShow.Columns["FullName"].HeaderText = " Giảng Viên ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                int indexGv = comboBox1.SelectedIndex - 1;
                string className = txtClassname.Text;
                if (indexGv >= 0 && className != "")
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
                            IdTeacher = ArrIdTeacher[indexGv]
                        };
                        string message = "Bạn có chắc chắn muốn thêm lớp: " + classRoom.ClassName + ", Giảng viên: "+ comboBox1.Text+ "?";

                        string textMessage = "Thêm lớp " + className;
                        DialogResult result = MessageBox.Show(message, textMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Thêm lớp: " + className + " thành công!";
                            db.ClassRoom.Add(classRoom);
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadListClass();
                        }
                    }
                }
                else
                {
                    string text = "Tên lớp hoặc tên giáo viên không hợp lệ";
                    MessageBox.Show(text);
                }
            }
            catch
            {
                string text = "Tên lớp hoặc tên giáo viên không hợp lệ";
                MessageBox.Show(text);
            }
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dbLopHocShow.SelectedRows.Count > 0)
            {
                try
                {
                    int[] arrId = new int[dbLopHocShow.SelectedRows.Count];
                    int i = 0;
                    foreach (DataGridViewRow row in dbLopHocShow.SelectedRows)
                    {
                        arrId[i] = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                    }
                    var deleteClass = db.ClassRoom.Where(u => arrId.Contains(u.IdClass));
                    if (deleteClass != null)
                    {
                        string message = "Bạn có chắc chắn muốn xóa danh sách lớp đã chọn hay không?";

                        DialogResult result = MessageBox.Show(message, "Delete List Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Danh sách class trên đã xoá thành công!";
                            db.ClassRoom.RemoveRange(deleteClass);
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadListClass();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy lớp cần xoá";
                        MessageBox.Show(text);
                    }

                }
                catch { string text = "Lỗi server"; MessageBox.Show(text); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnUpdate.Text == "Cập nhật")
                {
                    idClass = int.Parse(dbLopHocShow.SelectedRows[0].Cells[0].Value.ToString());
                    txtClassname.Text = dbLopHocShow.SelectedRows[0].Cells[1].Value.ToString();
                    comboBox1.SelectedItem = dbLopHocShow.SelectedRows[0].Cells[3].Value.ToString();
                    btnUpdate.Text = "Lưu lại";
                }
                else if (btnUpdate.Text == "Lưu lại")
                {
                    if(txtClassname.Text!=""&& comboBox1.SelectedIndex - 1 >= 0)
                    {
                        var listClass = db.ClassRoom.Where(c => c.ClassName == txtClassname.Text);
                        if (listClass.Count() > 0)
                        {
                            string text = "Tên lớp đã tồn tại!";
                            MessageBox.Show(text);
                        }
                        else
                        {
                            var updateClass = db.ClassRoom.Find(idClass);
                            updateClass.ClassName = txtClassname.Text;
                            updateClass.IdTeacher = ArrIdTeacher[comboBox1.SelectedIndex-1];
                            db.SaveChanges();
                            string text = "Class: "+txtClassname.Text + " đã được cập nhật!";
                            MessageBox.Show(text);
                            txtIdClass.Text = "";
                            txtClassname.Text = "";
                            comboBox1.SelectedIndex = 0;
                            btnUpdate.Text = "Cập nhật";
                            idClass = 0;
                            LoadListClass();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy lớp cần Update";
                        MessageBox.Show(text);
                    }
                }
            }
            catch
            {
                string text = "Lỗi server"; 
                MessageBox.Show(text);
            }
        }

        private void dbLopHocShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dbLopHocShow.SelectedRows.Count == 1)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdClass.Text = "";
            txtClassname.Text = "";
            comboBox1.SelectedIndex = 0;
            btnUpdate.Text = "Cập nhật";
            idClass = 0;
            LoadListClass();
        }
    }

}


