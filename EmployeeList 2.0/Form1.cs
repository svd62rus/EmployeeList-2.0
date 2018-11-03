using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace EmployeeList_2._0
{
    public partial class Form1 : Form
    {
        private EmployeeList list; //лист

        private const string _emptyDepField = "[не выбрано]"; //пустое поле комбобокса отделов на главной форме

        //Подписи инфо-лейблов на главной форме
        private string sumOfSalaryTitle = "Общая зарплата: ";
        private string avgOfSalaryTitle = "Средняя зарплата: ";
        private string countOfEmpTitle = "Cотрудники: ";
        private string sumOfDepSalaryTitle = "Общая зарплата по отделу: ";
        private string avgOfDepSalaryTitle = "Сред.зарплата по отделу: ";
        private string countOfDepEmpTitle = "Кол-во сотрудников в отделе: ";
        private string сurrency = "р.";
        private string noDataString = "нет данных";

        //Окончания слов
        private string endingMany = "ов";
        private string endingSingle = "а";
        
        //Регулярки для задания окончаний
        Regex regexMany = new Regex(@"^\d*(1\d|0)$");  //проверка на цифру, после которой у слова будет окончание "ов"
        Regex regexSingle = new Regex(@"^\d*[2,3,4]$"); //-//- окончание "а"

        static private string nameOfFile = "List.dat"; //имя сохраняемого файла

        public delegate void DisplayMethod<T>(DataGridView dataGrid, List<T> displayList); /*делегат для:
                                             - передачи метода вывода данных в таблицы
                                            */
        public Form1()
        {
            InitializeComponent();

            list = new EmployeeList(); //cоздаем экземпляр таблиц
            DataGridAddColumns(); //добавляем столбцы
            SetDataGridParams(DataGridDeps); //устанавливаем параметры датагрида отделов           
            SetDataGridParams(DataGridEmps); //устанавливаем параметры датагрида сотрудников
            SetInfoLabelText(); //устанавливаем дефолтный текст в инфо-лейблах
            ComboBoxDeps.DropDownStyle = ComboBoxStyle.DropDownList; //делаем комбобокс нередактируемым
        }

        //Добавление столбцов
        private void DataGridAddColumns()
        {
            //Добавляем столбцы в датагрид отделов
            DataGridDeps.Columns.Add("Id", "№");
            DataGridDeps.Columns.Add("Name", "Отдел");
            DataGridDeps.Columns.Add("DateCreate", "Дата создания");
            //Добавляем столбцы в датагрид сотрудников
            DataGridEmps.Columns.Add("Id", "№");
            DataGridEmps.Columns.Add("FullName", "ФИО");
            DataGridEmps.Columns.Add("Salary", "Зарплата, "+ сurrency);
            DataGridEmps.Columns.Add("Department", "Отдел");
            DataGridEmps.Columns.Add("DateHired", "Нанят");
            DataGridEmps.Columns.Add("DateFired", "Уволен");
        }
        //Установка параметров датагрида
        private void SetDataGridParams(DataGridView dataGrid)
        {
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;

        }
        //Установка дефолтного текста в инфо-лейблах
        private void SetInfoLabelText()
        {
            SumSalary.Text = sumOfSalaryTitle + noDataString;
            AvgSalary.Text = avgOfSalaryTitle + noDataString;
            CountOfEmp.Text = countOfEmpTitle + noDataString;
            SumOfDepSalary.Text = sumOfDepSalaryTitle + noDataString;
            AvgOfDepSalary.Text = avgOfDepSalaryTitle + noDataString;
            CountOfDepEmp.Text = countOfDepEmpTitle + noDataString;
        }
        //Заполнение комбобокса отделов
        private void FillDepsList(List<EmpClasses.Department> depList)
        {
            int selectedIndex = 0;
            int count = ComboBoxDeps.Items.Count;
            bool isCurrentItem = false; //обновляется ли текущий выбранный отдел
            if (count > 0)
                selectedIndex = ComboBoxDeps.SelectedIndex;
            AddDefaultSelect(); //добавляем пустое поле по умолчанию
            for (int i = 0; i < depList.Count; i++)
            {
                var currentIndex = ComboBoxDeps.Items.Add(depList[i].Id + ". " + depList[i].Name); //добавляем отдел в комбобокс
                if (currentIndex == selectedIndex)
                    isCurrentItem = true;
            }
            if (isCurrentItem)
                if (count > 0)
                    ComboBoxDeps.SelectedIndex = selectedIndex; //оставляем текущий выбранным
        }
        //Добавление пункта по-умолчанию в список отделов
        private void AddDefaultSelect()
        {
            ComboBoxDeps.Items.Clear();
            ComboBoxDeps.Items.Add(_emptyDepField); //добавляем пункт по умолчанию
            ComboBoxDeps.SelectedIndex = 0; //его индекс нулевой 
        }
          
        //Обновление датагрида отделов
        public void RefreshMainForm(DataGridView dataGrid, List<EmpClasses.Department> displayList)
        {
            Display(dataGrid, displayList);
            FillDepsList(list.Departments);
        }
        //Обновление датагрида сотрудников
        public void RefreshMainForm(DataGridView dataGrid, List<EmpClasses.Employee> displayList)
        {
            Display(dataGrid, displayList);
            RefreshTotalInfo();
            FillDepsList(list.Departments);
        }
        //Очистка датагрида
        private void ClearDataGrid(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count > 1)
                dataGrid.Rows.Clear(); //очищаем датагрид
        }

        //Вывод отделов
        public void Display(DataGridView dataGrid, List<EmpClasses.Department> depList)
        {
            ClearDataGrid(dataGrid); //очищаем датагрид
            foreach (var el in depList)
            {
                string[] row = { el.Id.ToString(), el.Name, el.DateCreate.ToLongDateString() };
                dataGrid.Rows.Add(row); //добавляем массив строк в датагрид
            }
        }
        //Вывод сотрудников
        public void Display(DataGridView dataGrid, List<EmpClasses.Employee> empList)
        {
            ClearDataGrid(dataGrid); //очищаем датагрид
            foreach (var el in empList)
            {
                string[] row = { el.Id.ToString(), el.FullName, String.Format($"{el.Salary:F2}"),el.DepartmentId.ToString(),
                    el.DateHired.ToLongDateString(),el.DateFired.ToString()};
                dataGrid.Rows.Add(row); //добавляем массив строк в датагрид
            }
        }

        //Файл-Загрузить
        private void ToolStripMenuLoad_Click(object sender, EventArgs e)
        {
            var ex = LoadTables(ref list, Display, Display);//загружаем файл в программу
            if (ex == null)
            {
                //убираем выделения строк
                DataGridDeps.ClearSelection();
                DataGridEmps.ClearSelection();
            }
            else
                MessageBox.Show($"Загрузка невозможна. Ошибка: {ex.Message}");
        }
        //Загрузка
        private Exception LoadTables(ref EmployeeList list, DisplayMethod<EmpClasses.Department> displayDeps,
            DisplayMethod<EmpClasses.Employee> displayEmps)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            try
            {
                using (FileStream fs = new FileStream(nameOfFile, FileMode.Open))
                {
                    list = (EmployeeList)formatter.Deserialize(fs);
                    displayDeps(DataGridDeps, list.Departments); //выводим данные отделов в соответствующий датагрид
                    displayEmps(DataGridEmps, list.Employees); //выводим данные cотрудников в соответствующий датагрид
                }  
            }
            catch (Exception ex)
            {
                return ex;
            }
            RefreshTotalInfo(); //обновляем общую инфу
            FillDepsList(list.Departments); //заполняем список отделов
            return null;
        }
        //Файл-Сохранить
        private void ToolStripMenuSave_Click(object sender, EventArgs e)
        {
            var ex = SaveTables(list); //сохраняем изменения в файл
            if (ex == null)
                MessageBox.Show("Данные сохранены!");
            else
            {
                MessageBox.Show($"Сохранение невозможно. Ошибка: {ex.Message}");
            }
        }
        //Сохранение
        static Exception SaveTables(EmployeeList list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            try
            {
                using (FileStream fs = new FileStream(nameOfFile, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, list);
                }
            }
            catch (Exception ex)
            {
                return ex;
            }

            return null;
        }

        //Обработка закрытия дочерних форм
        private void AnyChildFormClosed(object sender, EventArgs e)
        {
            Enabled = true;
        }
        
        //Обновление общей информации
        public void RefreshTotalInfo()
        {
            if (list.Employees.Count > 0)
            {
                SumSalary.Text = sumOfSalaryTitle + list.SumSalary().ToString("#.##") + " " + сurrency;
                AvgSalary.Text = avgOfSalaryTitle + list.AvgSalary().ToString("#.##") + " " + сurrency;
                CountOfEmp.Text = countOfEmpTitle + list.CountOfEmp().ToString();
            }
            else
            {
                SumSalary.Text = sumOfSalaryTitle + noDataString;
                AvgSalary.Text = avgOfSalaryTitle + noDataString;
                CountOfEmp.Text = countOfEmpTitle + noDataString;
            }
                
        }

        //Выделение конкретной строки с данными
        public void SelectRowInDataGrid(DataGridView dataGrid, int numOfRow)
        {
            dataGrid.Rows[numOfRow - 1].Selected = true;
            dataGrid.FirstDisplayedScrollingRowIndex = numOfRow-1;
            dataGrid.Update();
        }

        //Cоздание дочерней формы отделов и переключение на нее
        private void ShowChildFormDep(string operation)
        {
            Enabled = false;
            var childForm = new FormChangeRemDep(list, this, DataGridDeps, DataGridEmps, operation); //создаем форму изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
        }
        //Отделы-Добавить
        private void MenuAddDep_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var formAddDep = new FormAddDep(list, this, DataGridDeps); //создаем форму добавления отдела
            formAddDep.Show(); //показываем новую форму
            formAddDep.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
        }        
        //Отделы-Изменить
        private void MenuChangeDep_Click(object sender, EventArgs e)
        {
            ShowChildFormDep(Program.Действия.Изменить.ToString()); //вызываем дочернюю форму
        }
        //Отделы-Удалить
        private void MenuRemoveDep_Click(object sender, EventArgs e)
        {
            ShowChildFormDep(Program.Действия.Удалить.ToString()); //вызываем дочернюю форму
        }


        //Cоздание дочерней формы сотрудников и переключение на нее
        private void ShowChildFormEmp(string operation)
        {
            Enabled = false;
            var childForm = new FormAddChangeRemEmp(list, this, DataGridEmps, operation); //создаем форму добавления/изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы            
        }
        //Cотрудники-Добавить
        private void MenuAddEmp_Click(object sender, EventArgs e)
        {
            if (list.Departments.Count > 0)
                ShowChildFormEmp(Program.Действия.Добавить.ToString()); //вызываем дочернюю форму
            else
                MessageBox.Show($"Нет отделов для добавления сотрудника!");
        }
        //Сотрудники-Изменить
        private void MenuChangeEmp_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(Program.Действия.Изменить.ToString()); //вызываем дочернюю форму
            else
                MessageBox.Show($"Нет сотрудников для изменения");
        }
        //Сотрудники-Удалить
        private void MenuRemoveEmp_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(Program.Действия.Удалить.ToString()); //вызываем дочернюю форму
            else
                MessageBox.Show($"Нет сотрудников для изменения");
        }

        //Вывод данных по отделу
        private void ComboBoxDeps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDeps.SelectedItem.ToString() != _emptyDepField)
            {
                SelectRowInDataGrid(DataGridDeps,ComboBoxDeps.SelectedIndex);
                SetDepInfoLabelText(); //устанавливаем значение инфо-лейблов отдела
            }
            else
            {
                DataGridDeps.ClearSelection();
                NotDataMessage();
            }
                
        }
        //Установка значений инфо-лейблов отдела
        private void SetDepInfoLabelText()
        {
            if (list.SumSalary(ComboBoxDeps.SelectedIndex) > 0)
                SumOfDepSalary.Text = sumOfDepSalaryTitle + 
                                      list.SumSalary(ComboBoxDeps.SelectedIndex).ToString("#.##") + " " + сurrency;
            else
                NotDataMessage(); //выводим сообщение об отсутствии данных
            if (list.AvgSalary(ComboBoxDeps.SelectedIndex) > 0)
                AvgOfDepSalary.Text = avgOfDepSalaryTitle + 
                                      list.AvgSalary(ComboBoxDeps.SelectedIndex).ToString("#.##") + " " + сurrency;
            else
                NotDataMessage(); //выводим сообщение об отсутствии данных
            if (list.CountOfEmp(ComboBoxDeps.SelectedIndex) > 0)
                CountOfDepEmp.Text = countOfDepEmpTitle + list.CountOfEmp(ComboBoxDeps.SelectedIndex);
            else
                NotDataMessage(); //выводим сообщение об отсутствии данных
        }
        //Вывод сообщения об отсуствии данных для отдела
        private void NotDataMessage()
        {
            SumOfDepSalary.Text = sumOfDepSalaryTitle + noDataString;
            AvgOfDepSalary.Text = avgOfDepSalaryTitle + noDataString;
            CountOfDepEmp.Text = countOfDepEmpTitle + noDataString;
        }

        //Кол-во сотрудников по отделам
        private void CountOfEmpPerDep_Click(object sender, EventArgs e)
        {
            string output = string.Empty;
            if (list.Departments.Count > 0)
            {
                foreach (var el in list.CountOfEmpPerDep())
                {
                    string ending = CheckEndingOfWord(el); //задаем окончание слова
                    output += String.Format($"Отдел \"{el.Key}\": {el.Value} cотрудник{ending}.\r");
                }
            }
            else
                output = "Нет отделов";
            MessageBox.Show(output);
        }

        //Проверка и задание окончания слова за цифрой
        private string CheckEndingOfWord(KeyValuePair<string,int> elem)
        {
                var ending = string.Empty;
                if (regexMany.IsMatch(elem.Value.ToString()))
                    ending = endingMany;
                else
                {
                    if (regexSingle.IsMatch(elem.Value.ToString()))
                        ending = endingSingle;
                }
            return ending;
        }

        //Выход
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
