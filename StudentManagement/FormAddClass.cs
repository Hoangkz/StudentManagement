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
    public partial class FormAddClass : Form
    {

        StudentManagementEntities db = new StudentManagementEntities();

        public FormAddClass()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int ID = int.Parse(txtClassIdAdd.Text);
            string className = txtClassNameAdd.Text;
            string teacherName = txtTeacherNameAdd.Text;


            if (className == "" || teacherName == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo !!!");
            }
            else
            {
                
                var classcheck = (from c in db.ClassRoom
                                   join u in db.Teacher on c.IdTeacher equals u.IdTeacher
                                   join acc in db.Account on u.idUser equals acc.Id
                                   where c.ClassName == className
                                   select c );

                
                var teachername = (from c in db.ClassRoom
                                                  join u in db.Teacher on c.IdTeacher equals u.IdTeacher
                                                  join acc in db.Account on u.idUser equals acc.Id
                                                  where acc.FullName == teacherName
                                                  select c);


                if (classcheck.Any() )
                {
                    MessageBox.Show("Lớp đã có giảng viên", "Thông báo !!!", MessageBoxButtons.OK);
                }
                else if (teachername.Any())
                {
                    MessageBox.Show("Giảng viên đã được xếp lớp", "Thông báo !!!",MessageBoxButtons.OK);
                }
                else
                {

                   

                    ClassRoom newclass = new ClassRoom
                    {
                        ClassName = className
                    };
                    db.ClassRoom.Add(newclass);
                    db.SaveChanges();

                    Account teachName = new Account
                    {
                        FullName = teacherName
                    };
                    db.Account.Add(teachName);
                    db.SaveChanges();

                    MessageBox.Show("xếp lớp mới thành công ", "Thông báo");
                    this.Close();

                }
                

            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ các thay đổi?", "Xác nhận", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                // Hủy bỏ tất cả các thay đổi
                this.DialogResult = DialogResult.Cancel;
                // Đóng cửa sổ hiện tại
                this.Close();
            }
        }
    }
}
