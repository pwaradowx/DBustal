using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class SickLeaveForm : Form
    {
        private readonly int roleId;

        public SickLeaveForm(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            LoadSickLeaves();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = (roleId == 1 || roleId == 2);
        }

        private void LoadSickLeaves()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT s.SickLeaveId, e.FullName, s.StartDate, s.EndDate
                               FROM SickLeaves s
                               JOIN Employees e ON s.EmployeeId = e.EmployeeId";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSickLeaves.DataSource = dt;
                }
            }
            dgvSickLeaves.Columns["SickLeaveId"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditSickLeaveForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadSickLeaves();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSickLeaves.CurrentRow == null)
                return;
            int id = (int)dgvSickLeaves.CurrentRow.Cells["SickLeaveId"].Value;
            var form = new EditSickLeaveForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadSickLeaves();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSickLeaves.CurrentRow == null)
                return;
            int id = (int)dgvSickLeaves.CurrentRow.Cells["SickLeaveId"].Value;
            if (MessageBox.Show("Удалить выбранный больничный?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(DB.ConnectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM SickLeaves WHERE SickLeaveId=@id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadSickLeaves();
            }
        }
    }
}