using System;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class Form1 : Form
    {
        private int _roleId;
        private int _employeeId;

        public Form1(int roleId, int employeeId)
        {
            InitializeComponent();
            _roleId = roleId;
            _employeeId = employeeId;
            SetupMenu();
        }

        private void SetupMenu()
        {
            menuStrip1.Items.Clear();

            // Для админа (RoleId == 1): все пункты + отчет за сотрудника
            if (_roleId == 1)
            {
                menuStrip1.Items.Add(menuEmployees);
                menuStrip1.Items.Add(menuPositions);
                menuStrip1.Items.Add(menuBonuses);
                menuStrip1.Items.Add(menuSickLeaves);
                menuStrip1.Items.Add(menuPayroll);
                menuStrip1.Items.Add(menuAddReportForEmployee);
            }
            // Для менеджера (RoleId == 2): все пункты кроме должностей и сдачи отчета за сотрудника
            else if (_roleId == 2)
            {
                menuStrip1.Items.Add(menuEmployees);
                menuStrip1.Items.Add(menuBonuses);
                menuStrip1.Items.Add(menuSickLeaves);
                menuStrip1.Items.Add(menuPayroll);
            }
            // Для сотрудника (RoleId == 3): только сдача личного отчета
            else if (_roleId == 3)
            {
                menuStrip1.Items.Add(menuSelfReport);
            }
        }

        // Открытие форм по меню
        private void menuEmployees_Click(object sender, EventArgs e)
        {
            var f = new EmployeeForm(_roleId);
            f.ShowDialog();
        }

        private void menuPositions_Click(object sender, EventArgs e)
        {
            var f = new PositionForm(_roleId);
            f.ShowDialog();
        }

        private void menuBonuses_Click(object sender, EventArgs e)
        {
            var f = new BonusForm(_roleId);
            f.ShowDialog();
        }

        private void menuSickLeaves_Click(object sender, EventArgs e)
        {
            var f = new SickLeaveForm(_roleId);
            f.ShowDialog();
        }

        private void menuPayroll_Click(object sender, EventArgs e)
        {
            var f = new PayrollReportForm(_roleId, _employeeId, false);
            f.ShowDialog();
        }

        private void menuExportExcel_Click(object sender, EventArgs e)
        {
            var f = new PayrollReportForm(_roleId, _employeeId, true);
            f.ShowDialog();
        }

        private void menuAddReportForEmployee_Click(object sender, EventArgs e)
        {
            var f = new ReportForm(_roleId, _employeeId);
            f.ShowDialog();
        }

        private void menuSelfReport_Click(object sender, EventArgs e)
        {
            var f = new ReportForm(_roleId, _employeeId);
            f.ShowDialog();
        }
    }
}