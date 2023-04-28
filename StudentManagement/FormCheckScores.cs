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
    public partial class FormCheckScores : Form
    {
        int idStudent;
        StudentManagementEntities db = new StudentManagementEntities();
        public FormCheckScores(int id)
        { 
            this.idStudent = id;
            InitializeComponent();
            FormCheckScores_Load();
        }
        private void FormCheckScores_Load()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            var sinhvien = db.Student.FirstOrDefault(c => c.idUser == idStudent);
            label3.Text = sinhvien?.Account?.FullName;
            try
            {
                label5.Text = sinhvien?.ClassRoom?.ClassName;
            }
            catch { }
            var mark = db.Mark.Where(c => c.Student.idUser == idStudent)
                              .Select(c => new {
                                  c.Subject.SubjectName,
                                  c.Teacher.Account.FullName,
                                  c.Scores1,
                                  c.Scores2,
                                  c.Examscores,
                                  c.FinalGrade
                              });
            dataGridView1.DataSource = mark.ToList();
            dataGridView1.Columns["SubjectName"].HeaderText = "Môn học";
            dataGridView1.Columns["FullName"].HeaderText = "Giảng viên";
            dataGridView1.Columns["Scores1"].HeaderText = "Điểm hệ số 1";
            dataGridView1.Columns["Scores2"].HeaderText = "Điểm hệ số 2";
            dataGridView1.Columns["Examscores"].HeaderText = "Điểm thi";
            dataGridView1.Columns["FinalGrade"].HeaderText = "Tổng kết";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mark = db.Mark.Where(c => c.Student.idUser == idStudent)
                              .Select(c => new {
                                  c.Subject.SubjectName,
                                  c.Teacher.Account.FullName,
                                  c.Scores1,
                                  c.Scores2,
                                  c.Examscores,
                                  c.FinalGrade
                              });
            string SubjectName = textBox4.Text;
            string FullName = textBox5.Text;
            if (SubjectName != "")
            {
                mark = mark.Where(c=>c.SubjectName.Contains(SubjectName));
            }
            if (FullName != "")
            {
                mark = mark.Where(c => c.FullName.Contains(FullName));
            }
            dataGridView1.DataSource = mark.ToList();
            dataGridView1.Columns["SubjectName"].HeaderText = "Môn học";
            dataGridView1.Columns["FullName"].HeaderText = "Giảng viên";
            dataGridView1.Columns["Scores1"].HeaderText = "Điểm hệ số 1";
            dataGridView1.Columns["Scores2"].HeaderText = "Điểm hệ số 2";
            dataGridView1.Columns["Examscores"].HeaderText = "Điểm thi";
            dataGridView1.Columns["FinalGrade"].HeaderText = "Tổng kết";
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
            string text = "Bảng điểm sinh viên "+label3.Text +" lớp "+label5.Text;
            ExportToExcel(dataGridView1, text);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            FormCheckScores_Load();
        }
    }
}
