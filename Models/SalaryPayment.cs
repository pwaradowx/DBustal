using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.Models
{
    public class SalaryPayment
    {
        public int SalaryPaymentId { get; set; }
        public int EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal SickLeaveLosses { get; set; }
        public decimal Bonuses { get; set; }
        public decimal NDFL { get; set; }
        public string AccountNumber { get; set; }
        public string Status { get; set; } // "успешно", "отклонено"
        public Employee Employee { get; set; }
    }
}
