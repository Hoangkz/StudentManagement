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
    public partial class FormListSubject : Form
    {
        public FormListSubject()
        {
            InitializeComponent();
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataDSMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new FormSubject().ShowDialog();
        }
    }
}
