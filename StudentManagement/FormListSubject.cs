using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentManagement
{
    public partial class FormListSubject : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();
        private int[] ArrIdTeacher = new int[100];
        private int IdSubject = 0;
        public FormListSubject()
        {
            InitializeComponent();
            LoadDataSubject();
        }
        private void LoadDataSubject()
        {
            var listSubject = from c in db.Subject
                              join u in db.Teacher
                                on c.IdTeacher equals u.IdTeacher
                              join acc in db.Account 
                              on u.idUser equals acc.Id
                              select new { c.IdSubject, c.SubjectName, u.IdTeacher, acc.FullName};
            var query = from c in db.Teacher
                        join u in db.Account
                        on c.idUser equals u.Id
                        select new { c.IdTeacher, u.FullName };
            for (int i = 0; i < query.Count(); i++)
            {
                ArrIdTeacher[i] = query.ToArray()[i].IdTeacher;
                CbGV.Items.Add(query.ToArray()[i].FullName);
            }
            dgvDSMH.DataSource = listSubject.ToList();
            dgvDSMH.Columns["IdSubject"].HeaderText = "Mã môn học";
            dgvDSMH.Columns["SubjectName"].HeaderText = "Tên môn học";
            dgvDSMH.Columns["IdTeacher"].HeaderText = "Mã giảng viên";

            dgvDSMH.Columns["FullName"].HeaderText = "Tên giảng viên";

            db.SaveChanges();
            

        }
        private void FormListSubject_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string SubjectName = txtTimKiem.Text;
            string FullName = CbGV.Text;

            var subject = from c in db.Subject
                              join u in db.Teacher
                                on c.IdTeacher equals u.IdTeacher
                              join acc in db.Account
                              on u.idUser equals acc.Id
                              select new { c.IdSubject, c.SubjectName, u.IdTeacher, acc.FullName };
            if (SubjectName != "")
            {
                subject = subject.Where(c => c.SubjectName.Contains(SubjectName));
            }
            if (FullName != "")
            {
                subject = subject.Where(c => c.FullName.Contains(FullName));
            }
            dgvDSMH.DataSource = subject.ToList();
            dgvDSMH.Columns["IdSubject"].HeaderText = "Mã môn học";
            dgvDSMH.Columns["SubjectName"].HeaderText = "Tên môn học";
            dgvDSMH.Columns["IdTeacher"].HeaderText = "Mã giảng viên";

            dgvDSMH.Columns["FullName"].HeaderText = "Tên giảng viên";

            
            dgvDSMH.DataSource = subject.ToList();


        }

        public void dgvDSMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                
                int IdTeacher = ArrIdTeacher[CbGV.SelectedIndex];
                string SubjectName = txtTimKiem.Text;
                Console.WriteLine(IdTeacher + " " + SubjectName);
                if (IdTeacher >= 0 && SubjectName != "")
                {
                    var listSubject = db.Subject.Where(c => c.SubjectName == SubjectName && c.IdTeacher == IdTeacher);

                    if (listSubject.Count() > 0)
                    {
                        string text = "Môn học đã tồn tại!";
                        MessageBox.Show(text);
                    }
                    else
                    {
                        Console.WriteLine("vao day");

                        Subject subject = new Subject()
                        {
                            SubjectName = SubjectName,
                            IdTeacher = IdTeacher
                        };


                        string message = "Bạn có chắc chắn muốn thêm môn học: " + subject.SubjectName + ", Giảng viên: " + CbGV.Text + "?";

                        string textMessage = "Thêm môn học " + SubjectName;
                        DialogResult result = MessageBox.Show(message, textMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Thêm môn học: " + SubjectName + " thành công!";
                            db.Subject.Add(subject);
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadDataSubject();
                        }
                    }
                }
                else
                {
                    string text = "Tên môn học hoặc tên giáo viên không hợp lệ";
                    MessageBox.Show(text);
                }
            }
            catch
            {
                string text = "Lỗi server";
                MessageBox.Show(text);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text == "Cập nhật")
                {
                    IdSubject = int.Parse(dgvDSMH.SelectedRows[0].Cells[0].Value.ToString());
                    txtTimKiem.Text = dgvDSMH.SelectedRows[0].Cells[1].Value.ToString();
                    CbGV.SelectedItem = dgvDSMH.SelectedRows[0].Cells[3].Value.ToString();
                    btnSua.Text = "Lưu lại";
                }
                else if (btnSua.Text == "Lưu lại")
                {
                    if (txtTimKiem.Text != "" && CbGV.SelectedIndex >= 0)
                    {
                        var listSubject = db.Subject.Where(c => c.SubjectName == txtTimKiem.Text && c.IdTeacher == CbGV.SelectedIndex);
                        if (listSubject.Count() > 0)
                        {
                            string text = "Môn học đã tồn tại!";
                            MessageBox.Show(text);
                        }
                        else
                        {
                            var updateSubject = db.Subject.Find(IdSubject);
                            updateSubject.SubjectName = txtTimKiem.Text;
                            updateSubject.IdTeacher = ArrIdTeacher[CbGV.SelectedIndex];
                            db.SaveChanges();
                            string text = "Môn học: " + txtTimKiem.Text + " đã được cập nhật!";
                            MessageBox.Show(text);

                            txtTimKiem.Text = "";
                            CbGV.Text = "";
                            btnSua.Text = "Cập nhật";
                            IdSubject = 0;
                            LoadDataSubject();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy môn học cần cập nhật";
                        MessageBox.Show(text);
                    }
                }
            }
            catch
            {
                string text = "Lỗi server";
                MessageBox.Show(text);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSMH.SelectedRows.Count > 0)
            {
                
                try
                {
                    int[] arrId = new int[dgvDSMH.SelectedRows.Count];
                    int i = 0;
                    foreach (DataGridViewRow row in dgvDSMH.SelectedRows)
                    {
                        arrId[i] = int.Parse(row.Cells[0].Value.ToString());
                        i++;
                    }
                    var deleteAccount = db.Subject.Where(u => arrId.Contains(u.IdSubject));
                    if (deleteAccount != null)
                    {
                        string message = "Bạn có chắc chắn muốn xóa danh sách môn học hay không?";

                        DialogResult result = MessageBox.Show(message, "Xóa Môn Học", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string text = "Danh sách môn học trên đã xoá thành công!";
                            db.Subject.RemoveRange(deleteAccount);
                            db.SaveChanges();
                            MessageBox.Show(text);
                            LoadDataSubject();
                        }
                    }
                    else
                    {
                        string text = "Không tìm thấy môn học cần xoá";
                        MessageBox.Show(text);
                    }

                }
                catch { string text = "Lỗi server"; MessageBox.Show(text); }
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
        private void btnEE_Click(object sender, EventArgs e)
        {
            string text = label1.Text;
            ExportToExcel(dgvDSMH, text);
        }

        private void dgvDSMH_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDSMH.SelectedRows.Count>1)
            {
                btnSua.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            CbGV.Text = "";
            btnSua.Text = "Cập nhật";
            LoadDataSubject();
        }
    }
}

