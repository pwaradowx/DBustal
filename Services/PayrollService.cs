using System;
using System.Collections.Generic;
using System.Linq;
using SalaryApp.Models;
using SalaryApp.Data;

namespace SalaryApp.Services
{
    public class PayrollService
    {
        private readonly EmployeeRepository empRepo = new EmployeeRepository();
        private readonly SickLeaveRepository sickRepo = new SickLeaveRepository();
        private readonly BonusRepository bonusRepo = new BonusRepository();

        public List<PayrollReportRow> GetPayrollReport(string month)
        {
            if (!DateTime.TryParse($"{month}-01", out DateTime monthStart))
                throw new ArgumentException("Месяц должен быть в формате YYYY-MM");
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var employees = empRepo.GetAll();
            var result = new List<PayrollReportRow>();

            foreach (var emp in employees)
            {
                var sickLeaves = sickRepo.GetByEmployee(emp.EmployeeId)
                    .Where(sl => sl.StartDate <= monthEnd && sl.EndDate >= monthStart).ToList();

                int totalDays = (monthEnd - monthStart).Days + 1;
                int sickDays = 0;
                foreach (var sl in sickLeaves)
                {
                    var sickStart = sl.StartDate < monthStart ? monthStart : sl.StartDate;
                    var sickEnd = sl.EndDate > monthEnd ? monthEnd : sl.EndDate;
                    sickDays += (sickEnd - sickStart).Days + 1;
                }
                int workDays = totalDays - sickDays;

                decimal baseSalary = emp.Salary;
                decimal sickPay = (baseSalary / totalDays) * sickDays * 0.5m;
                decimal workPay = (baseSalary / totalDays) * workDays;
                var bonuses = bonusRepo.GetByEmployee(emp.EmployeeId)
                    .Where(b => b.BonusDate >= monthStart && b.BonusDate <= monthEnd).ToList();
                decimal bonusSum = bonuses.Sum(b => b.Amount);

                decimal gross = sickPay + workPay + bonusSum;
                decimal tax = gross * 0.13m;
                decimal net = gross - tax;

                result.Add(new PayrollReportRow
                {
                    EmployeeId = emp.EmployeeId,
                    FullName = emp.FullName,
                    PositionName = emp.PositionName,
                    BaseSalary = baseSalary,
                    SickDays = sickDays,
                    Bonus = bonusSum,
                    GrossSalary = Math.Round(gross, 2),
                    Tax = Math.Round(tax, 2),
                    NetSalary = Math.Round(net, 2)
                });
            }
            return result;
        }
    }
}
