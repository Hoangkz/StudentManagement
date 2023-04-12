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
                              join u in db.Student 
                              on c.Id equals u.idUser

                              
                              join classRoomJoin in db.ClassRoom on u.IdClass equals classRoomJoin.IdClass 
                              into classRoomGroup from classRoom in classRoomGroup.DefaultIfEmpty() where (c.Role.Replace(" ","").ToLower() =="sinhviên" && c.isUser==true)
                              select new { c.Id, c.FullName, c.Gender, c.DateOfBirth, c.Phone, c.Email,
                                  Class = classRoom != null ? classRoom.ClassName : "Chưa xếp lớp"
                              };
            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["Gender"].HeaderText = "Giới tính";
            dgvAccount.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvAccount.Columns["Class"].HeaderText = "Lớp";

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

            var listAccount = from c in db.Account
                              join u in db.Student
                              on c.Id equals u.idUser
                              join classRoomJoin in db.ClassRoom on u.IdClass equals classRoomJoin.IdClass into classRoomGroup
                              from classRoom in classRoomGroup.DefaultIfEmpty()
                              where (c.Role.Replace(" ", "").ToLower() == "sinhviên" && c.isUser == true)
                              select new
                              {
                                  c.Id,
                                  c.FullName,
                                  c.Gender,
                                  c.DateOfBirth,
                                  c.Phone,
                                  c.Email,
                                  Class = classRoom != null ? classRoom.ClassName : "Chưa xếp lớp"
                              };
            

            string fullName = textBox1.Text;


            if (Id != 0)
            {
                listAccount = listAccount.Where(c => c.Id == Id);
            }
            if (fullName != "")
            {
                listAccount = listAccount.Where(c => c.FullName.Contains(fullName));
            }

            dgvAccount.DataSource = listAccount.ToList();
            dgvAccount.Columns["FullName"].HeaderText = "Họ và tên";
            dgvAccount.Columns["Gender"].HeaderText = "Giới tính";
            dgvAccount.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dgvAccount.Columns["Class"].HeaderText = "Lớp";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegester formRegester = new FormRegester();
            formRegester.ShowDialog();
            LoadDataAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDetailStudent formDetailStudent = new FormDetailStudent(dgvAccount.SelectedRows[0]);
            formDetailStudent.ShowDialog();
            LoadDataAccount();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resuilt;
            resuilt = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Thông tin", MessageBoxButtons.YesNo);
            if (resuilt.ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void FormListStudent_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resuilt;
            resuilt = MessageBox.Show("Bạn chắc chắn muốn đóng", "Thông tin", MessageBoxButtons.YesNo);
            if(resuilt.ToString() == "Yes")
            {
                this.Close();
            }        
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
        private void button5_Click(object sender, EventArgs e)
        {
            string text = label3.Text;
            ExportToExcel(dgvAccount, text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            textBox1.Text = "";
            LoadDataAccount();
        }
    }
}
