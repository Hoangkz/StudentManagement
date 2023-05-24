using System;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormListTeacher : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public FormListTeacher()
        {
            InitializeComponent();
            LoadDataTeacher();
        }

        private void LoadDataTeacher()
        {
            var listTeacher = from c in db.Account
                              join u in db.Teacher
                              on c.Id equals u.idUser
                              select new
                              {
                                  u.IdTeacher,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,
                                  u.Faculty.FacultyName

                              };
            dgvGV.DataSource = listTeacher.ToList();
            dgvGV.Columns["IdTeacher"].HeaderText = "ID"; 
            dgvGV.Columns["FullName"].HeaderText = "Tên Giảng viên"; 
            dgvGV.Columns["Gender"].HeaderText = "Giới tính"; 
            dgvGV.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvGV.Columns["FacultyName"].HeaderText = "Tên khoa";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            var listTeacher = from c in db.Account
                              join u in db.Teacher
                              on c.Id equals u.idUser
                              select new
                              {
                                  u.IdTeacher,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,

                              };


            string fullName = textBox1.Text;


            if (Id != 0)
            {
                listTeacher = listTeacher.Where(c => c.IdTeacher == Id);
            }
            if (fullName != "")
            {
                listTeacher = listTeacher.Where(c => c.FullName.Contains(fullName));
            }

            dgvGV.DataSource = listTeacher.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvGV.SelectedRows.Count > 0)
            {
                try
                {
                    int[] arrId = new int[dgvGV.SelectedRows.Count];
                    int i = 0;
                    foreach (DataGridViewRow row in dgvGV.SelectedRows)
                    {
                        arrId[i] = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                    }
                    var deleteTeacher = db.Teacher.Where(u => arrId.Contains(u.IdTeacher));
                    Console.WriteLine(deleteTeacher.Count());
                    var listAccount = db.Account.Where(a => deleteTeacher.Any(t => t.idUser == a.Id));
                    Console.WriteLine(listAccount.Count());
                    if (listAccount.Any())
                    {
                        string message = "Bạn có chắc chắn muốn xóa danh sách tài khoản hay không?";
                        DialogResult result = MessageBox.Show(message, "Xóa Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            foreach (var teacher in deleteTeacher)
                            {

                                var hasMark = db.Mark.Any(z => z.IdTeacher == teacher.IdTeacher);
                                if (hasMark)
                                {
                                    string text2 = "Không thể xoá tài khoản: " + teacher.Account.FullName + " vì tồn tại bản ghi trong bảng Mark!";
                                    MessageBox.Show(text2);
                                    return; // Bỏ qua và dừng việc xoá tài khoản   
                                }
                            }
                            db.Account.RemoveRange(listAccount);
                            db.SaveChanges();
                            string text = "Danh sách tài khoản trên đã xoá thành công!";
                            MessageBox.Show(text);
                            LoadDataTeacher();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy tài khoản cần xoá";
                        MessageBox.Show(text);
                    }

                }
                catch { string text = "Lỗi server"; MessageBox.Show(text); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            LoadDataTeacher();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            textBox1.Text = "";
            LoadDataTeacher();
        }
    }
}
