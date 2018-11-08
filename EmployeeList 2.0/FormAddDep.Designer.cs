namespace EmployeeList_2._0
{
    partial class FormAddDep
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
            this.LabelDepName = new System.Windows.Forms.Label();
            this.TextBoxDepName = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelDepName
            // 
            this.LabelDepName.AutoSize = true;
            this.LabelDepName.Location = new System.Drawing.Point(12, 26);
            this.LabelDepName.Name = "LabelDepName";
            this.LabelDepName.Size = new System.Drawing.Size(95, 13);
            this.LabelDepName.TabIndex = 0;
            this.LabelDepName.Text = "Название отдела";
            // 
            // TextBoxDepName
            // 
            this.TextBoxDepName.Location = new System.Drawing.Point(15, 61);
            this.TextBoxDepName.Name = "TextBoxDepName";
            this.TextBoxDepName.Size = new System.Drawing.Size(184, 20);
            this.TextBoxDepName.TabIndex = 1;
            this.TextBoxDepName.TextChanged += new System.EventHandler(this.TextBoxDepName_TextChanged);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(12, 130);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "Добавить";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(124, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormAddDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 158);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.TextBoxDepName);
            this.Controls.Add(this.LabelDepName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddDep";
            this.Text = "Добавить отдел";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddDep_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDepName;
        private System.Windows.Forms.TextBox TextBoxDepName;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}