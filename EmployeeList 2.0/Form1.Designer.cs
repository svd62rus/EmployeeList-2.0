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
            this.MenuEmpFire = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportHire = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportFire = new System.Windows.Forms.ToolStripMenuItem();
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
            this.GroupBoxFiltersSorts = new System.Windows.Forms.GroupBox();
            this.LabelSalarySort = new System.Windows.Forms.Label();
            this.LabelFullNameSort = new System.Windows.Forms.Label();
            this.ButtonSort90 = new System.Windows.Forms.Button();
            this.ButtonSort09 = new System.Windows.Forms.Button();
            this.ButtonSortZA = new System.Windows.Forms.Button();
            this.LabelSort = new System.Windows.Forms.Label();
            this.LabelSalary = new System.Windows.Forms.Label();
            this.ButtonSortAZ = new System.Windows.Forms.Button();
            this.RadioButtonRange = new System.Windows.Forms.RadioButton();
            this.RadioButtonLess = new System.Windows.Forms.RadioButton();
            this.RadioButtonMore = new System.Windows.Forms.RadioButton();
            this.TextBoxMaxSalary = new System.Windows.Forms.TextBox();
            this.ButtonResetFilter = new System.Windows.Forms.Button();
            this.ButtonFilter = new System.Windows.Forms.Button();
            this.TextBoxMinSalary = new System.Windows.Forms.TextBox();
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
            this.GroupBoxFiltersSorts.SuspendLayout();
            this.TotalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuDepartmens,
            this.MenuEmployers,
            this.MenuExport});
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
            this.MenuRemoveEmp,
            this.MenuEmpFire});
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
            // MenuEmpFire
            // 
            this.MenuEmpFire.Name = "MenuEmpFire";
            this.MenuEmpFire.Size = new System.Drawing.Size(128, 22);
            this.MenuEmpFire.Text = "Уволить";
            this.MenuEmpFire.Click += new System.EventHandler(this.MenuEmpFire_Click);
            // 
            // MenuExport
            // 
            this.MenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportHire,
            this.MenuExportFire});
            this.MenuExport.Name = "MenuExport";
            this.MenuExport.Size = new System.Drawing.Size(64, 20);
            this.MenuExport.Text = "Экспорт";
            // 
            // MenuExportHire
            // 
            this.MenuExportHire.Name = "MenuExportHire";
            this.MenuExportHire.Size = new System.Drawing.Size(136, 22);
            this.MenuExportHire.Text = "Работники";
            this.MenuExportHire.Click += new System.EventHandler(this.MenuExportHire_Click);
            // 
            // MenuExportFire
            // 
            this.MenuExportFire.Name = "MenuExportFire";
            this.MenuExportFire.Size = new System.Drawing.Size(136, 22);
            this.MenuExportFire.Text = "Уволенные";
            this.MenuExportFire.Click += new System.EventHandler(this.MenuExportFire_Click);
            // 
            // DataGridDeps
            // 
            this.DataGridDeps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridDeps.Location = new System.Drawing.Point(20, 237);
            this.DataGridDeps.Name = "DataGridDeps";
            this.DataGridDeps.Size = new System.Drawing.Size(310, 409);
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
            this.DataGridEmps.Location = new System.Drawing.Point(21, 237);
            this.DataGridEmps.Name = "DataGridEmps";
            this.DataGridEmps.Size = new System.Drawing.Size(582, 409);
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
            this.PanelDeps.Size = new System.Drawing.Size(351, 665);
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
            this.DepartmentInfo.Size = new System.Drawing.Size(310, 193);
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
            this.CountOfDepEmp.Location = new System.Drawing.Point(7, 170);
            this.CountOfDepEmp.Name = "CountOfDepEmp";
            this.CountOfDepEmp.Size = new System.Drawing.Size(87, 13);
            this.CountOfDepEmp.TabIndex = 8;
            this.CountOfDepEmp.Text = "CountOfDepEmp";
            // 
            // SumOfDepSalary
            // 
            this.SumOfDepSalary.AutoSize = true;
            this.SumOfDepSalary.Location = new System.Drawing.Point(8, 78);
            this.SumOfDepSalary.Name = "SumOfDepSalary";
            this.SumOfDepSalary.Size = new System.Drawing.Size(88, 13);
            this.SumOfDepSalary.TabIndex = 6;
            this.SumOfDepSalary.Text = "SumOfDepSalary";
            // 
            // AvgOfDepSalary
            // 
            this.AvgOfDepSalary.AutoSize = true;
            this.AvgOfDepSalary.Location = new System.Drawing.Point(8, 124);
            this.AvgOfDepSalary.Name = "AvgOfDepSalary";
            this.AvgOfDepSalary.Size = new System.Drawing.Size(86, 13);
            this.AvgOfDepSalary.TabIndex = 7;
            this.AvgOfDepSalary.Text = "AvgOfDepSalary";
            // 
            // PanelEmps
            // 
            this.PanelEmps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEmps.Controls.Add(this.GroupBoxFiltersSorts);
            this.PanelEmps.Controls.Add(this.TotalInfo);
            this.PanelEmps.Controls.Add(this.LabelNameOfTableEmp);
            this.PanelEmps.Controls.Add(this.DataGridEmps);
            this.PanelEmps.Location = new System.Drawing.Point(369, 52);
            this.PanelEmps.Name = "PanelEmps";
            this.PanelEmps.Size = new System.Drawing.Size(627, 665);
            this.PanelEmps.TabIndex = 7;
            // 
            // GroupBoxFiltersSorts
            // 
            this.GroupBoxFiltersSorts.Controls.Add(this.LabelSalarySort);
            this.GroupBoxFiltersSorts.Controls.Add(this.LabelFullNameSort);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonSort90);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonSort09);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonSortZA);
            this.GroupBoxFiltersSorts.Controls.Add(this.LabelSort);
            this.GroupBoxFiltersSorts.Controls.Add(this.LabelSalary);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonSortAZ);
            this.GroupBoxFiltersSorts.Controls.Add(this.RadioButtonRange);
            this.GroupBoxFiltersSorts.Controls.Add(this.RadioButtonLess);
            this.GroupBoxFiltersSorts.Controls.Add(this.RadioButtonMore);
            this.GroupBoxFiltersSorts.Controls.Add(this.TextBoxMaxSalary);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonResetFilter);
            this.GroupBoxFiltersSorts.Controls.Add(this.ButtonFilter);
            this.GroupBoxFiltersSorts.Controls.Add(this.TextBoxMinSalary);
            this.GroupBoxFiltersSorts.Location = new System.Drawing.Point(21, 87);
            this.GroupBoxFiltersSorts.Name = "GroupBoxFiltersSorts";
            this.GroupBoxFiltersSorts.Size = new System.Drawing.Size(582, 107);
            this.GroupBoxFiltersSorts.TabIndex = 14;
            this.GroupBoxFiltersSorts.TabStop = false;
            this.GroupBoxFiltersSorts.Text = "Фильтры/Сортировка";
            // 
            // LabelSalarySort
            // 
            this.LabelSalarySort.AutoSize = true;
            this.LabelSalarySort.Location = new System.Drawing.Point(497, 50);
            this.LabelSalarySort.Name = "LabelSalarySort";
            this.LabelSalarySort.Size = new System.Drawing.Size(55, 13);
            this.LabelSalarySort.TabIndex = 27;
            this.LabelSalarySort.Text = "Зарплата";
            // 
            // LabelFullNameSort
            // 
            this.LabelFullNameSort.AutoSize = true;
            this.LabelFullNameSort.Location = new System.Drawing.Point(387, 50);
            this.LabelFullNameSort.Name = "LabelFullNameSort";
            this.LabelFullNameSort.Size = new System.Drawing.Size(34, 13);
            this.LabelFullNameSort.TabIndex = 26;
            this.LabelFullNameSort.Text = "ФИО";
            // 
            // ButtonSort90
            // 
            this.ButtonSort90.Location = new System.Drawing.Point(541, 69);
            this.ButtonSort90.Name = "ButtonSort90";
            this.ButtonSort90.Size = new System.Drawing.Size(35, 29);
            this.ButtonSort90.TabIndex = 25;
            this.ButtonSort90.Text = "9-0";
            this.ButtonSort90.UseVisualStyleBackColor = true;
            this.ButtonSort90.Click += new System.EventHandler(this.ButtonSort90_Click);
            // 
            // ButtonSort09
            // 
            this.ButtonSort09.Location = new System.Drawing.Point(500, 69);
            this.ButtonSort09.Name = "ButtonSort09";
            this.ButtonSort09.Size = new System.Drawing.Size(35, 29);
            this.ButtonSort09.TabIndex = 24;
            this.ButtonSort09.Text = "0-9";
            this.ButtonSort09.UseVisualStyleBackColor = true;
            this.ButtonSort09.Click += new System.EventHandler(this.ButtonSort09_Click);
            // 
            // ButtonSortZA
            // 
            this.ButtonSortZA.Location = new System.Drawing.Point(431, 69);
            this.ButtonSortZA.Name = "ButtonSortZA";
            this.ButtonSortZA.Size = new System.Drawing.Size(35, 29);
            this.ButtonSortZA.TabIndex = 23;
            this.ButtonSortZA.Text = "Я-А";
            this.ButtonSortZA.UseVisualStyleBackColor = true;
            this.ButtonSortZA.Click += new System.EventHandler(this.ButtonSortZA_Click);
            // 
            // LabelSort
            // 
            this.LabelSort.AutoSize = true;
            this.LabelSort.Location = new System.Drawing.Point(387, 24);
            this.LabelSort.Name = "LabelSort";
            this.LabelSort.Size = new System.Drawing.Size(67, 13);
            this.LabelSort.TabIndex = 22;
            this.LabelSort.Text = "Сортировка";
            // 
            // LabelSalary
            // 
            this.LabelSalary.AutoSize = true;
            this.LabelSalary.Location = new System.Drawing.Point(8, 24);
            this.LabelSalary.Name = "LabelSalary";
            this.LabelSalary.Size = new System.Drawing.Size(55, 13);
            this.LabelSalary.TabIndex = 21;
            this.LabelSalary.Text = "Зарплата";
            // 
            // ButtonSortAZ
            // 
            this.ButtonSortAZ.BackColor = System.Drawing.Color.Transparent;
            this.ButtonSortAZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonSortAZ.Location = new System.Drawing.Point(390, 69);
            this.ButtonSortAZ.Name = "ButtonSortAZ";
            this.ButtonSortAZ.Size = new System.Drawing.Size(35, 29);
            this.ButtonSortAZ.TabIndex = 19;
            this.ButtonSortAZ.Text = "А-Я";
            this.ButtonSortAZ.UseVisualStyleBackColor = false;
            this.ButtonSortAZ.Click += new System.EventHandler(this.ButtonSortAZ_Click);
            // 
            // RadioButtonRange
            // 
            this.RadioButtonRange.AutoSize = true;
            this.RadioButtonRange.Location = new System.Drawing.Point(157, 75);
            this.RadioButtonRange.Name = "RadioButtonRange";
            this.RadioButtonRange.Size = new System.Drawing.Size(73, 17);
            this.RadioButtonRange.TabIndex = 18;
            this.RadioButtonRange.TabStop = true;
            this.RadioButtonRange.Text = "диапазон";
            this.RadioButtonRange.UseVisualStyleBackColor = true;
            this.RadioButtonRange.CheckedChanged += new System.EventHandler(this.RadioButtonRange_CheckedChanged);
            // 
            // RadioButtonLess
            // 
            this.RadioButtonLess.AutoSize = true;
            this.RadioButtonLess.Location = new System.Drawing.Point(86, 75);
            this.RadioButtonLess.Name = "RadioButtonLess";
            this.RadioButtonLess.Size = new System.Drawing.Size(65, 17);
            this.RadioButtonLess.TabIndex = 17;
            this.RadioButtonLess.Text = "меньше";
            this.RadioButtonLess.UseVisualStyleBackColor = true;
            this.RadioButtonLess.CheckedChanged += new System.EventHandler(this.RadioButtonLess_CheckedChanged);
            // 
            // RadioButtonMore
            // 
            this.RadioButtonMore.AutoSize = true;
            this.RadioButtonMore.Checked = true;
            this.RadioButtonMore.Location = new System.Drawing.Point(11, 75);
            this.RadioButtonMore.Name = "RadioButtonMore";
            this.RadioButtonMore.Size = new System.Drawing.Size(63, 17);
            this.RadioButtonMore.TabIndex = 16;
            this.RadioButtonMore.TabStop = true;
            this.RadioButtonMore.Text = "больше";
            this.RadioButtonMore.UseVisualStyleBackColor = true;
            this.RadioButtonMore.CheckedChanged += new System.EventHandler(this.RadioButtonMore_CheckedChanged);
            // 
            // TextBoxMaxSalary
            // 
            this.TextBoxMaxSalary.Location = new System.Drawing.Point(131, 40);
            this.TextBoxMaxSalary.Name = "TextBoxMaxSalary";
            this.TextBoxMaxSalary.Size = new System.Drawing.Size(114, 20);
            this.TextBoxMaxSalary.TabIndex = 15;
            // 
            // ButtonResetFilter
            // 
            this.ButtonResetFilter.Location = new System.Drawing.Point(251, 72);
            this.ButtonResetFilter.Name = "ButtonResetFilter";
            this.ButtonResetFilter.Size = new System.Drawing.Size(115, 23);
            this.ButtonResetFilter.TabIndex = 14;
            this.ButtonResetFilter.Text = "Сброс";
            this.ButtonResetFilter.UseVisualStyleBackColor = true;
            this.ButtonResetFilter.Click += new System.EventHandler(this.ButtonResetFilter_Click);
            // 
            // ButtonFilter
            // 
            this.ButtonFilter.Location = new System.Drawing.Point(251, 40);
            this.ButtonFilter.Name = "ButtonFilter";
            this.ButtonFilter.Size = new System.Drawing.Size(114, 23);
            this.ButtonFilter.TabIndex = 12;
            this.ButtonFilter.Text = "Применить фильтр";
            this.ButtonFilter.UseVisualStyleBackColor = true;
            this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // TextBoxMinSalary
            // 
            this.TextBoxMinSalary.Location = new System.Drawing.Point(11, 40);
            this.TextBoxMinSalary.Name = "TextBoxMinSalary";
            this.TextBoxMinSalary.Size = new System.Drawing.Size(114, 20);
            this.TextBoxMinSalary.TabIndex = 13;
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
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.PanelEmps);
            this.Controls.Add(this.PanelDeps);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeList 2.0.5";
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
            this.GroupBoxFiltersSorts.ResumeLayout(false);
            this.GroupBoxFiltersSorts.PerformLayout();
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
        private System.Windows.Forms.TextBox TextBoxMinSalary;
        private System.Windows.Forms.Button ButtonFilter;
        private System.Windows.Forms.GroupBox GroupBoxFiltersSorts;
        private System.Windows.Forms.Button ButtonResetFilter;
        private System.Windows.Forms.TextBox TextBoxMaxSalary;
        private System.Windows.Forms.RadioButton RadioButtonLess;
        private System.Windows.Forms.RadioButton RadioButtonMore;
        private System.Windows.Forms.RadioButton RadioButtonRange;
        private System.Windows.Forms.Button ButtonSortAZ;
        private System.Windows.Forms.Label LabelSalary;
        private System.Windows.Forms.Label LabelSort;
        private System.Windows.Forms.Button ButtonSortZA;
        private System.Windows.Forms.Button ButtonSort09;
        private System.Windows.Forms.Button ButtonSort90;
        private System.Windows.Forms.Label LabelSalarySort;
        private System.Windows.Forms.Label LabelFullNameSort;
        private System.Windows.Forms.ToolStripMenuItem MenuEmpFire;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
        private System.Windows.Forms.ToolStripMenuItem MenuExportHire;
        private System.Windows.Forms.ToolStripMenuItem MenuExportFire;
    }
}

