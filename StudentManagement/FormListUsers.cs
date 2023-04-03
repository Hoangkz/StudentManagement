using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
                              select new {c.Id, c.UserName, c.Role, c.FullName,c.Gender,c.DateOfBirth,c.Phone,c.Email,c.isUser};
            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["Role"].HeaderText = "Loại TK";

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
                          select new { c.Id, c.UserName, c.Role, c.FullName, c.Gender, c.DateOfBirth, c.Phone, c.Email, c.isUser };

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
        private void ExportToExcel(DataGridView dataGridView, string text="excel")
        {
            // Tạo đối tượng Excel và mở một workbook mới
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);

            // Tạo một worksheet và đặt tên cho nó
            Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "ExportedFromDataGridView";

            // Thêm tiêu đề cho bảng
            for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, i], worksheet.Cells[1, i]];
                headerRange.Font.Bold = true;
                headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.RowHeight = 30;
            }
            // Thêm dữ liệu vào bảng
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
            Excel.Range columnsRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dataGridView.Rows.Count + 1, dataGridView.Columns.Count]];
            columnsRange.Columns.AutoFit();
            columnsRange.RowHeight = 22;
            // Hiển thị dialog để người dùng chọn nơi lưu file
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = text;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing,
                    Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing, Type.Missing);
            }

            // Đóng workbook và Excel
            workbook.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string text = label1.Text;
            ExportToExcel(dgvAccount, text);
        }
    }
}
