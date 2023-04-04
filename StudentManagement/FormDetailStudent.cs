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
            var query = from c in db.ClassRoom 
                        select new { id = c.IdClass, Class= c.ClassName };
            Console.WriteLine(query.ToArray());
            for (int i = 0; i < query.Count(); i++)
            {
                ArrClass[i] = query.ToArray()[i].id;
                comboBox2.Items.Add(query.ToArray()[i].Class);
            }


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
    }
}
