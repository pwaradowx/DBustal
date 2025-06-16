using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SalaryApp.Models;

namespace SalaryApp.Data
{
    public class EmployeeRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SalaryDb"].ConnectionString;

        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT e.EmployeeId, e.FullName, e.PositionId, e.Salary, e.MaritalStatus, e.ChildrenCount, p.PositionName
                    FROM Employees e JOIN Positions p ON e.PositionId = p.PositionId", conn);
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Employee
                    {
                        EmployeeId = (int)r["EmployeeId"],
                        FullName = r["FullName"].ToString(),
                        PositionId = (int)r["PositionId"],
                        Salary = (decimal)r["Salary"],
                        MaritalStatus = r["MaritalStatus"].ToString(),
                        ChildrenCount = (int)r["ChildrenCount"],
                        PositionName = r["PositionName"].ToString()
                    });
                }
            }
            return list;
        }

        public List<Employee> GetAllShort()
        {
            var list = new List<Employee>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT EmployeeId, FullName FROM Employees", conn);
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Employee
                    {
                        EmployeeId = (int)r["EmployeeId"],
                        FullName = r["FullName"].ToString()
                    });
                }
            }
            return list;
        }

        public void Add(Employee e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO Employees (FullName, PositionId, Salary, MaritalStatus, ChildrenCount)
                    VALUES (@FullName, @PositionId, @Salary, @MaritalStatus, @ChildrenCount)", conn);
                cmd.Parameters.AddWithValue("@FullName", e.FullName);
                cmd.Parameters.AddWithValue("@PositionId", e.PositionId);
                cmd.Parameters.AddWithValue("@Salary", e.Salary);
                cmd.Parameters.AddWithValue("@MaritalStatus", e.MaritalStatus);
                cmd.Parameters.AddWithValue("@ChildrenCount", e.ChildrenCount);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"UPDATE Employees SET FullName=@FullName, PositionId=@PositionId, Salary=@Salary, MaritalStatus=@MaritalStatus, ChildrenCount=@ChildrenCount
                    WHERE EmployeeId=@EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", e.EmployeeId);
                cmd.Parameters.AddWithValue("@FullName", e.FullName);
                cmd.Parameters.AddWithValue("@PositionId", e.PositionId);
                cmd.Parameters.AddWithValue("@Salary", e.Salary);
                cmd.Parameters.AddWithValue("@MaritalStatus", e.MaritalStatus);
                cmd.Parameters.AddWithValue("@ChildrenCount", e.ChildrenCount);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int employeeId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeId=@EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}