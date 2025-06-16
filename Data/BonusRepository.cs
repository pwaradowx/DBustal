using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SalaryApp.Models;

namespace SalaryApp.Data
{
    public class BonusRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Add(Bonus b)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Bonuses (EmployeeId, Amount, Description, BonusDate) VALUES (@EmployeeId, @Amount, @Description, @BonusDate)", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", b.EmployeeId);
                cmd.Parameters.AddWithValue("@Amount", b.Amount);
                cmd.Parameters.AddWithValue("@Description", b.Description);
                cmd.Parameters.AddWithValue("@BonusDate", b.BonusDate);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Bonus> GetByEmployee(int employeeId)
        {
            var list = new List<Bonus>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT BonusId, EmployeeId, Amount, Description, BonusDate FROM Bonuses WHERE EmployeeId=@EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Bonus
                    {
                        BonusId = (int)r["BonusId"],
                        EmployeeId = (int)r["EmployeeId"],
                        Amount = (decimal)r["Amount"],
                        Description = r["Description"].ToString(),
                        BonusDate = (DateTime)r["BonusDate"]
                    });
                }
            }
            return list;
        }
    }
}
