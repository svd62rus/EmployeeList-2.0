using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EmployeeList_2._0.EmpClasses;
using ExportManager;

namespace EmployeeList_2._0
{
    public partial class Form1 : Form, ILogger
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
        static private string nameOfExportHired = "Работники";
        static private string nameOfExportFired = "Уволенные";

        public delegate void DisplayMethod<T>(DataGridView dataGrid, List<T> displayList); /*делегат для:
                                             - передачи метода вывода данных в таблицы
                                            */

        private bool moreFilter = true;
        private bool lessFilter = false;

        public Form1()
        {
            InitializeComponent();
            WriteLog("---Start Log---");
            list = new EmployeeList(); //cоздаем экземпляр таблиц
            DataGridAddColumns(); //добавляем столбцы
            SetDataGridParams(DataGridDeps); //устанавливаем параметры датагрида отделов           
            SetDataGridParams(DataGridEmps); //устанавливаем параметры датагрида сотрудников
            SetInfoLabelText(); //устанавливаем дефолтный текст в инфо-лейблах
            ComboBoxDeps.DropDownStyle = ComboBoxStyle.DropDownList; //делаем комбобокс нередактируемым
            TextBoxMaxSalary.Enabled = false;
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
            DataGridEmps.Columns.Add("Salary", "Зарплата, " + сurrency);
            DataGridEmps.Columns.Add("Department", "Отдел");
            DataGridEmps.Columns.Add("DateHired", "Нанят");
            DataGridEmps.Columns.Add("DateFired", "Уволен");
            WriteLog("Columns add.");
        }
        //Установка параметров датагрида
        private void SetDataGridParams(DataGridView dataGrid)
        {
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            WriteLog("DataGrid parameters set.");
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
            WriteLog("Info label text set.");
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
            WriteLog($"Fill department combobox. Count of departments = {count}.");
        }
        //Добавление пункта по-умолчанию в список отделов
        private void AddDefaultSelect()
        {
            ComboBoxDeps.Items.Clear();
            ComboBoxDeps.Items.Add(_emptyDepField); //добавляем пункт по умолчанию
            ComboBoxDeps.SelectedIndex = 0; //его индекс нулевой 
            WriteLog("Add default item in department combobox.");
        }

        //Обновление отделов
        public void RefreshMainForm(DataGridView dataGrid, List<Department> displayList)
        {
            Display(dataGrid, displayList);
            FillDepsList(list.Departments);
            WriteLog("Departments refresh.");
        }
        //Обновление сотрудников
        public void RefreshMainForm(DataGridView dataGrid, List<Employee> displayList)
        {
            ClearFilterTexBoxes();
            Display(dataGrid, displayList);
            RefreshTotalInfo();
            FillDepsList(list.Departments);
            WriteLog("Employeers refresh.");
        }
        //Очистка датагрида
        private void ClearDataGrid(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count > 1)
            {
                dataGrid.Rows.Clear(); //очищаем датагрид
                WriteLog($"Datagrid \"{dataGrid.Name}\" clear. Count of row in datagrid = {dataGrid.Rows.Count}");
            }     
        }

        //Вывод отделов
        public void Display(DataGridView dataGrid, List<Department> depList)
        {
            ClearDataGrid(dataGrid); //очищаем датагрид
            foreach (var el in depList)
            {
                string[] row = { el.Id.ToString(), el.Name, el.DateCreate.ToLongDateString() };
                dataGrid.Rows.Add(row); //добавляем массив строк в датагрид
            }
            WriteLog($"Department is display. Count of department = {depList.Count}.");
        }
        //Вывод сотрудников
        public void Display(DataGridView dataGrid, List<Employee> empList)
        {
            ClearDataGrid(dataGrid); //очищаем датагрид
            foreach (var el in empList)
            {
                string salary = string.Empty;
                if (!el.IsFired)
                    salary = string.Format($"{el.Salary:F2}");
                string[] row = { el.Id.ToString(), el.FullName, salary, MakeDepName(el),
                    el.DateHired.ToLongDateString(), MakeDateFired(el)};
                dataGrid.Rows.Add(row); //добавляем массив строк в датагрид
            }
            WriteLog($"Employeers is display. Count of employeers = {empList.Count}.");
        }
        //Cоздание строки с датой увольнения
        private string MakeDateFired(Employee emp)
        {
            DateTime dateFired;
            if (emp.DateFired != null)
            {
                dateFired = (DateTime)emp.DateFired;
                WriteLog($"Employee \"{emp.FullName}\". Date of fired = {dateFired.ToLongDateString()}.");
                return dateFired.ToLongDateString();
            }
            else
                return emp.DateFired.ToString();
        }
        //Cоздание строки с именем отдела
        private string MakeDepName(Employee emp)
        {
            foreach (var elem in list.Departments)
            {
                if (elem.Id == emp.DepartmentId)
                {
                    WriteLog($"String with name of department #{elem.Id} created.");
                    return elem.Name;
                }
                    
            }

            return null;
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
                WriteLog($".dat file is loaded.");
            }
            else
            {
                WriteLog($".dat file is not loaded. ERROR: {ex.Message}");
                MessageBox.Show($"Загрузка невозможна. Ошибка: {ex.Message}");
            }
                
        }
        //Загрузка
        private Exception LoadTables(ref EmployeeList list, DisplayMethod<Department> displayDeps,
            DisplayMethod<Employee> displayEmps)
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
            WriteLog("Data load success.");
            return null;
        }
        //Файл-Сохранить
        private void ToolStripMenuSave_Click(object sender, EventArgs e)
        {
            var ex = SaveTables(list); //сохраняем изменения в файл
            if (ex == null)
            {
                WriteLog(".dat is save.");
                MessageBox.Show("Данные сохранены!");
            }
                
            else
            {
                WriteLog($".dat file is not save. ERROR: {ex.Message}");
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
            WriteLog("Form 1 is enabled.");
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
            WriteLog($"Total info refresh. Count of employees = {list.Employees.Count}.");
        }

        //Выделение конкретной строки с данными
        public void SelectRowInDataGrid(DataGridView dataGrid, int numOfRow)
        {
            dataGrid.Rows[numOfRow - 1].Selected = true;
            dataGrid.FirstDisplayedScrollingRowIndex = numOfRow - 1;
            dataGrid.Update();
            WriteLog($"Row #{numOfRow-1} selected.");
        }

        //Cоздание дочерней формы отделов и переключение на нее
        private void ShowChildFormDep(string operation)
        {
            Enabled = false;
            var childForm = new FormChangeRemDep(list, this, DataGridDeps, DataGridEmps, operation); //создаем форму изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Child departments form \"{childForm.Name}\" created and activate.");
        }
        //Отделы-Добавить
        private void MenuAddDep_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var formAddDep = new FormAddDep(list, this, DataGridDeps); //создаем форму добавления отдела
            formAddDep.Show(); //показываем новую форму
            formAddDep.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Child departments form \"{formAddDep.Name}\" created and activate.");
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
            RefreshMainForm(DataGridEmps, list.Employees);
            Enabled = false;
            var childForm = new FormAddChangeRemEmp(list, this, DataGridEmps, operation); //создаем форму добавления/изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы 
            WriteLog($"Child employee form \"{childForm.Name}\" created and activate.");
        }
        //Cотрудники-Добавить
        private void MenuAddEmp_Click(object sender, EventArgs e)
        {
            if (list.Departments.Count > 0)
                ShowChildFormEmp(Program.Действия.Добавить.ToString()); //вызываем дочернюю форму
            else
            {
                WriteLog("ERROR: not departments for add employee.");
                MessageBox.Show($"Нет отделов для добавления сотрудника!");
            }
                
        }
        //Сотрудники-Изменить
        private void MenuChangeEmp_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(Program.Действия.Изменить.ToString()); //вызываем дочернюю форму
            else
            {
                WriteLog("ERROR: not employeers for change.");
                MessageBox.Show($"Нет сотрудников для изменения!");
            }
                
        }
        //Сотрудники-Удалить
        private void MenuRemoveEmp_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(Program.Действия.Удалить.ToString()); //вызываем дочернюю форму
            else
            {
                WriteLog("ERROR: not employeers for remove.");
                MessageBox.Show($"Нет сотрудников для удаления!");
            }      
        }

        //Cоздание дочерней формы cотрудников и переключение на нее
        private void ShowChildFormEmp()
        {
            Enabled = false;
            var childForm = new FormEmpFire(list, this, DataGridEmps); //создаем форму увольнения сотрудника
            childForm.Show(); //показываем новую форму
            childForm.FormClosed += new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Child employee form \"{childForm.Name}\" created and activate.");
        }

        //Вывод данных по отделу
        private void ComboBoxDeps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDeps.SelectedItem.ToString() != _emptyDepField)
            {
                SelectRowInDataGrid(DataGridDeps, ComboBoxDeps.SelectedIndex);
                WriteLog($"Select {ComboBoxDeps.SelectedItem.ToString()}.");
                SetDepInfoLabelText(); //устанавливаем значение инфо-лейблов отдела
            }
            else
            {
                WriteLog($"Select none.");
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
            WriteLog("Department info labels set.");
        }
        //Вывод сообщения об отсуствии данных для отдела
        private void NotDataMessage()
        {
            SumOfDepSalary.Text = sumOfDepSalaryTitle + noDataString;
            AvgOfDepSalary.Text = avgOfDepSalaryTitle + noDataString;
            CountOfDepEmp.Text = countOfDepEmpTitle + noDataString;
            WriteLog("Not data message show.");
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
                    WriteLog("Employeers per department show.");
                }
            }
            else
            {
                WriteLog("ERROR: not department.");
                output = "Нет отделов";
            }    
            MessageBox.Show(output);
        }

        //Проверка и задание окончания слова за цифрой
        private string CheckEndingOfWord(KeyValuePair<string, int> elem)
        {
            var ending = string.Empty;
            if (regexMany.IsMatch(elem.Value.ToString()))
                ending = endingMany;
            else
            {
                if (regexSingle.IsMatch(elem.Value.ToString()))
                    ending = endingSingle;
            }
            WriteLog("Ending of word after digit success.");
            return ending;
        }

        //Выход
        private void MenuExit_Click(object sender, EventArgs e)
        {
            WriteLog("Exit from app.");
            WriteLog("---End Log---");
            Close();
        }

        //Кнопка "Фильтр"
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            if (CheckFilters(out List<Employee> emps))
            {
                WriteLog("Filter apply.");
                Display(DataGridEmps, emps);
            }

            else
            {
                WriteLog("ERROR: wrong filter value.");
                MessageBox.Show("Неверное знач-е фильтра!");
            }
                
        }
        //Проверка фильтров
        private bool CheckFilters(out List<Employee> emps)
        {
            string strSalary = string.Empty;
            string strMaxSalary = string.Empty;
            if (moreFilter && lessFilter)
            {
                strSalary = TextBoxMinSalary.Text;
                strMaxSalary = TextBoxMaxSalary.Text;
                WriteLog("Check filter success.");
                bool result = CheckAndCallRangeFilter(strSalary, strMaxSalary, out List<Employee> employees);
                emps = employees;
                return result;
            }
            else
            {
                strSalary = moreFilter ? TextBoxMinSalary.Text : TextBoxMaxSalary.Text;
                WriteLog("Check filter success.");
                bool result = CheckAndCallSimpleFilter(strSalary, out List<Employee> employees);
                emps = employees;
                
                return result;
            }
        }
        //Проверка и вызов фильтра по диапазону
        private bool CheckAndCallRangeFilter(string strSalary, string strMaxSalary, out List<Employee> employees)
        {
            if (double.TryParse(strSalary, out double minSalary) && double.TryParse(strMaxSalary, out double maxSalary))
            {
                var filterObj = new FilterClass(minSalary, maxSalary);
                WriteLog($"Range filter activate. Min salary = {minSalary}; Max salary = {maxSalary}.");
                employees = CallFilter(filterObj);
                return true;
            }
            else
            {
                employees = null;
                return false;
            }
        }
        //Проверка и вызов фильтра по одной стороне (простой)
        private bool CheckAndCallSimpleFilter(string strSalary, out List<Employee> employees)
        {
            if (double.TryParse(strSalary, out double salary))
            {
                WriteLog($"Simple filter activate. Salary = {salary}.");
                var filterObj = new FilterClass(moreFilter, lessFilter, salary);
                employees = CallFilter(filterObj);
                return true;
            }
            else
            {
                employees = null;
                return false;
            }
        }
        //Вызов фильтра
        private List<Employee> CallFilter(FilterClass filterObj)
        {
            var tempList = list;
            WriteLog("Filter calling.");
            return tempList.EmployeeFilter(tempList.SalaryFilter, filterObj);
        }
        //Сброс фильтра
        private void ButtonResetFilter_Click(object sender, EventArgs e)
        {
            RefreshMainForm(DataGridEmps, list.Employees);
            RadioButtonMore.Checked = true;
        }
        //Выбран фильтр "больше"
        private void RadioButtonMore_CheckedChanged(object sender, EventArgs e)
        {
            moreFilter = true;
            lessFilter = false;
            TextBoxMinSalary.Enabled = true;
            TextBoxMaxSalary.Enabled = false;
            TextBoxMaxSalary.Clear();
        }
        //Выбран фильтр "меньше"
        private void RadioButtonLess_CheckedChanged(object sender, EventArgs e)
        {
            moreFilter = false;
            lessFilter = true;
            TextBoxMaxSalary.Enabled = true;
            TextBoxMinSalary.Enabled = false;
            TextBoxMinSalary.Clear();
        }
        //Выбран фильтр "диапазон"
        private void RadioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            moreFilter = true;
            lessFilter = true;
            TextBoxMaxSalary.Enabled = true;
            TextBoxMinSalary.Enabled = true;
        }
        //Очистка текстбоксов фильтра
        private void ClearFilterTexBoxes()
        {
            TextBoxMinSalary.Clear();
            TextBoxMaxSalary.Clear();
            WriteLog("TextBoxex of filter clear.");
        }

        //Cброс выделения кнопок сортировок
        private void ResetColorOfSortButton()
        {
            ButtonSortAZ.BackColor = Color.Transparent;
            ButtonSortAZ.ForeColor = Color.Black;
            ButtonSortZA.BackColor = Color.Transparent;
            ButtonSortZA.ForeColor = Color.Black;
            ButtonSort09.BackColor = Color.Transparent;
            ButtonSort09.ForeColor = Color.Black;
            ButtonSort90.BackColor = Color.Transparent;
            ButtonSort90.ForeColor = Color.Black;
            WriteLog("Reset color of sort buttons.");
        }
        //Cортировка А-Я
        private void ButtonSortAZ_Click(object sender, EventArgs e)
        {
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSortAZ.BackColor = Color.DeepSkyBlue;
            ButtonSortAZ.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Алфавит);
            WriteLog("A-Z sort activated.");
            Display(DataGridEmps, list.Employees);
        }
        //Cортировка Я-А
        private void ButtonSortZA_Click(object sender, EventArgs e)
        {
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSortZA.BackColor = Color.DeepSkyBlue;
            ButtonSortZA.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Алфавитобратная);
            WriteLog("Z-A sort activated.");
            Display(DataGridEmps, list.Employees);
        }

        //Cортировка 0-9
        private void ButtonSort09_Click(object sender, EventArgs e)
        {
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSort09.BackColor = Color.DeepSkyBlue;
            ButtonSort09.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Позарплате);
            WriteLog("0-9 sort activated.");
            Display(DataGridEmps, list.Employees);
        }
        //Cортировка 9-0
        private void ButtonSort90_Click(object sender, EventArgs e)
        {
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSort90.BackColor = Color.DeepSkyBlue;
            ButtonSort90.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Позарплатеобратная);
            WriteLog("9-0 sort activated.");
            Display(DataGridEmps, list.Employees);
        }

        //Сотрудники-Уволить
        private void MenuEmpFire_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(); //вызываем дочернюю форму
            else
            {
                WriteLog("ERROR: not employeers for fired.");
                MessageBox.Show($"Нет сотрудников для увольнения!");
            }
                
        }
        //Экспорт-Работники
        private void MenuExportHire_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
            {
                Export export = new Export(nameOfExportHired, list.FullNames(list.CheckEmpType, true));
                var resOfExport = export.WriteFile();
                if (resOfExport == null)
                {
                    WriteLog($"File export success in \"{nameOfExportHired}\".");
                    MessageBox.Show("Файл экспортирован!");
                }   
                else
                {
                    WriteLog($"File is not export. ERROR: {resOfExport.Message}");
                    MessageBox.Show($"Экспорт невозможен. Ошибка {resOfExport.Message}");
                }
            }
            else
            {
                WriteLog($"ERROR: not employeers for export.");
                MessageBox.Show($"Нет сотрудников для экспорта!");
            }
                
        }
        //Экспорт-Уволенные
        private void MenuExportFire_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
            {
                Export export = new Export(nameOfExportFired, list.FullNames(list.CheckEmpType, false));
                var resOfExport = export.WriteFile();
                if (resOfExport == null)
                {
                    WriteLog($"File export success in \"{nameOfExportFired}\".");
                    MessageBox.Show("Файл экспортирован!");
                }
                    
                else
                {
                    WriteLog($"File is not export. ERROR: {resOfExport.Message}");
                    MessageBox.Show($"Экспорт невозможен. Ошибка {resOfExport.Message}");
                }
            }
            else
            {
                WriteLog($"ERROR: not employeers for export.");
                MessageBox.Show($"Нет сотрудников для экспорта!");
            }
                
        }

        public void WriteLog(string message)
        {
            StreamWriter sw = new StreamWriter(Program.mainLog,true);
            sw.WriteLineAsync($"[{DateTime.Now.ToString()}] : {message}");
            sw.Close();
        }
    }
}
