using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class EditSickLeaveForm : Form
    {
        private int? sickLeaveId = null;

        public EditSickLeaveForm(int? id = null)
        {
            InitializeComponent();
            LoadEmployees();
            if (id.HasValue)
            {
                this.sickLeaveId = id;
                LoadSickLeave(id.Value);
            }
        }

        private void LoadEmployees()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT EmployeeId, FullName FROM Employees";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbEmployee.DataSource = dt;
                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "EmployeeId";
                }
            }
        }

        private void LoadSickLeave(int id)
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT EmployeeId, StartDate, EndDate FROM SickLeaves WHERE SickLeaveId=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmbEmployee.SelectedValue = (int)reader["EmployeeId"];
                            dtpStart.Value = Convert.ToDateTime(reader["StartDate"]);
                            dtpEnd.Value = Convert.ToDateTime(reader["EndDate"]);
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(cmbEmployee.SelectedValue);
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql;
                if (sickLeaveId.HasValue)
                    sql = @"UPDATE SickLeaves SET EmployeeId=@emp, StartDate=@start, EndDate=@end WHERE SickLeaveId=@id";
                else
                    sql = @"INSERT INTO SickLeaves (EmployeeId, StartDate, EndDate) VALUES (@emp, @start, @end)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp", empId);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (sickLeaveId.HasValue)
                        cmd.Parameters.AddWithValue("@id", sickLeaveId.Value);
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