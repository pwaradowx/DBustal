using SalaryApp.Forms;
using System;
using System.Windows.Forms;

namespace SalaryApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ¬ход через форму авторизации
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // ѕосле успешного входа Ч запуск главной формы с параметрами
                    Application.Run(new Form1(
                        loginForm.RoleId,
                        loginForm.EmployeeId
                    ));
                }
            }
        }
    }
}