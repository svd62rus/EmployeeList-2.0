namespace EmployeeList_2._0
{
    partial class FormChangeRemDep
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
            this.TextBoxDesiredDep = new System.Windows.Forms.TextBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.labelNewDepName = new System.Windows.Forms.Label();
            this.TextBoxNewDepName = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDepIdOrName
            // 
            this.labelDepIdOrName.AutoSize = true;
            this.labelDepIdOrName.Location = new System.Drawing.Point(12, 19);
            this.labelDepIdOrName.Name = "labelDepIdOrName";
            this.labelDepIdOrName.Size = new System.Drawing.Size(250, 13);
            this.labelDepIdOrName.TabIndex = 0;
            this.labelDepIdOrName.Text = "Введите № или имя отдела, который вы хотите ";
            // 
            // TextBoxDesiredDep
            // 
            this.TextBoxDesiredDep.Location = new System.Drawing.Point(15, 47);
            this.TextBoxDesiredDep.Name = "TextBoxDesiredDep";
            this.TextBoxDesiredDep.Size = new System.Drawing.Size(177, 20);
            this.TextBoxDesiredDep.TabIndex = 1;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(15, 83);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 2;
            this.ButtonSearch.Text = "Найти";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(236, 205);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
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
            // TextBoxNewDepName
            // 
            this.TextBoxNewDepName.Location = new System.Drawing.Point(15, 156);
            this.TextBoxNewDepName.Name = "TextBoxNewDepName";
            this.TextBoxNewDepName.Size = new System.Drawing.Size(177, 20);
            this.TextBoxNewDepName.TabIndex = 5;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(15, 205);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 6;
            this.ButtonOK.Text = "ChangeRemove";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FormChangeRemDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 240);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.TextBoxNewDepName);
            this.Controls.Add(this.labelNewDepName);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.TextBoxDesiredDep);
            this.Controls.Add(this.labelDepIdOrName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangeRemDep";
            this.Text = "ChangeRemove";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDepIdOrName;
        private System.Windows.Forms.TextBox TextBoxDesiredDep;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label labelNewDepName;
        private System.Windows.Forms.TextBox TextBoxNewDepName;
        private System.Windows.Forms.Button ButtonOK;
    }
}