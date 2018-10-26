namespace EmployeeList_2._0
{
    partial class FormChangeDep
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
            this.labelDepIdOrName = new System.Windows.Forms.Label();
            this.textBoxDesiredDep = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelNewDepName = new System.Windows.Forms.Label();
            this.textBoxNewDepName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDepIdOrName
            // 
            this.labelDepIdOrName.AutoSize = true;
            this.labelDepIdOrName.Location = new System.Drawing.Point(12, 19);
            this.labelDepIdOrName.Name = "labelDepIdOrName";
            this.labelDepIdOrName.Size = new System.Drawing.Size(299, 13);
            this.labelDepIdOrName.TabIndex = 0;
            this.labelDepIdOrName.Text = "Введите № или имя отдела, который вы хотите изменить";
            // 
            // textBoxDesiredDep
            // 
            this.textBoxDesiredDep.Location = new System.Drawing.Point(15, 47);
            this.textBoxDesiredDep.Name = "textBoxDesiredDep";
            this.textBoxDesiredDep.Size = new System.Drawing.Size(177, 20);
            this.textBoxDesiredDep.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(15, 83);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(236, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelNewDepName
            // 
            this.labelNewDepName.AutoSize = true;
            this.labelNewDepName.Location = new System.Drawing.Point(12, 128);
            this.labelNewDepName.Name = "labelNewDepName";
            this.labelNewDepName.Size = new System.Drawing.Size(143, 13);
            this.labelNewDepName.TabIndex = 4;
            this.labelNewDepName.Text = "Введите новое имя отдела";
            // 
            // textBoxNewDepName
            // 
            this.textBoxNewDepName.Location = new System.Drawing.Point(15, 156);
            this.textBoxNewDepName.Name = "textBoxNewDepName";
            this.textBoxNewDepName.Size = new System.Drawing.Size(177, 20);
            this.textBoxNewDepName.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(15, 205);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "Изменить";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormChangeDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 240);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxNewDepName);
            this.Controls.Add(this.labelNewDepName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxDesiredDep);
            this.Controls.Add(this.labelDepIdOrName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangeDep";
            this.Text = "Изменить отдел";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDepIdOrName;
        private System.Windows.Forms.TextBox textBoxDesiredDep;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelNewDepName;
        private System.Windows.Forms.TextBox textBoxNewDepName;
        private System.Windows.Forms.Button buttonOK;
    }
}