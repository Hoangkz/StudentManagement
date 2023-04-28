using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentManagement
{
    public partial class FormDetailStudent : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        private int[] ArrClass = new int[100];

        DataGridViewRow dataColumn = null;
        public FormDetailStudent(DataGridViewRow data)
        {
            dataColumn = data;
            InitializeComponent();
        }

        private void DetailStudent_Load(object sender, EventArgs e)
        {
            int IDStudent = int.Parse(dataColumn.Cells[0].Value.ToString());
            var query = from c in db.ClassRoom 
                        select new { id = c.IdClass, Class= c.ClassName };

            for (int i = 0; i < query.Count(); i++)
            {
                ArrClass[i] = query.ToArray()[i].id;
                comboBox2.Items.Add(query.ToArray()[i].Class);
            }

            var markStudent = db.Mark.Where(c => c.Student.idUser == IDStudent)
                                                .Select(m => new {
                                                    Idstudent = m.Student.idUser,
                                                    StudentName = m.Student.Account.FullName,
                                                    SubjectName = m.Subject.SubjectName,
                                                    TeacherName = m.Teacher.Account.FullName,
                                                    m.Scores1,
                                                    m.Scores2,
                                                    m.Examscores,
                                                    m.FinalGrade
                                                });
            dataGridView1.DataSource = markStudent.ToList();
            dataGridView1.Columns["Idstudent"].HeaderText = "Id";
            dataGridView1.Columns["StudentName"].HeaderText = "Tên sinh viên";
            dataGridView1.Columns["TeacherName"].HeaderText = "Tên giảng viên";
            dataGridView1.Columns["SubjectName"].HeaderText = "Môn học";
            dataGridView1.Columns["FinalGrade"].HeaderText = "Tổng kết";
            dataGridView1.Columns["Examscores"].HeaderText = "Điểm thi";
            dataGridView1.Columns["Scores1"].HeaderText = "Điểm thành phần 1";
            dataGridView1.Columns["Scores2"].HeaderText = "Điểm thành phần 2";
            this.Text = "Sinh viên " + dataColumn.Cells[1].Value.ToString();
            textBox1.Text = dataColumn.Cells[1].Value.ToString();
            textBox2.Text = dataColumn.Cells[4].Value.ToString();
            textBox3.Text = dataColumn.Cells[5].Value.ToString();
            comboBox1.SelectedItem = dataColumn.Cells[2].Value.ToString(); 
            comboBox2.SelectedItem = dataColumn.Cells[6].Value.ToString();
            DateTime dateTime = DateTime.ParseExact(dataColumn.Cells[3].Value.ToString(), "dd/MM/yyyy", null);

            dateTimePicker1.Value = dateTime;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IDStudent = int.Parse(dataColumn.Cells[0].Value.ToString());
            var markStudent = db.Mark.Where(c => c.Student.idUser == IDStudent)
                                     .Select(m => new { 
                                         Idstudent = m.Student.idUser, 
                                         StudentName = m.Student.Account.FullName, 
                                         SubjectName = m.Subject.SubjectName,
                                         TeacherName = m.Teacher.Account.FullName, 
                                         m.Scores1, 
                                         m.Scores2, 
                                         m.Examscores, 
                                         m.FinalGrade });

            string SubjectName = textBox4.Text;
            string TeacherName = textBox5.Text;
            if (SubjectName!=""){

                markStudent = markStudent.Where(c => c.SubjectName.Contains(SubjectName));
            }

            if (TeacherName != "")
            {

                markStudent = markStudent.Where(c => c.TeacherName.Contains(TeacherName));
            }
            dataGridView1.DataSource = markStudent.ToList();
            dataGridView1.Columns["Idstudent"].HeaderText = "Id";
            dataGridView1.Columns["StudentName"].HeaderText = "Tên sinh viên";
            dataGridView1.Columns["TeacherName"].HeaderText = "Tên giảng viên";
            dataGridView1.Columns["SubjectName"].HeaderText = "Môn học";
            dataGridView1.Columns["FinalGrade"].HeaderText = "Tổng kết";
            dataGridView1.Columns["Examscores"].HeaderText = "Điểm thi";
            dataGridView1.Columns["Scores1"].HeaderText = "Điểm thành phần 1";
            dataGridView1.Columns["Scores2"].HeaderText = "Điểm thành phần 2";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try {
                String FullName = textBox1.Text;
                String Gender = comboBox1.SelectedItem.ToString();
                String Phone = textBox2.Text;
                String Email = textBox3.Text;

                string dateOfbirth = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                int idClass = ArrClass[comboBox2.SelectedIndex];
                int id = int.Parse(dataColumn.Cells[0].Value.ToString());
                if(FullName!="" && Gender != "" && Phone != "" && Email != "")
                {
                    var student = db.Account.Find(id);
                    student.FullName = FullName;
                    student.Gender = Gender;
                    student.Phone = Phone;
                    student.Email = Email;
                    student.DateOfBirth = dateOfbirth;
                    db.SaveChanges();
                    var classStudent = db.Student.FirstOrDefault(o => o.idUser == id);
                    classStudent.IdClass = idClass;
                    db.SaveChanges();
                    string text = "Cập nhật thành công!";
                    MessageBox.Show(text, "Thông báo");
                }
                else
                {
                    string text = "Cập nhật không thành công!";
                    MessageBox.Show(text, "Thông báo");
                }
            }
            catch {

                string text = "Cập nhật không thành công!";
                MessageBox.Show(text, "Thông báo");
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void ExportToExcel(DataGridView dataGridView, string text = "excel")
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            string text = "Bảng điểm sinh viên";
            ExportToExcel(dataGridView1, text);
        }
    }
}
