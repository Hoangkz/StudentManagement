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
    public partial class Form1 : Form
    {
        StudentManagementEntities  db = new StudentManagementEntities();
        public Form1()
        {
            InitializeComponent();
            editAccount();
            loaddata();
        }
        #region methods
        void loaddata()
        {

            /*
            var query = from c in db.Accounts 
                        where c.Id == 1 || c.Id ==2
                        select new { Id = c.Id, UserName = c.UserName };
            */
            var query = db.Accounts.Where(a => a.Id >= 1);
            dataGridView1.DataSource = query.ToList();
            //tìm theo id
            //var query = db.Accounts.Find(1);

            
        }
        void addAccount()
        {
            //add
            Accounts accounts = new Accounts()
            {
                UserName = "Hoang6",
                PassWord = "Hoang1"
            };

            db.Accounts.Add(accounts);
            db.SaveChanges();
        }
        void deleteAccount()
        {
            Accounts accounts = db.Accounts.Where(a => a.Id == 4).SingleOrDefault();
            db.Accounts.Remove(accounts);
            db.SaveChanges();
        }

        void editAccount()
        {
            int id = 2;
            Accounts accounts = db.Accounts.Find(id);
            accounts.PassWord = "New PassWord";
            accounts.UserName = "New UserName";
            db.SaveChanges();
        }
        #endregion

        #region events

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
