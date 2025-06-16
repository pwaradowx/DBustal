using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class BonusForm : Form
    {
        private readonly int roleId;

        public BonusForm(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            LoadBonuses();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = (roleId == 1 || roleId == 2);
        }

        private void LoadBonuses()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT b.BonusId, e.FullName, b.Amount, b.Description, b.BonusDate
                               FROM Bonuses b
                               JOIN Employees e ON b.EmployeeId = e.EmployeeId";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBonuses.DataSource = dt;
                }
            }
            dgvBonuses.Columns["BonusId"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditBonusForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadBonuses();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBonuses.CurrentRow == null)
                return;
            int id = (int)dgvBonuses.CurrentRow.Cells["BonusId"].Value;
            var form = new EditBonusForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBonuses();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBonuses.CurrentRow == null)
                return;
            int id = (int)dgvBonuses.CurrentRow.Cells["BonusId"].Value;
            if (MessageBox.Show("Удалить выбранную премию?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(DB.ConnectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Bonuses WHERE BonusId=@id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadBonuses();
            }
        }
    }
}
