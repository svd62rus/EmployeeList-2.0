using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    public partial class FormEmpFire : Form, ILogger
    {
        private const string _emptyDepField = "[не выбрано]"; //пустое поле комбобокса сотрудников

        private EmployeeList list; //лист таблиц
        private Form1 mainForm; //главная форма для обновления
        private DataGridView dataGrid; //датагрид

        public FormEmpFire(EmployeeList list, Form1 mainForm, DataGridView dataGrid)
        {
            InitializeComponent();
            WriteLog($"Info. Компоненты формы сотрудников \"{Name}\" инициализированы");
            this.list = list;
            this.mainForm = mainForm;
            this.dataGrid = dataGrid;
            FillEmpsList(list.Employees);
            ComboBoxEmps.DropDownStyle = ComboBoxStyle.DropDownList;
            ButtonOK.Enabled = false;
        }
        //Заполнение комбобокса сотрудников
        private void FillEmpsList(List<Employee> empList)
        {
            ComboBoxEmps.Items.Clear();
            ComboBoxEmps.Items.Add(_emptyDepField); //добавляем пункт по умолчанию
            ComboBoxEmps.SelectedIndex = 0; //его индекс нулевой 
            for (int i = 0; i < empList.Count; i++)
            {
                if (!empList[i].IsFired)
                    ComboBoxEmps.Items.Add(empList[i].Id + ". " + empList[i].FullName); //добавляем отдел в комбобокс
            }
        }
        //Увольняем сотрудника
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            foreach (var elem in list.Employees)
            {
                if ((elem.Id + ". " + elem.FullName) == ComboBoxEmps.SelectedItem.ToString())
                {
                    list.FireEmp(elem);
                    FillEmpsList(list.Employees);
                    mainForm.RefreshMainForm(dataGrid,list.Employees);
                    mainForm.SelectRowInDataGrid(dataGrid,elem.Id);
                    mainForm.RefreshTotalInfo();
                    WriteLog($"Info. Cотрудник \"{elem.FullName}\" уволен");
                    MessageBox.Show($"Cотрудник \"{elem.FullName}\" уволен!");
                    break;
                }
            }
        }
        //Доступность кнопки увольнения
        private void ComboBoxEmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmps.SelectedItem.ToString() != _emptyDepField)
                ButtonOK.Enabled = true;
            else
                ButtonOK.Enabled = false;
        }

        public void WriteLog(string message)
        {
            StreamWriter sw = new StreamWriter(Program.mainLog, true);
            sw.WriteLineAsync($"[{DateTime.Now.ToString()}] : {message}");
            sw.Close();
        }

        private void FormEmpFire_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteLog($"Info. Форма сотрудников \"{Name}\" закрыта");
        }
    }
}
