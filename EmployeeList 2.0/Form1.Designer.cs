namespace EmployeeList_2._0
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDepartmens = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddDep = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChangeDep = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveDep = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEmployers = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChangeEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridDeps = new System.Windows.Forms.DataGridView();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CountOfEmpPerDep = new System.Windows.Forms.ToolStripButton();
            this.DataGridEmps = new System.Windows.Forms.DataGridView();
            this.LabelNameOfTableEmp = new System.Windows.Forms.Label();
            this.LabelNameOfTableDep = new System.Windows.Forms.Label();
            this.PanelDeps = new System.Windows.Forms.Panel();
            this.DepartmentInfo = new System.Windows.Forms.GroupBox();
            this.ComboBoxDeps = new System.Windows.Forms.ComboBox();
            this.CountOfDepEmp = new System.Windows.Forms.Label();
            this.SumOfDepSalary = new System.Windows.Forms.Label();
            this.AvgOfDepSalary = new System.Windows.Forms.Label();
            this.PanelEmps = new System.Windows.Forms.Panel();
            this.TotalInfo = new System.Windows.Forms.GroupBox();
            this.SumSalary = new System.Windows.Forms.Label();
            this.CountOfEmp = new System.Windows.Forms.Label();
            this.AvgSalary = new System.Windows.Forms.Label();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDeps)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmps)).BeginInit();
            this.PanelDeps.SuspendLayout();
            this.DepartmentInfo.SuspendLayout();
            this.PanelEmps.SuspendLayout();
            this.TotalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuDepartmens,
            this.MenuEmployers});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLoad,
            this.MenuSave,
            this.MenuExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "Файл";
            // 
            // MenuLoad
            // 
            this.MenuLoad.Image = global::EmployeeList_2._0.Properties.Resources.folder_open;
            this.MenuLoad.Name = "MenuLoad";
            this.MenuLoad.Size = new System.Drawing.Size(132, 22);
            this.MenuLoad.Text = "Загрузить";
            this.MenuLoad.Click += new System.EventHandler(this.ToolStripMenuLoad_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Image = global::EmployeeList_2._0.Properties.Resources.Save256;
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(132, 22);
            this.MenuSave.Text = "Сохранить";
            this.MenuSave.Click += new System.EventHandler(this.ToolStripMenuSave_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(132, 22);
            this.MenuExit.Text = "Выход";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MenuDepartmens
            // 
            this.MenuDepartmens.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddDep,
            this.MenuChangeDep,
            this.MenuRemoveDep});
            this.MenuDepartmens.Name = "MenuDepartmens";
            this.MenuDepartmens.Size = new System.Drawing.Size(61, 20);
            this.MenuDepartmens.Text = "Отделы";
            // 
            // MenuAddDep
            // 
            this.MenuAddDep.Image = global::EmployeeList_2._0.Properties.Resources.add;
            this.MenuAddDep.Name = "MenuAddDep";
            this.MenuAddDep.Size = new System.Drawing.Size(128, 22);
            this.MenuAddDep.Text = "Добавить";
            this.MenuAddDep.Click += new System.EventHandler(this.MenuAddDep_Click);
            // 
            // MenuChangeDep
            // 
            this.MenuChangeDep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuChangeDep.Name = "MenuChangeDep";
            this.MenuChangeDep.Size = new System.Drawing.Size(128, 22);
            this.MenuChangeDep.Text = "Изменить";
            this.MenuChangeDep.Click += new System.EventHandler(this.MenuChangeDep_Click);
            // 
            // MenuRemoveDep
            // 
            this.MenuRemoveDep.Name = "MenuRemoveDep";
            this.MenuRemoveDep.Size = new System.Drawing.Size(128, 22);
            this.MenuRemoveDep.Text = "Удалить";
            this.MenuRemoveDep.Click += new System.EventHandler(this.MenuRemoveDep_Click);
            // 
            // MenuEmployers
            // 
            this.MenuEmployers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddEmp,
            this.MenuChangeEmp,
            this.MenuRemoveEmp});
            this.MenuEmployers.Name = "MenuEmployers";
            this.MenuEmployers.Size = new System.Drawing.Size(85, 20);
            this.MenuEmployers.Text = "Сотрудники";
            // 
            // MenuAddEmp
            // 
            this.MenuAddEmp.Image = global::EmployeeList_2._0.Properties.Resources.add;
            this.MenuAddEmp.Name = "MenuAddEmp";
            this.MenuAddEmp.Size = new System.Drawing.Size(128, 22);
            this.MenuAddEmp.Text = "Добавить";
            this.MenuAddEmp.Click += new System.EventHandler(this.MenuAddEmp_Click);
            // 
            // MenuChangeEmp
            // 
            this.MenuChangeEmp.Name = "MenuChangeEmp";
            this.MenuChangeEmp.Size = new System.Drawing.Size(128, 22);
            this.MenuChangeEmp.Text = "Изменить";
            this.MenuChangeEmp.Click += new System.EventHandler(this.MenuChangeEmp_Click);
            // 
            // MenuRemoveEmp
            // 
            this.MenuRemoveEmp.Name = "MenuRemoveEmp";
            this.MenuRemoveEmp.Size = new System.Drawing.Size(128, 22);
            this.MenuRemoveEmp.Text = "Удалить";
            this.MenuRemoveEmp.Click += new System.EventHandler(this.MenuRemoveEmp_Click);
            // 
            // DataGridDeps
            // 
            this.DataGridDeps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridDeps.Location = new System.Drawing.Point(20, 171);
            this.DataGridDeps.Name = "DataGridDeps";
            this.DataGridDeps.Size = new System.Drawing.Size(310, 310);
            this.DataGridDeps.TabIndex = 1;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CountOfEmpPerDep});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "toolStrip1";
            // 
            // CountOfEmpPerDep
            // 
            this.CountOfEmpPerDep.Image = global::EmployeeList_2._0.Properties.Resources.icons8;
            this.CountOfEmpPerDep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CountOfEmpPerDep.Name = "CountOfEmpPerDep";
            this.CountOfEmpPerDep.Size = new System.Drawing.Size(184, 22);
            this.CountOfEmpPerDep.Text = "Кол-во сотр-ков по отделам";
            this.CountOfEmpPerDep.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CountOfEmpPerDep.Click += new System.EventHandler(this.CountOfEmpPerDep_Click);
            // 
            // DataGridEmps
            // 
            this.DataGridEmps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridEmps.Location = new System.Drawing.Point(21, 171);
            this.DataGridEmps.Name = "DataGridEmps";
            this.DataGridEmps.Size = new System.Drawing.Size(582, 310);
            this.DataGridEmps.TabIndex = 3;
            // 
            // LabelNameOfTableEmp
            // 
            this.LabelNameOfTableEmp.AutoSize = true;
            this.LabelNameOfTableEmp.Location = new System.Drawing.Point(18, 9);
            this.LabelNameOfTableEmp.Name = "LabelNameOfTableEmp";
            this.LabelNameOfTableEmp.Size = new System.Drawing.Size(76, 13);
            this.LabelNameOfTableEmp.TabIndex = 5;
            this.LabelNameOfTableEmp.Text = "\"Сотрудники\"";
            // 
            // LabelNameOfTableDep
            // 
            this.LabelNameOfTableDep.AutoSize = true;
            this.LabelNameOfTableDep.Location = new System.Drawing.Point(17, 9);
            this.LabelNameOfTableDep.Name = "LabelNameOfTableDep";
            this.LabelNameOfTableDep.Size = new System.Drawing.Size(56, 13);
            this.LabelNameOfTableDep.TabIndex = 4;
            this.LabelNameOfTableDep.Text = "\"Отделы\"";
            // 
            // PanelDeps
            // 
            this.PanelDeps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDeps.Controls.Add(this.DepartmentInfo);
            this.PanelDeps.Controls.Add(this.LabelNameOfTableDep);
            this.PanelDeps.Controls.Add(this.DataGridDeps);
            this.PanelDeps.Location = new System.Drawing.Point(12, 52);
            this.PanelDeps.Name = "PanelDeps";
            this.PanelDeps.Size = new System.Drawing.Size(351, 497);
            this.PanelDeps.TabIndex = 6;
            // 
            // DepartmentInfo
            // 
            this.DepartmentInfo.Controls.Add(this.ComboBoxDeps);
            this.DepartmentInfo.Controls.Add(this.CountOfDepEmp);
            this.DepartmentInfo.Controls.Add(this.SumOfDepSalary);
            this.DepartmentInfo.Controls.Add(this.AvgOfDepSalary);
            this.DepartmentInfo.Location = new System.Drawing.Point(20, 38);
            this.DepartmentInfo.Name = "DepartmentInfo";
            this.DepartmentInfo.Size = new System.Drawing.Size(310, 121);
            this.DepartmentInfo.TabIndex = 9;
            this.DepartmentInfo.TabStop = false;
            this.DepartmentInfo.Text = "Сведения об отделе";
            // 
            // ComboBoxDeps
            // 
            this.ComboBoxDeps.FormattingEnabled = true;
            this.ComboBoxDeps.Location = new System.Drawing.Point(6, 19);
            this.ComboBoxDeps.Name = "ComboBoxDeps";
            this.ComboBoxDeps.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxDeps.TabIndex = 5;
            this.ComboBoxDeps.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDeps_SelectedIndexChanged);
            // 
            // CountOfDepEmp
            // 
            this.CountOfDepEmp.AutoSize = true;
            this.CountOfDepEmp.Location = new System.Drawing.Point(3, 103);
            this.CountOfDepEmp.Name = "CountOfDepEmp";
            this.CountOfDepEmp.Size = new System.Drawing.Size(87, 13);
            this.CountOfDepEmp.TabIndex = 8;
            this.CountOfDepEmp.Text = "CountOfDepEmp";
            // 
            // SumOfDepSalary
            // 
            this.SumOfDepSalary.AutoSize = true;
            this.SumOfDepSalary.Location = new System.Drawing.Point(3, 54);
            this.SumOfDepSalary.Name = "SumOfDepSalary";
            this.SumOfDepSalary.Size = new System.Drawing.Size(88, 13);
            this.SumOfDepSalary.TabIndex = 6;
            this.SumOfDepSalary.Text = "SumOfDepSalary";
            // 
            // AvgOfDepSalary
            // 
            this.AvgOfDepSalary.AutoSize = true;
            this.AvgOfDepSalary.Location = new System.Drawing.Point(3, 78);
            this.AvgOfDepSalary.Name = "AvgOfDepSalary";
            this.AvgOfDepSalary.Size = new System.Drawing.Size(86, 13);
            this.AvgOfDepSalary.TabIndex = 7;
            this.AvgOfDepSalary.Text = "AvgOfDepSalary";
            // 
            // PanelEmps
            // 
            this.PanelEmps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEmps.Controls.Add(this.TotalInfo);
            this.PanelEmps.Controls.Add(this.LabelNameOfTableEmp);
            this.PanelEmps.Controls.Add(this.DataGridEmps);
            this.PanelEmps.Location = new System.Drawing.Point(369, 52);
            this.PanelEmps.Name = "PanelEmps";
            this.PanelEmps.Size = new System.Drawing.Size(627, 497);
            this.PanelEmps.TabIndex = 7;
            // 
            // TotalInfo
            // 
            this.TotalInfo.Controls.Add(this.SumSalary);
            this.TotalInfo.Controls.Add(this.CountOfEmp);
            this.TotalInfo.Controls.Add(this.AvgSalary);
            this.TotalInfo.Location = new System.Drawing.Point(21, 38);
            this.TotalInfo.Name = "TotalInfo";
            this.TotalInfo.Size = new System.Drawing.Size(582, 43);
            this.TotalInfo.TabIndex = 11;
            this.TotalInfo.TabStop = false;
            this.TotalInfo.Text = "Информация";
            // 
            // SumSalary
            // 
            this.SumSalary.AutoSize = true;
            this.SumSalary.Location = new System.Drawing.Point(6, 19);
            this.SumSalary.Name = "SumSalary";
            this.SumSalary.Size = new System.Drawing.Size(57, 13);
            this.SumSalary.TabIndex = 7;
            this.SumSalary.Text = "SumSalary";
            // 
            // CountOfEmp
            // 
            this.CountOfEmp.AutoSize = true;
            this.CountOfEmp.Location = new System.Drawing.Point(422, 19);
            this.CountOfEmp.Name = "CountOfEmp";
            this.CountOfEmp.Size = new System.Drawing.Size(67, 13);
            this.CountOfEmp.TabIndex = 10;
            this.CountOfEmp.Text = "CountOfEmp";
            // 
            // AvgSalary
            // 
            this.AvgSalary.AutoSize = true;
            this.AvgSalary.Location = new System.Drawing.Point(214, 19);
            this.AvgSalary.Name = "AvgSalary";
            this.AvgSalary.Size = new System.Drawing.Size(55, 13);
            this.AvgSalary.TabIndex = 9;
            this.AvgSalary.Text = "AvgSalary";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.PanelEmps);
            this.Controls.Add(this.PanelDeps);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeList 2.0.2";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDeps)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmps)).EndInit();
            this.PanelDeps.ResumeLayout(false);
            this.PanelDeps.PerformLayout();
            this.DepartmentInfo.ResumeLayout(false);
            this.DepartmentInfo.PerformLayout();
            this.PanelEmps.ResumeLayout(false);
            this.PanelEmps.PerformLayout();
            this.TotalInfo.ResumeLayout(false);
            this.TotalInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuDepartmens;
        private System.Windows.Forms.ToolStripMenuItem MenuAddDep;
        private System.Windows.Forms.DataGridView DataGridDeps;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.DataGridView DataGridEmps;
        private System.Windows.Forms.Label LabelNameOfTableEmp;
        private System.Windows.Forms.Label LabelNameOfTableDep;
        private System.Windows.Forms.Panel PanelDeps;
        private System.Windows.Forms.Panel PanelEmps;
        private System.Windows.Forms.ToolStripMenuItem MenuEmployers;
        private System.Windows.Forms.ToolStripMenuItem MenuAddEmp;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveEmp;
        private System.Windows.Forms.Label SumSalary;
        private System.Windows.Forms.Label AvgSalary;
        private System.Windows.Forms.Label CountOfEmp;
        private System.Windows.Forms.ComboBox ComboBoxDeps;
        private System.Windows.Forms.Label SumOfDepSalary;
        private System.Windows.Forms.Label AvgOfDepSalary;
        private System.Windows.Forms.Label CountOfDepEmp;
        private System.Windows.Forms.ToolStripButton CountOfEmpPerDep;
        private System.Windows.Forms.GroupBox TotalInfo;
        private System.Windows.Forms.GroupBox DepartmentInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuChangeDep;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveDep;
        private System.Windows.Forms.ToolStripMenuItem MenuChangeEmp;
    }
}

