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

            // ���� ����� ����� �����������
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // ����� ��������� ����� � ������ ������� ����� � �����������
                    Application.Run(new Form1(
                        loginForm.RoleId,
                        loginForm.EmployeeId
                    ));
                }
            }
        }
    }
}