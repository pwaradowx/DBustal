using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class EditBonusForm : Form
    {
        private int? bonusId = null;

        public EditBonusForm(int? id = null)
        {
            InitializeComponent();
            LoadEmployees();
            if (id.HasValue)
            {
                this.bonusId = id;
                LoadBonus(id.Value);
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

        private void LoadBonus(int id)
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT EmployeeId, Amount, Description, BonusDate FROM Bonuses WHERE BonusId=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmbEmployee.SelectedValue = (int)reader["EmployeeId"];
                            nudAmount.Value = Convert.ToDecimal(reader["Amount"]);
                            txtDescription.Text = reader["Description"].ToString();
                            dtpBonusDate.Value = Convert.ToDateTime(reader["BonusDate"]);
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(cmbEmployee.SelectedValue);
            decimal amount = nudAmount.Value;
            string desc = txtDescription.Text.Trim();
            DateTime bdate = dtpBonusDate.Value.Date;

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql;
                if (bonusId.HasValue)
                    sql = @"UPDATE Bonuses SET EmployeeId=@emp, Amount=@amount, Description=@desc, BonusDate=@bdate WHERE BonusId=@id";
                else
                    sql = @"INSERT INTO Bonuses (EmployeeId, Amount, Description, BonusDate) VALUES (@emp, @amount, @desc, @bdate)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp", empId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@bdate", bdate);
                    if (bonusId.HasValue)
                        cmd.Parameters.AddWithValue("@id", bonusId.Value);
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