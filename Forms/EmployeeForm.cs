using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly int roleId;

        public EmployeeForm(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                // SQL-запрос с подстановкой наименования должности
                string sql = @"SELECT e.EmployeeId, e.FullName, p.PositionName, e.Salary, e.MaritalStatus, e.ChildrenCount
                               FROM Employees e
                               JOIN Positions p ON e.PositionId = p.PositionId";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmployees.DataSource = dt;
                }
            }
            dgvEmployees.Columns["EmployeeId"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditEmployeeForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadEmployees();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
                return;
            int id = (int)dgvEmployees.CurrentRow.Cells["EmployeeId"].Value;
            var form = new EditEmployeeForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
                return;
            int id = (int)dgvEmployees.CurrentRow.Cells["EmployeeId"].Value;
            if (MessageBox.Show("Удалить выбранного сотрудника?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(DB.ConnectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Employees WHERE EmployeeId=@id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadEmployees();
            }
        }
    }
}