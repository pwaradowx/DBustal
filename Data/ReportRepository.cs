using System;
using System.Data.SqlClient;

namespace SalaryApp.Repositories
{
    public static class ReportRepository
    {
        public static bool AddOrUpdateReport(int employeeId, int month, int year, string reportText, DateTime createdAt, int createdBy)
        {
            using (var conn = new SqlConnection(DB.ConnectionString))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();

                // Проверим, есть ли уже отчет за этот месяц/год
                cmd.CommandText = @"SELECT COUNT(*) FROM Reports WHERE EmployeeId=@empId AND ReportMonth=@month AND ReportYear=@year";
                cmd.Parameters.AddWithValue("@empId", employeeId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Обновить
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"UPDATE Reports SET ReportText=@text, CreatedAt=@dt, CreatedBy=@createdBy
                        WHERE EmployeeId=@empId AND ReportMonth=@month AND ReportYear=@year";
                    cmd.Parameters.AddWithValue("@text", reportText);
                    cmd.Parameters.AddWithValue("@dt", createdAt);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@empId", employeeId);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    return cmd.ExecuteNonQuery() > 0;
                }
                else
                {
                    // Вставить
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO Reports (EmployeeId, ReportMonth, ReportYear, ReportText, CreatedAt, CreatedBy)
                        VALUES (@empId, @month, @year, @text, @dt, @createdBy)";
                    cmd.Parameters.AddWithValue("@empId", employeeId);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@text", reportText);
                    cmd.Parameters.AddWithValue("@dt", createdAt);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}