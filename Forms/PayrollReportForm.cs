using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SalaryApp.Forms
{
    public partial class PayrollReportForm : Form
    {
        private int _roleId;
        private int _employeeId;
        private bool _excelExport;

        public PayrollReportForm(int roleId, int employeeId, bool excelExport)
        {
            InitializeComponent();
            _roleId = roleId;
            _employeeId = employeeId;
            _excelExport = excelExport;
            for (int m = 1; m <= 12; m++) cmbMonth.Items.Add(m);
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            int year = DateTime.Now.Year;
            for (int y = year - 1; y <= year + 1; y++) cmbYear.Items.Add(y);
            cmbYear.SelectedItem = year;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int month = (int)cmbMonth.SelectedItem;
            int year = (int)cmbYear.SelectedItem;

            using (var conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                string sql = @"
SELECT
    e.FullName AS [ФИО],
    p.PositionName AS [Должность],
    e.Salary AS [Оклад],
    ISNULL(s.SickDays, 0) AS [Дней больничных],
    ISNULL(b.Bonuses, 0) AS [Премии],
    ROUND(ISNULL(s.SickDays,0)*(e.Salary/30.0)*0.5, 2) AS [Потери из-за больничного],
    ROUND(e.Salary - (ISNULL(s.SickDays,0)*(e.Salary/30.0)*0.5) + ISNULL(b.Bonuses,0), 2) AS [Итоговая ЗП],
    ROUND((e.Salary - (ISNULL(s.SickDays,0)*(e.Salary/30.0)*0.5) + ISNULL(b.Bonuses,0)) * 0.87, 2) AS [ЗП после налога],
    CASE WHEN r.ReportId IS NULL THEN N'отчет отсутствует!' ELSE N'отчет сдан' END AS [Отчет]
FROM Employees e
JOIN Positions p ON e.PositionId = p.PositionId
LEFT JOIN (
    SELECT EmployeeId, SUM(DATEDIFF(DAY, StartDate, EndDate) + 1) AS SickDays
    FROM SickLeaves
    WHERE MONTH(StartDate) = @month AND YEAR(StartDate) = @year
    GROUP BY EmployeeId
) s ON e.EmployeeId = s.EmployeeId
LEFT JOIN (
    SELECT EmployeeId, SUM(Amount) AS Bonuses
    FROM Bonuses
    WHERE MONTH(BonusDate) = @month AND YEAR(BonusDate) = @year
    GROUP BY EmployeeId
) b ON e.EmployeeId = b.EmployeeId
LEFT JOIN (
    SELECT EmployeeId, ReportId
    FROM Reports
    WHERE ReportMonth = @month AND ReportYear = @year
) r ON e.EmployeeId = r.EmployeeId
ORDER BY e.FullName
";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReport.DataSource = dt;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Экспорт в Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Сохранить как Excel файл"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Отчет");

                            // Заголовки столбцов
                            for (int col = 0; col < dgvReport.Columns.Count; col++)
                            {
                                worksheet.Cell(1, col + 1).Value = dgvReport.Columns[col].HeaderText;
                            }

                            // Данные
                            for (int row = 0; row < dgvReport.Rows.Count; row++)
                            {
                                // Пропускаем служебную пустую строку в конце, если AllowUserToAddRows == true
                                if (dgvReport.AllowUserToAddRows && row == dgvReport.Rows.Count - 1)
                                    break;

                                for (int col = 0; col < dgvReport.Columns.Count; col++)
                                {
                                    worksheet.Cell(row + 2, col + 1).Value = dgvReport.Rows[row].Cells[col].Value?.ToString();
                                }
                            }

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Данные успешно экспортированы в Excel!", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при экспорте:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReport.Columns[e.ColumnIndex].HeaderText == "Отчет"
                && e.Value?.ToString().Contains("отчет отсутствует") == true)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }
    }
}