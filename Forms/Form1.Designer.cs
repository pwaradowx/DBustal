namespace SalaryApp.Forms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEmployees;
        private System.Windows.Forms.ToolStripMenuItem menuPositions;
        private System.Windows.Forms.ToolStripMenuItem menuBonuses;
        private System.Windows.Forms.ToolStripMenuItem menuSickLeaves;
        private System.Windows.Forms.ToolStripMenuItem menuPayroll;
        private System.Windows.Forms.ToolStripMenuItem menuExportExcel;
        private System.Windows.Forms.ToolStripMenuItem menuAddReportForEmployee;
        private System.Windows.Forms.ToolStripMenuItem menuSelfReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPositions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBonuses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSickLeaves = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddReportForEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelfReport = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // menuEmployees
            // 
            this.menuEmployees.Name = "menuEmployees";
            this.menuEmployees.Size = new System.Drawing.Size(100, 24);
            this.menuEmployees.Text = "Сотрудники";
            this.menuEmployees.Click += new System.EventHandler(this.menuEmployees_Click);
            // 
            // menuPositions
            // 
            this.menuPositions.Name = "menuPositions";
            this.menuPositions.Size = new System.Drawing.Size(100, 24);
            this.menuPositions.Text = "Должности";
            this.menuPositions.Click += new System.EventHandler(this.menuPositions_Click);
            // 
            // menuBonuses
            // 
            this.menuBonuses.Name = "menuBonuses";
            this.menuBonuses.Size = new System.Drawing.Size(80, 24);
            this.menuBonuses.Text = "Премии";
            this.menuBonuses.Click += new System.EventHandler(this.menuBonuses_Click);
            // 
            // menuSickLeaves
            // 
            this.menuSickLeaves.Name = "menuSickLeaves";
            this.menuSickLeaves.Size = new System.Drawing.Size(110, 24);
            this.menuSickLeaves.Text = "Больничные";
            this.menuSickLeaves.Click += new System.EventHandler(this.menuSickLeaves_Click);
            // 
            // menuPayroll
            // 
            this.menuPayroll.Name = "menuPayroll";
            this.menuPayroll.Size = new System.Drawing.Size(170, 24);
            this.menuPayroll.Text = "Зарплатная ведомость";
            this.menuPayroll.Click += new System.EventHandler(this.menuPayroll_Click);
            // 
            // menuExportExcel
            // 
            this.menuExportExcel.Name = "menuExportExcel";
            this.menuExportExcel.Size = new System.Drawing.Size(120, 24);
            this.menuExportExcel.Text = "Экспорт в Excel";
            this.menuExportExcel.Click += new System.EventHandler(this.menuExportExcel_Click);
            // 
            // menuAddReportForEmployee
            // 
            this.menuAddReportForEmployee.Name = "menuAddReportForEmployee";
            this.menuAddReportForEmployee.Size = new System.Drawing.Size(210, 24);
            this.menuAddReportForEmployee.Text = "Сдать отчет за сотрудника";
            this.menuAddReportForEmployee.Click += new System.EventHandler(this.menuAddReportForEmployee_Click);
            // 
            // menuSelfReport
            // 
            this.menuSelfReport.Name = "menuSelfReport";
            this.menuSelfReport.Size = new System.Drawing.Size(140, 24);
            this.menuSelfReport.Text = "Сдать отчет";
            this.menuSelfReport.Click += new System.EventHandler(this.menuSelfReport_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Зарплатное приложение";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
        }
    }
}