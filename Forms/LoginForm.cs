using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class LoginForm : Form
    {
        public string UserLogin { get; private set; }
        public int RoleId { get; private set; }
        public int EmployeeId { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT RoleId, EmployeeId FROM Users WHERE Login=@login AND PasswordHash=@pass", conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@pass", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            RoleId = reader.GetInt32(0);
                            EmployeeId = reader.GetInt32(1);
                            UserLogin = login;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!");
                        }
                    }
                }
            }
        }
    }
}