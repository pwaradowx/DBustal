using System;

namespace SalaryApp.Models
{
    public class Bonus
    {
        public int BonusId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime BonusDate { get; set; }
    }
}
