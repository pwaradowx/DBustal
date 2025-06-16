namespace SalaryApp.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.NumericUpDown numericUpDownMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.Button buttonSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelEmployee = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.numericUpDownMonth = new System.Windows.Forms.NumericUpDown();
            this.labelYear = new System.Windows.Forms.Label();
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.labelReport = new System.Windows.Forms.Label();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Location = new System.Drawing.Point(25, 20);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(107, 17);
            this.labelEmployee.Text = "Сотрудник:";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployee.Location = new System.Drawing.Point(150, 17);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(250, 24);
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(25, 60);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(54, 17);
            this.labelMonth.Text = "Месяц:";
            // 
            // numericUpDownMonth
            // 
            this.numericUpDownMonth.Location = new System.Drawing.Point(150, 57);
            this.numericUpDownMonth.Minimum = 1;
            this.numericUpDownMonth.Maximum = 12;
            this.numericUpDownMonth.Name = "numericUpDownMonth";
            this.numericUpDownMonth.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownMonth.Value = System.DateTime.Now.Month;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(240, 60);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(34, 17);
            this.labelYear.Text = "Год:";
            // 
            // numericUpDownYear
            // 
            this.numericUpDownYear.Location = new System.Drawing.Point(280, 57);
            this.numericUpDownYear.Minimum = 2000;
            this.numericUpDownYear.Maximum = 2100;
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.Size = new System.Drawing.Size(70, 22);
            this.numericUpDownYear.Value = System.DateTime.Now.Year;
            // 
            // labelReport
            // 
            this.labelReport.AutoSize = true;
            this.labelReport.Location = new System.Drawing.Point(25, 100);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(102, 17);
            this.labelReport.Text = "Текст отчета:";
            // 
            // textBoxReport
            // 
            this.textBoxReport.Location = new System.Drawing.Point(28, 120);
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.Size = new System.Drawing.Size(372, 120);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(150, 260);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(130, 30);
            this.buttonSubmit.Text = "Сдать отчет";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(430, 310);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.numericUpDownMonth);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.numericUpDownYear);
            this.Controls.Add(this.labelReport);
            this.Controls.Add(this.textBoxReport);
            this.Controls.Add(this.buttonSubmit);
            this.Name = "ReportForm";
            this.Text = "Сдача отчета";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}