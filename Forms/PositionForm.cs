using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class PositionForm : Form
    {
        private readonly int roleId;

        public PositionForm(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            LoadPositions();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = (roleId == 1);
        }

        private void LoadPositions()
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT PositionId, PositionName FROM Positions";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPositions.DataSource = dt;
                }
            }
            dgvPositions.Columns["PositionId"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditPositionForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadPositions();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.CurrentRow == null)
                return;
            int id = (int)dgvPositions.CurrentRow.Cells["PositionId"].Value;
            var form = new EditPositionForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadPositions();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.CurrentRow == null)
                return;
            int id = (int)dgvPositions.CurrentRow.Cells["PositionId"].Value;
            if (MessageBox.Show("Удалить выбранную должность?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(DB.ConnectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Positions WHERE PositionId=@id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadPositions();
            }
        }
    }
}