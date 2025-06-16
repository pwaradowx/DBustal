using System;

namespace SalaryApp.Models
{
    public class SickLeave
    {
        public int SickLeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}