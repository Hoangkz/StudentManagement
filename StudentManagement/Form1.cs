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
            addAccount();
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
            var query = db.Account.Where(a => a.Id >= 1);
            dataGridView1.DataSource = query.ToList();
            //tìm theo id
            //var query = db.Accounts.Find(1);

            
        }
        void addAccount()
        {
            //add
            Account account = new Account()
            {
                UserName = "Hoang633",
                PassWord = "Hoang1"
            };

            db.Account.Add(account);
            db.SaveChanges();
        }
        void deleteAccount()
        {
            Account account = db.Account.Where(a => a.Id == 4).SingleOrDefault();
            db.Account.Remove(account);
            db.SaveChanges();
        }

        void editAccount()
        {
            int id = 2;
            Account accounts = db.Account.Find(id);
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
