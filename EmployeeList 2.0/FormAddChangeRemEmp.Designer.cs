namespace EmployeeList_2._0
{
    partial class FormAddChangeRemEmp
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
            this.LabelSurname = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelPatronymic = new System.Windows.Forms.Label();
            this.LabelDepartment = new System.Windows.Forms.Label();
            this.ComboBoxDeps = new System.Windows.Forms.ComboBox();
            this.LabelSalary = new System.Windows.Forms.Label();
            this.TextBoxSurname = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxPatronymic = new System.Windows.Forms.TextBox();
            this.TextBoxSalary = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelSurname
            // 
            this.LabelSurname.AutoSize = true;
            this.LabelSurname.Location = new System.Drawing.Point(24, 38);
            this.LabelSurname.Name = "LabelSurname";
            this.LabelSurname.Size = new System.Drawing.Size(56, 13);
            this.LabelSurname.TabIndex = 0;
            this.LabelSurname.Text = "Фамилия";
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(24, 93);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(29, 13);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "Имя";
            // 
            // LabelPatronymic
            // 
            this.LabelPatronymic.AutoSize = true;
            this.LabelPatronymic.Location = new System.Drawing.Point(24, 146);
            this.LabelPatronymic.Name = "LabelPatronymic";
            this.LabelPatronymic.Size = new System.Drawing.Size(54, 13);
            this.LabelPatronymic.TabIndex = 2;
            this.LabelPatronymic.Text = "Отчество";
            // 
            // LabelDepartment
            // 
            this.LabelDepartment.AutoSize = true;
            this.LabelDepartment.Location = new System.Drawing.Point(24, 197);
            this.LabelDepartment.Name = "LabelDepartment";
            this.LabelDepartment.Size = new System.Drawing.Size(38, 13);
            this.LabelDepartment.TabIndex = 3;
            this.LabelDepartment.Text = "Отдел";
            // 
            // ComboBoxDeps
            // 
            this.ComboBoxDeps.FormattingEnabled = true;
            this.ComboBoxDeps.Location = new System.Drawing.Point(122, 197);
            this.ComboBoxDeps.Name = "ComboBoxDeps";
            this.ComboBoxDeps.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxDeps.TabIndex = 4;
            // 
            // LabelSalary
            // 
            this.LabelSalary.AutoSize = true;
            this.LabelSalary.Location = new System.Drawing.Point(24, 249);
            this.LabelSalary.Name = "LabelSalary";
            this.LabelSalary.Size = new System.Drawing.Size(92, 13);
            this.LabelSalary.TabIndex = 5;
            this.LabelSalary.Text = "Зарплата р./мес";
            // 
            // TextBoxSurname
            // 
            this.TextBoxSurname.Location = new System.Drawing.Point(122, 35);
            this.TextBoxSurname.Name = "TextBoxSurname";
            this.TextBoxSurname.Size = new System.Drawing.Size(121, 20);
            this.TextBoxSurname.TabIndex = 6;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(122, 90);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(121, 20);
            this.TextBoxName.TabIndex = 7;
            // 
            // TextBoxPatronymic
            // 
            this.TextBoxPatronymic.Location = new System.Drawing.Point(122, 143);
            this.TextBoxPatronymic.Name = "TextBoxPatronymic";
            this.TextBoxPatronymic.Size = new System.Drawing.Size(121, 20);
            this.TextBoxPatronymic.TabIndex = 8;
            // 
            // TextBoxSalary
            // 
            this.TextBoxSalary.Location = new System.Drawing.Point(122, 246);
            this.TextBoxSalary.Name = "TextBoxSalary";
            this.TextBoxSalary.Size = new System.Drawing.Size(121, 20);
            this.TextBoxSalary.TabIndex = 9;
            this.TextBoxSalary.TextChanged += new System.EventHandler(this.TextBoxSalary_TextChanged);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(27, 329);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 10;
            this.ButtonOK.Text = "AddChangeRem";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(268, 329);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(268, 141);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 12;
            this.ButtonSearch.Text = "Найти";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // FormAddChangeRemEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 364);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.TextBoxSalary);
            this.Controls.Add(this.TextBoxPatronymic);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.TextBoxSurname);
            this.Controls.Add(this.LabelSalary);
            this.Controls.Add(this.ComboBoxDeps);
            this.Controls.Add(this.LabelDepartment);
            this.Controls.Add(this.LabelPatronymic);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.LabelSurname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddChangeRemEmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddChange";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddChangeRemEmp_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelSurname;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelPatronymic;
        private System.Windows.Forms.Label LabelDepartment;
        private System.Windows.Forms.ComboBox ComboBoxDeps;
        private System.Windows.Forms.Label LabelSalary;
        private System.Windows.Forms.TextBox TextBoxSurname;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxPatronymic;
        private System.Windows.Forms.TextBox TextBoxSalary;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSearch;
    }
}