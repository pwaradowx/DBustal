namespace SalaryApp.Forms
{
    partial class EditBonusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpBonusDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(140, 20);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(250, 24);
            this.cmbEmployee.TabIndex = 0;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(140, 60);
            this.nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 22);
            this.nudAmount.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(140, 100);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 22);
            this.txtDescription.TabIndex = 2;
            // 
            // dtpBonusDate
            // 
            this.dtpBonusDate.Location = new System.Drawing.Point(140, 140);
            this.dtpBonusDate.Name = "dtpBonusDate";
            this.dtpBonusDate.Size = new System.Drawing.Size(150, 22);
            this.dtpBonusDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "Сотрудник:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.Text = "Сумма:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.Text = "Описание:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.Text = "Дата:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(70, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 35);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Сохранить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditBonusForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpBonusDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.cmbEmployee);
            this.Name = "EditBonusForm";
            this.Text = "Премия/надбавка";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpBonusDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}