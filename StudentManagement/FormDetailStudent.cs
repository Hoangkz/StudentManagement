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
    public partial class FormDetailStudent : Form
    {
        DataGridViewRow dataColumn = null;
        public FormDetailStudent(DataGridViewRow data)
        {
            dataColumn = data;
            InitializeComponent();
        }

        private void DetailStudent_Load(object sender, EventArgs e)
        {
            this.Text = dataColumn.Cells[1].Value.ToString();
            textBox1.Text = dataColumn.Cells[1].Value.ToString();
        }
    }
}
