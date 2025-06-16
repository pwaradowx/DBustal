using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SalaryApp.Models;

namespace SalaryApp.Data
{
    public class SickLeaveRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Add(SickLeave s)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO SickLeaves (EmployeeId, StartDate, EndDate) VALUES (@EmployeeId, @StartDate, @EndDate)", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", s.EmployeeId);
                cmd.Parameters.AddWithValue("@StartDate", s.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", s.EndDate);
                cmd.ExecuteNonQuery();
            }
        }

        public List<SickLeave> GetByEmployee(int employeeId)
        {
            var list = new List<SickLeave>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT SickLeaveId, EmployeeId, StartDate, EndDate FROM SickLeaves WHERE EmployeeId=@EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new SickLeave
                    {
                        SickLeaveId = (int)r["SickLeaveId"],
                        EmployeeId = (int)r["EmployeeId"],
                        StartDate = (DateTime)r["StartDate"],
                        EndDate = (DateTime)r["EndDate"]
                    });
                }
            }
            return list;
        }
    }
}