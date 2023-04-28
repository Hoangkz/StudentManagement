using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Properties;

namespace StudentManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string DB_HOST = string.Format(Settings.Default.DB_HOST);
            string connectionString = string.Format(ConfigurationManager.ConnectionStrings["StudentManagementEntities"].ConnectionString, DB_HOST);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Lưu lại giá trị chuỗi kết nối mới vào file app.config
            config.ConnectionStrings.ConnectionStrings["StudentManagementEntities"].ConnectionString = connectionString;
            config.Save(ConfigurationSaveMode.Modified, true);

            // Tải lại các giá trị cấu hình mới
            ConfigurationManager.RefreshSection("connectionStrings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormStudentManagement(3036));
            Application.Run(new FormLogin());
        }
    }
}
