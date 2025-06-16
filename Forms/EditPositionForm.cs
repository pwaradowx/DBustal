using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class EditPositionForm : Form
    {
        private int? positionId = null;

        public EditPositionForm(int? id = null)
        {
            InitializeComponent();
            if (id.HasValue)
            {
                this.positionId = id;
                LoadPosition(id.Value);
            }
        }

        private void LoadPosition(int id)
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT PositionName FROM Positions WHERE PositionId=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPositionName.Text = reader["PositionName"].ToString();
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = txtPositionName.Text.Trim();

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql;
                if (positionId.HasValue)
                    sql = @"UPDATE Positions SET PositionName=@name WHERE PositionId=@id";
                else
                    sql = @"INSERT INTO Positions (PositionName) VALUES (@name)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    if (positionId.HasValue)
                        cmd.Parameters.AddWithValue("@id", positionId.Value);
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