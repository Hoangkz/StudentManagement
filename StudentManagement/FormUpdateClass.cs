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

    public partial class FormUpdateClass : Form
    {
        int idclass = 0;
        private int[] ArrIdTeacher = new int[100];

        StudentManagementEntities db = new StudentManagementEntities();
        public FormUpdateClass(int id = 0)
        {

            this.idclass = id;
            InitializeComponent();
            loadClass();
        }
        private void loadClass()
        {
            var updateClass = db.ClassRoom.Find(idclass);
            this.Text = "Cập nhật lớp " + updateClass?.ClassName;
            textBox1.Text = updateClass.ClassName;
            var listTeacher = from c in db.Teacher
                              join u in db.Account
                              on c.idUser equals u.Id
                              select new { c.IdTeacher, u.FullName };
            int i = 0;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chọn giảng viên");
            comboBox1.SelectedIndex = 0;
            foreach (var c in listTeacher)
            {
                ArrIdTeacher[i] = c.IdTeacher;
                comboBox1.Items.Add(c.FullName);
                i=i+1;
            }
            var checkClass = db.Teacher.FirstOrDefault(c=>c.IdClass == idclass);
            if(checkClass != null)
            {
                comboBox1.SelectedItem = checkClass.Account.FullName;    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string className = textBox1.Text;
                if(className != "")
                {
                    var checkClass = db.ClassRoom.FirstOrDefault(c=>c.IdClass!=idclass&&c.ClassName==className);
                    if (checkClass!=null)
                    {
                        string text2 = "Tên lớp đã tồn tại!";
                        MessageBox.Show(text2);
                    }
                    else
                    {
                        var updateClass = db.ClassRoom.Find(idclass);
                        updateClass.ClassName = className;
                        if (comboBox1.SelectedIndex - 1 >= 0)
                        {
                            int idTeacher = ArrIdTeacher[comboBox1.SelectedIndex - 1];
                            var checkTeacher = db.Teacher.Find(idTeacher);
                            if (checkTeacher.IdClass!=null)
                            {
                                string text = "Giảng viên này đã có lớp!";
                                MessageBox.Show(text);
                            }
                            else
                            {
                                var teacher = db.Teacher.Find(idTeacher);
                                var removeTeacher = db.Teacher.FirstOrDefault(c => c.IdClass == idclass);
                                if(removeTeacher!= null)
                                {
                                    removeTeacher.IdClass = null;
                                }
                                teacher.IdClass = updateClass.IdClass;
                                db.SaveChanges();
                                string text = "Update lớp " + className + " thành công!";
                                MessageBox.Show(text);
                            }
                        }
                        else
                        {
                            db.SaveChanges();
                            string text = "Update lớp " + className + " thành công!";
                            MessageBox.Show(text);
                        }
                    }
                }
                else
                {
                    string text = "Tên lớp không hợp lệ!";
                    MessageBox.Show(text);
                }
            }
            catch
            {
                string text = "Lỗi server";
                MessageBox.Show(text);
            }
        }
    }
}
