using SalaryApp.Data;
using SalaryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class ReportForm : Form
    {
        private int _roleId;
        private int _employeeId;

        public ReportForm(int roleId, int employeeId)
        {
            InitializeComponent();
            _roleId = roleId;
            _employeeId = employeeId;
            SetupEmployeeCombo();
        }

        private EmployeeRepository empRepo = new EmployeeRepository();
        private void SetupEmployeeCombo()
        {
            // Всегда показываем всех сотрудников и разрешаем выбор
            comboBoxEmployee.DataSource = empRepo.GetAllShort();
            comboBoxEmployee.DisplayMember = "FullName";
            comboBoxEmployee.ValueMember = "EmployeeId";
            comboBoxEmployee.Enabled = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedEmployeeId = (int)comboBoxEmployee.SelectedValue;
            int month = (int)numericUpDownMonth.Value;
            int year = (int)numericUpDownYear.Value;
            string reportText = textBoxReport.Text.Trim();

            if (string.IsNullOrWhiteSpace(reportText))
            {
                MessageBox.Show("Текст отчета не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ok = ReportRepository.AddOrUpdateReport(
                selectedEmployeeId,
                month,
                year,
                reportText,
                DateTime.Now,
                _employeeId // кто создал
            );

            if (ok)
            {
                MessageBox.Show("Отчет успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}