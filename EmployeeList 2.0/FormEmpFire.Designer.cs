namespace EmployeeList_2._0
{
    partial class FormEmpFire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBoxEmps = new System.Windows.Forms.ComboBox();
            this.LabelEmp = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxEmps
            // 
            this.ComboBoxEmps.FormattingEnabled = true;
            this.ComboBoxEmps.Location = new System.Drawing.Point(15, 28);
            this.ComboBoxEmps.Name = "ComboBoxEmps";
            this.ComboBoxEmps.Size = new System.Drawing.Size(224, 21);
            this.ComboBoxEmps.TabIndex = 0;
            this.ComboBoxEmps.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEmps_SelectedIndexChanged);
            // 
            // LabelEmp
            // 
            this.LabelEmp.AutoSize = true;
            this.LabelEmp.Location = new System.Drawing.Point(12, 12);
            this.LabelEmp.Name = "LabelEmp";
            this.LabelEmp.Size = new System.Drawing.Size(133, 13);
            this.LabelEmp.TabIndex = 1;
            this.LabelEmp.Text = "Работающие сотрудники";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(60, 128);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(126, 26);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "Уволить";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FormEmpFire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 175);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.LabelEmp);
            this.Controls.Add(this.ComboBoxEmps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEmpFire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Уволить сотрудника";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEmpFire_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxEmps;
        private System.Windows.Forms.Label LabelEmp;
        private System.Windows.Forms.Button ButtonOK;
    }
}