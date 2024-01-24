using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagement
{
    public partial class FormMain : Form
    {
        StudentManagementEntities db = new StudentManagementEntities();

        private int idUser;
        public FormMain(int id)
        {
            InitializeComponent();
            idUser = id;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb((int)(0.8 * 255), Color.White);

            //textBoxlop.Text = "ĐH10C3";
            var User = db.Account.Find(idUser);
            try
            {
                /*
                textBox2.Text = User.FullName;
                comboBox1.SelectedItem = User.Gender;
                textBox3.Text = User.Phone;
                textBox4.Text = User.Email;*/

                label11.Text = User?.FullName;
                label12.Text = User?.Gender.ToString();
                label13.Text = User?.Phone.ToString();
                label14.Text = User?.Email.ToString();
                label2.Text = User?.DateOfBirth.ToString();
                label10.Text = User?.Role;

                if (User.Role =="Sinh viên")
                {
                    var sinhvien = db.Student.FirstOrDefault(c => c.idUser == User.Id);
                    if(sinhvien.ClassRoom.ClassName != null) {
                        label3.Text = sinhvien.ClassRoom.ClassName;
                    }
                    else
                    {
                        label9.Visible = false;
                        label3.Visible = false;
                    }
                }
                else
                {

                    label9.Visible = false;
                    label3.Visible = false;
                }
            }
            catch
            {
            }
           
        }
    }
}
