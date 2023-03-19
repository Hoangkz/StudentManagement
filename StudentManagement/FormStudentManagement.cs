using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormStudentManagement : Form
    {
        private int idUser;
        public FormStudentManagement(int id)
        {
            idUser = id;
            InitializeComponent();
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AddForm(Form form)
        {
            this.pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Text = form.Text;
            this.pnlContent.Controls.Add(form);
            form.Show();
        }
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User user = new User(idUser);
            //AddForm(user);
            user.ShowDialog();
        }
    }
}
