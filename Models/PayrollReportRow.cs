namespace SalaryApp.Models
{
    public class PayrollReportRow
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; }
        public decimal BaseSalary { get; set; }
        public int SickDays { get; set; }
        public decimal Bonus { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
    }
}