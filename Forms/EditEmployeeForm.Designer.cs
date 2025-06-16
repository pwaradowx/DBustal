namespace SalaryApp.Forms
{
    partial class EditEmployeeForm
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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.cmbMarital = new System.Windows.Forms.ComboBox();
            this.nudChildren = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(140, 20);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(250, 22);
            this.txtFullName.TabIndex = 0;
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Location = new System.Drawing.Point(140, 55);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(250, 24);
            this.cmbPosition.TabIndex = 1;
            // 
            // nudSalary
            // 
            this.nudSalary.Location = new System.Drawing.Point(140, 95);
            this.nudSalary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(120, 22);
            this.nudSalary.TabIndex = 2;
            this.nudSalary.DecimalPlaces = 2;
            // 
            // cmbMarital
            // 
            this.cmbMarital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarital.Items.AddRange(new object[] { "Женат", "Не женат", "Замужем", "Не замужем", "Холост" });
            this.cmbMarital.Location = new System.Drawing.Point(140, 135);
            this.cmbMarital.Name = "cmbMarital";
            this.cmbMarital.Size = new System.Drawing.Size(120, 24);
            this.cmbMarital.TabIndex = 3;
            // 
            // nudChildren
            // 
            this.nudChildren.Location = new System.Drawing.Point(140, 175);
            this.nudChildren.Name = "nudChildren";
            this.nudChildren.Size = new System.Drawing.Size(50, 22);
            this.nudChildren.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "ФИО:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.Text = "Должность:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.Text = "Оклад:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 135);
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.Text = "Сем. положение:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 175);
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.Text = "Детей:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(70, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Сохранить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditEmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 280);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudChildren);
            this.Controls.Add(this.cmbMarital);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.txtFullName);
            this.Name = "EditEmployeeForm";
            this.Text = "Сотрудник";
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.NumericUpDown nudSalary;
        private System.Windows.Forms.ComboBox cmbMarital;
        private System.Windows.Forms.NumericUpDown nudChildren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}