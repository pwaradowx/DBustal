using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SalaryApp.Models;

namespace SalaryApp.Data
{
    public class PositionRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Position> GetAll()
        {
            var list = new List<Position>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT PositionId, PositionName FROM Positions", conn);
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Position
                    {
                        PositionId = (int)r["PositionId"],
                        PositionName = r["PositionName"].ToString()
                    });
                }
            }
            return list;
        }
    }
}