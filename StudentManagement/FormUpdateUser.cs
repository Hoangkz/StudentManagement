using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormUpdateUser : Form
    {
        private int Id;
        StudentManagementEntities db = new StudentManagementEntities();
        private int[] ArrFaculty = new int[100];
        public FormUpdateUser(int id)
        {
            Id = id;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string fullname = textBox3.Text;
                string role = (string)comboBox1.SelectedItem;
                string gender = comboBox2.SelectedItem.ToString();
                string dateOfbirth = dateTimePicker1.Value.ToShortDateString().ToString();
                string tell = textBox4.Text;
                string email = textBox5.Text;
                if (username.Length >= 5 && fullname.Length > 0)
                {
                    var query = db.Account.Where(a => a.UserName == username && a.Id!=Id);
                    if (query.Count() > 0)
                    {
                        MessageBox.Show("Tên tài khoản đã có người sử dụng!", "Thông báo");
                    }
                    else
                    {
                        var UpdateAccount = db.Account.Find(Id);
                        UpdateAccount.UserName = username;
                        UpdateAccount.FullName = fullname;
                        UpdateAccount.Gender = gender;
                        UpdateAccount.Role = role;
                        UpdateAccount.DateOfBirth = dateOfbirth;
                        UpdateAccount.Phone = tell;
                        UpdateAccount.Email = email;

                        db.SaveChanges();

                        if (role.Replace(" ", "").ToLower() == "giảngviên")
                        {
                            var deleteStudent = db.Student.FirstOrDefault(o => o.idUser == Id);
                            if (deleteStudent != null)
                            {
                                db.Student.Remove(deleteStudent);
                                db.SaveChanges();

                            }
                            int idFaculty = ArrFaculty[comboBox3.SelectedIndex];
                            var teacher = new Teacher()
                            {
                                idUser = Id,
                                IdFaculty = idFaculty
                            };
                            var existingObject = db.Teacher.FirstOrDefault(o => o.idUser == teacher.idUser);
                            if (existingObject != null)
                            {
                                existingObject.IdFaculty = idFaculty;
                                db.SaveChanges();

                            }
                            else
                            {
                                db.Teacher.Add(teacher);
                                db.SaveChanges();
                            }
                        }
                        else if (role.Replace(" ", "").ToLower() == "sinhviên")
                        {
                            var deleteTeacher = db.Teacher.FirstOrDefault(o => o.idUser == Id);
                            if (deleteTeacher != null)
                            {
                                db.Teacher.Remove(deleteTeacher);
                                db.SaveChanges();
                            }
                            var student = new Student()
                            {
                                idUser = Id
                            };
                            var existingObject = db.Student.FirstOrDefault(o => o.idUser == student.idUser);
                            if (existingObject == null)
                            {
                                db.Student.Add(student);
                                db.SaveChanges();
                            }
                        }
                        MessageBox.Show("Update tài khoản thành công!", "Thông báo");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập thông tin của bạn!", "Thông báo");
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string loaitk = comboBox1.SelectedItem.ToString().Replace(" ", "").ToLower();
                if (loaitk == "giảngviên")
                {
                    comboBox3.Enabled = true;
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.Enabled = false;
                    comboBox3.Text = "";
                }
            }
            catch { }
        }

        private void FormUpdateUser_Load(object sender, EventArgs e)
        {
            try
            {
                var UpdateAccount = db.Account.Find(Id);

                this.Text = UpdateAccount.FullName.ToString();
                textBox1.Text = UpdateAccount.UserName;
                textBox3.Text = UpdateAccount.FullName;
                textBox4.Text = UpdateAccount.Phone;
                string Role = UpdateAccount.Role;
                textBox5.Text = UpdateAccount.Email;
                comboBox1.SelectedItem = Role;
                comboBox2.SelectedItem = UpdateAccount.Gender;
                DateTime dateTime = DateTime.ParseExact(UpdateAccount.DateOfBirth, "dd/MM/yyyy", null);

                dateTimePicker1.Value = dateTime;
                var query = from c in db.Faculty
                            select new { id = c.IdFaculty, Khoa = c.FacultyName };
                for (int i = 0; i < query.Count(); i++)
                {
                    ArrFaculty[i] = query.ToArray()[i].id;
                    comboBox3.Items.Add(query.ToArray()[i].Khoa);
                }
                if(Role.Replace(" ", "").ToLower() == "giảngviên"){
                    try
                    {
                        var giangvien = from c in db.Teacher join u in db.Faculty on c.IdFaculty equals u.IdFaculty
                                        where c.idUser == Id
                                        select u.FacultyName;
                        comboBox3.SelectedItem = giangvien.ToArray()[0].ToString();
                        comboBox3.Enabled = true;
                    }
                    catch { }
                }
                else
                {
                    comboBox3.Enabled = false;
                }
            }
            catch { }
        }
    }
}
