using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagement
{
    public partial class FormInputExam : Form
    {
        DataGridViewRow dataColumn = null;
        StudentManagementEntities db = new StudentManagementEntities();
        public FormInputExam(DataGridViewRow data, int i = 1)
        {
            dataColumn = data;
            InitializeComponent();
        }

        private void FormInputScores_Load(object sender, EventArgs e)
        {


            label3.Text = dataColumn.Cells[2].Value.ToString();
            label6.Text = dataColumn.Cells[4].Value.ToString();
            if (dataColumn.Cells[5].Value != null )
            {
                textBox1.Text = dataColumn.Cells[5].Value.ToString();
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string diem1 = textBox1.Text;
            float point1 = -1;
            if (diem1 != "")
            {
                point1 = float.Parse(diem1);
            }

            var mark = db.Mark.Find(dataColumn.Cells["Id"].Value);
            if (mark != null)
            {
                if (point1 >= 0)
                {
                    mark.Examscores = point1;
                    double FinalGrade = (float.Parse(mark.Scores1.ToString()) + float.Parse(mark.Scores2.ToString())) *0.2 + point1*0.6;
                    mark.FinalGrade = Math.Round(FinalGrade, 2);
                    Console.WriteLine(Math.Round(FinalGrade, 2));
                }
                
                string message = "Xác nhận điểm đã nhập?";
                string text = "Nhập điểm cho sinh viên thành công!";

                DialogResult result = MessageBox.Show(message, "Xác nhận điểm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.SaveChanges();
                    MessageBox.Show(text);
                    this.Close();
                }

            }


        }

    }
}
