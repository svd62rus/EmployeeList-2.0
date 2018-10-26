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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepartmens = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddDep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangeDep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangeDepByData = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridDeps = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonAddDep = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeps)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuDepartmens});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoad,
            this.menuSave,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(48, 20);
            this.menuFile.Text = "Файл";
            // 
            // menuLoad
            // 
            this.menuLoad.Image = global::EmployeeList_2._0.Properties.Resources.folder_open;
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(180, 22);
            this.menuLoad.Text = "Загрузить";
            this.menuLoad.Click += new System.EventHandler(this.toolStripMenuLoad_Click);
            // 
            // menuSave
            // 
            this.menuSave.Image = global::EmployeeList_2._0.Properties.Resources.Save256;
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(180, 22);
            this.menuSave.Text = "Сохранить";
            this.menuSave.Click += new System.EventHandler(this.toolStripMenuSave_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuDepartmens
            // 
            this.menuDepartmens.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddDep,
            this.menuChangeDep});
            this.menuDepartmens.Name = "menuDepartmens";
            this.menuDepartmens.Size = new System.Drawing.Size(61, 20);
            this.menuDepartmens.Text = "Отделы";
            // 
            // menuAddDep
            // 
            this.menuAddDep.Image = global::EmployeeList_2._0.Properties.Resources.add;
            this.menuAddDep.Name = "menuAddDep";
            this.menuAddDep.Size = new System.Drawing.Size(180, 22);
            this.menuAddDep.Text = "Добавить";
            this.menuAddDep.Click += new System.EventHandler(this.menuAddDep_Click);
            // 
            // menuChangeDep
            // 
            this.menuChangeDep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeDepByData});
            this.menuChangeDep.Name = "menuChangeDep";
            this.menuChangeDep.Size = new System.Drawing.Size(180, 22);
            this.menuChangeDep.Text = "Изменить";
            // 
            // menuChangeDepByData
            // 
            this.menuChangeDepByData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuChangeDepByData.Name = "menuChangeDepByData";
            this.menuChangeDepByData.Size = new System.Drawing.Size(180, 22);
            this.menuChangeDepByData.Text = "По данным";
            this.menuChangeDepByData.Click += new System.EventHandler(this.menuChangeDepByData_Click);
            // 
            // dataGridDeps
            // 
            this.dataGridDeps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDeps.Location = new System.Drawing.Point(12, 113);
            this.dataGridDeps.Name = "dataGridDeps";
            this.dataGridDeps.Size = new System.Drawing.Size(462, 343);
            this.dataGridDeps.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonLoad,
            this.toolButtonSave,
            this.toolStripSeparator1,
            this.toolButtonAddDep});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolButtonLoad
            // 
            this.toolButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonLoad.Image = global::EmployeeList_2._0.Properties.Resources.folder_open;
            this.toolButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonLoad.Name = "toolButtonLoad";
            this.toolButtonLoad.Size = new System.Drawing.Size(23, 22);
            this.toolButtonLoad.Text = "Загрузить";
            this.toolButtonLoad.Click += new System.EventHandler(this.toolButtonLoad_Click);
            // 
            // toolButtonSave
            // 
            this.toolButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonSave.Image = global::EmployeeList_2._0.Properties.Resources.Save256;
            this.toolButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonSave.Name = "toolButtonSave";
            this.toolButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolButtonSave.Text = "Сохранить";
            this.toolButtonSave.Click += new System.EventHandler(this.toolButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolButtonAddDep
            // 
            this.toolButtonAddDep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonAddDep.Image = global::EmployeeList_2._0.Properties.Resources.add;
            this.toolButtonAddDep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonAddDep.Name = "toolButtonAddDep";
            this.toolButtonAddDep.Size = new System.Drawing.Size(23, 22);
            this.toolButtonAddDep.Text = "Добавить отдел";
            this.toolButtonAddDep.Click += new System.EventHandler(this.toolButtonAddDep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(588, 492);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridDeps);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeList 2.0 [прототип]";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeps)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuDepartmens;
        private System.Windows.Forms.ToolStripMenuItem menuAddDep;
        private System.Windows.Forms.DataGridView dataGridDeps;
        private System.Windows.Forms.ToolStripMenuItem menuChangeDep;
        private System.Windows.Forms.ToolStripMenuItem menuChangeDepByData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolButtonLoad;
        private System.Windows.Forms.ToolStripButton toolButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolButtonAddDep;
    }
}

