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
    public partial class FormMyClass : Form
    {
        int idGiangvien = 0;
        StudentManagementEntities db = new StudentManagementEntities();
        public FormMyClass(int id = 0)
        {
            this.idGiangvien = id;
            InitializeComponent();
            loadClass();
        }
        private void loadClass()
        {
            var teacher = db.Teacher.Find(idGiangvien);
            this.Text = "Danh sách sinh viên lớp " + teacher.ClassRoom.ClassName;
            label1.Text = label1.Text+" " + teacher.ClassRoom.ClassName;
            var listTeacher = db.Student.Where(c => c.IdClass == teacher.IdClass)
                                        .Select(c => new {
                                                c.Account.Id,
                                                c.Account.FullName,
                                                c.Account.Gender,
                                                c.Account.DateOfBirth,
                                                c.Account.Phone,
                                                c.Account.Email
                                        });
            dataGridView1.DataSource = listTeacher.ToList();
            dataGridView1.Columns["FullName"].HeaderText = "Họ và tên";
            dataGridView1.Columns["Gender"].HeaderText = "Giới tính";
            dataGridView1.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
        }

        private void ExportToExcel(DataGridView dataGridView, string text = "excel")
        {
            if (dataGridView.Rows.Count > 0)
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
                        worksheet.Cells[i + 2, j + 1] = dataGridView?.Rows[i]?.Cells[j]?.Value?.ToString();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.Text;
            ExportToExcel(dataGridView1, text);
        }
    }
}
