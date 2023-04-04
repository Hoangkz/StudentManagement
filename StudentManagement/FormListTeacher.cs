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

                          };
             dgvGV.DataSource = listTeacher.ToList();
             db.SaveChanges();
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
                    if (deleteTeacher != null)
                    {
                        string message = "Bạn có chắc chắn muốn xóa danh sách tài khoản hay không?";

                        DialogResult result = MessageBox.Show(message, "Xóa Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Danh sách tài khoản trên đã xoá thành công!";
                            db.Teacher.RemoveRange(deleteTeacher);
                            db.SaveChanges();
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
