using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
        private void ExportToExcel( DataGridView dataGridView, string text="excel")
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
        private void button3_Click(object sender, EventArgs e)
        {
            string text = label3.Text;
            ExportToExcel(dgvGV, text);
        }
    }
}
