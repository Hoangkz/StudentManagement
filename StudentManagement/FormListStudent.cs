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
    public partial class FormListStudent : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();

        public FormListStudent()
        {
            InitializeComponent();
            LoadDataAccount();
        }


        private void LoadDataAccount()
        {
            var listAccount = from c in db.Account
                              where(c.Role.Replace(" ","").ToLower() =="sinhviên" && c.isUser==true)
                              select c;
            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["Role"].HeaderText = "Loại TK";

            dgvAccount.Columns["Student"].Visible = false;
            dgvAccount.Columns["Teacher"].Visible = false;
            dgvAccount.Columns["PassWord"].Visible = false;
            db.SaveChanges();

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

            string fullName = textBox1.Text;

            var account = from c in db.Account
                          where (c.Role.Replace(" ", "").ToLower() == "sinhviên" && c.isUser == true)
                          select c;

            if (Id != 0)
            {
                account = account.Where(c => c.Id == Id);
            }
            if (fullName != "")
            {
                account = account.Where(c => c.FullName.Contains(fullName));
            }

            dgvAccount.DataSource = account.ToList();
            dgvAccount.Columns["Role"].HeaderText = "Loại TK";

            dgvAccount.Columns["Student"].Visible = false;
            dgvAccount.Columns["Teacher"].Visible = false;
            dgvAccount.Columns["PassWord"].Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            textBox1.Text = "";
            LoadDataAccount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            LoadDataAccount();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count > 0)
            {
                try
                {
                    int Id = int.Parse(dgvAccount.SelectedRows[0].Cells[0].Value.ToString());
                    var deleteAccount = db.Account.Find(Id);
                    if (deleteAccount != null)
                    {
                        string message = "Bạn có chắc chắn muốn xóa tài khoản: " + deleteAccount.UserName + " hay không?";

                        DialogResult result = MessageBox.Show(message, "Xóa Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Xoá tài khoản: " + deleteAccount.UserName + " Thành công!";
                            db.Account.Remove(deleteAccount);
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadDataAccount();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(dgvAccount.SelectedRows[0].Cells[0].Value.ToString());
                FormUpdateUser formUpdateUser = new FormUpdateUser(Id);
                formUpdateUser.ShowDialog();
            }
            catch { }
        }
    }
}
