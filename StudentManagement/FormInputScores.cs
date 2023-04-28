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
    public partial class FormInputScores : Form
    {
        DataGridViewRow dataColumn = null;
        StudentManagementEntities db = new StudentManagementEntities();
        int checkoutForm = -1;
        public FormInputScores(DataGridViewRow data,int i =1)
        {
            checkoutForm = i;
            dataColumn = data;
            InitializeComponent();
        }

        private void FormInputScores_Load(object sender, EventArgs e)
        {
            label3.Text = dataColumn.Cells[2].Value.ToString();
            label6.Text = dataColumn.Cells[4].Value.ToString();
            if(checkoutForm == 1)
            {
                int check = 0;
                if (dataColumn.Cells[5].Value != null && checkoutForm == 1)
                {
                    textBox1.Text = dataColumn.Cells[5].Value.ToString();
                    textBox1.Enabled = false;
                    check = check + 1;
                }

                if (dataColumn.Cells[6].Value != null && checkoutForm == 1)
                {
                    textBox2.Text = dataColumn.Cells[6].Value.ToString();
                    textBox2.Enabled = false;
                    check = check + 1;
                }

                if (check == 2)
                {
                    button1.Enabled = false;
                }
            }
            else
            {
                textBox1.Text = dataColumn.Cells[5].Value.ToString();
                textBox2.Text = dataColumn.Cells[6].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string diem1 = textBox1.Text;
            string diem2 = textBox2.Text;
            float point1 = -1;
            float point2 = -1;
            if (diem1 != "")
            {
                point1 = float.Parse(diem1);
            }

            if (diem2 != "")
            {
                point2 = float.Parse(diem2);
            }

            var mark = db.Mark.Find(dataColumn.Cells["Id"].Value);
            if(mark != null)
            {
                if (point1 >= 0)
                {
                    mark.Scores1 = point1;
                }
                if (point2 >= 0)
                {
                    mark.Scores2 = point2;
                }

                string message = "Xác nhận điểm đã nhập?";
                string text = "Nhập điểm cho sinh viên thành công!";

                if (checkoutForm == 2)
                {
                    message = "Sửa điểm đã nhập?";
                    text = "Sửa cho sinh viên thành công!";
                }
                DialogResult result = MessageBox.Show(message, "Xác nhận điểm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.SaveChanges();
                    MessageBox.Show(text);
                    this.Close();
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Không cho phép nhập ký tự khác số và dấu chấm
            }

            // Kiểm tra số thực nhập vào có hợp lệ hay không
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Không cho phép nhập nhiều hơn một dấu chấm
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Không cho phép nhập ký tự khác số và dấu chấm
            }

            // Kiểm tra số thực nhập vào có hợp lệ hay không
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Không cho phép nhập nhiều hơn một dấu chấm
            }
        }
    }
}
