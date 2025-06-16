using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class EditEmployeeForm : Form
    {
        private int? employeeId = null;

        public EditEmployeeForm(int? id = null)
        {
            InitializeComponent();
            LoadPositions();
            if (id.HasValue)
            {
                this.employeeId = id;
                LoadEmployee(id.Value);
            }
        }

        private void LoadPositions()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT PositionId, PositionName FROM Positions";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbPosition.DataSource = dt;
                    cmbPosition.DisplayMember = "PositionName";
                    cmbPosition.ValueMember = "PositionId";
                }
            }
        }

        private void LoadEmployee(int id)
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT FullName, PositionId, Salary, MaritalStatus, ChildrenCount FROM Employees WHERE EmployeeId=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            cmbPosition.SelectedValue = (int)reader["PositionId"];
                            nudSalary.Value = Convert.ToDecimal(reader["Salary"]);
                            cmbMarital.Text = reader["MaritalStatus"].ToString();
                            nudChildren.Value = Convert.ToInt32(reader["ChildrenCount"]);
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            int positionId = Convert.ToInt32(cmbPosition.SelectedValue);
            decimal salary = nudSalary.Value;
            string marital = cmbMarital.Text;
            int children = (int)nudChildren.Value;

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql;
                if (employeeId.HasValue)
                {
                    // UPDATE
                    sql = @"UPDATE Employees SET FullName=@name, PositionId=@pos, Salary=@salary, MaritalStatus=@mar, ChildrenCount=@kids WHERE EmployeeId=@id";
                }
                else
                {
                    // INSERT
                    sql = @"INSERT INTO Employees (FullName, PositionId, Salary, MaritalStatus, ChildrenCount)
                            VALUES (@name, @pos, @salary, @mar, @kids)";
                }
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", fullName);
                    cmd.Parameters.AddWithValue("@pos", positionId);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@mar", marital);
                    cmd.Parameters.AddWithValue("@kids", children);
                    if (employeeId.HasValue)
                        cmd.Parameters.AddWithValue("@id", employeeId.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}