using System.Collections.Generic;

namespace SalaryApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public decimal Salary { get; set; }
        public string MaritalStatus { get; set; }
        public int ChildrenCount { get; set; }
        public string AccountNumber { get; set; } // реквизиты счета
        public string Phone { get; set; }
        public string Email { get; set; }
        // навигационные свойства
        public Position Position { get; set; }
        public List<SalaryPayment> SalaryPayments { get; set; }
    }
}