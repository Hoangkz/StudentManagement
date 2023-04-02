﻿using System;
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

    public partial class FormListUsers : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        
        private int checkUser = -1;
        public FormListUsers()
        {
            InitializeComponent();
            LoadDataAccount();
        }

        private void LoadDataAccount()
        {
            var listAccount = from c in db.Account
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
            {}

            string fullName = textBox1.Text;
            
            string Role = (string)comboBox1.SelectedItem;
            string Role2 = Role.Replace(" ","").ToLower();
            var account = from c in db.Account
                          select c;

            if (Id != 0)
            {
                account = account.Where(c => c.Id == Id);
            }
            if (fullName != "")
            {
                account = account.Where(c => c.FullName.Contains(fullName));
            }



            if (Role2 == "giảngviên" || Role2 == "nhânviên" || Role2 == "admin" || Role2 == "sinhviên")
            {
                account = account.Where(c => c.Role == Role);
            }

            if (checkUser == 1 || checkUser == 0)
            {
                bool result = (checkUser != 0);
                account = account.Where(c => c.isUser== result);
            }
            dgvAccount.DataSource = account.ToList();
            dgvAccount.Columns["Role"].HeaderText = "Loại TK";

            dgvAccount.Columns["Student"].Visible = false;
            dgvAccount.Columns["Teacher"].Visible = false;
            dgvAccount.Columns["PassWord"].Visible = false;
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkUser = 0;

            if (checkBox1.Checked)
            {
                checkUser = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            checkUser = -1;
            checkBox1.Checked = false;
            LoadDataAccount();
        }

        private void FormListUsers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            LoadDataAccount();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            txtID.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dgvAccount.SelectedRows.Count > 0)
            {
                try
                {
                    int[] arrId = new int[dgvAccount.SelectedRows.Count];
                    int i =0;
                    foreach (DataGridViewRow row in dgvAccount.SelectedRows)
                    {
                        arrId[i] = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                    }
                    var deleteAccount = db.Account.Where(u => arrId.Contains(u.Id));
                    if (deleteAccount != null)
                    {
                        string message = "Bạn có chắc chắn muốn xóa danh sách tài khoản hay không?";

                        DialogResult result = MessageBox.Show(message, "Xóa Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Danh sách tài khoản trên đã xoá thành công!";
                            db.Account.RemoveRange(deleteAccount);
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

        private void button5_Click(object sender, EventArgs e)
        {
             try
                {
                    int[] arrId = new int[dgvAccount.SelectedRows.Count];
                    int i = 0;
                    foreach (DataGridViewRow row in dgvAccount.SelectedRows)
                    {
                        arrId[i] = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                    }
                    var checkAccount = db.Account.Where(u => arrId.Contains(u.Id) && u.isUser == false);
                    Console.WriteLine(checkAccount.Count());
                    if (checkAccount.Count() != 0)
                    {
                        string message = "Bạn có chắc chắn muốn xác thực danh sách tài khoản này hay không?";

                        DialogResult result = MessageBox.Show(message, "Xác thực", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Danh sách tài khoản này đã được xác thực thành công!";
                            checkAccount.ToList().ForEach(u => u.isUser = true);

                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadDataAccount();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy tài khoản cần xác thực";
                        MessageBox.Show(text);
                    }

                }
                catch { string text = "Lỗi server"; MessageBox.Show(text); }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 1)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }

        }
    }
}
