using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    public partial class Form1 : Form, ILogger
    {
        Regex sizeKbLogReg = new Regex(@"\s*LogSizeKb\s*=\s*\d+");
        Regex sizeKbReg = new Regex(@"\d+");
        private int logSizeKb;

        private EmployeeList list; //лист
        private EmployeeList listTemp; //лист для проверки сохранения

        private string emptyDepField = "[не выбрано]"; //пустое поле комбобокса отделов на главной форме

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
        Regex regexMany = new Regex(@"^\d*(1\d|0)$"); //проверка на цифру, после которой у слова будет окончание "ов"
        Regex regexSingle = new Regex(@"^\d*[2,3,4]$"); //-//- окончание "а"

        static private string nameOfFile = "List.dat"; //имя сохраняемого файла
        private string nameOfExportHired = "Работники";
        private string nameOfExportFired = "Уволенные";

        private const string nameOfConfig = "employee_list.conf";

        public delegate void DisplayMethod<T>(DataGridView dataGrid, List<T> displayList); /*делегат для:
                                             - передачи метода вывода данных в таблицы
                                            */

        private bool moreFilter = true;
        private bool lessFilter = false;


        public Form1()
        {
            WriteLog("---Start Log---");
            WriteLog("Info. Приложение запущено");
            ReadConfig();
            InitializeComponent();
            list = new EmployeeList(); //cоздаем экземпляр таблиц
            listTemp = new EmployeeList();
            //listTemp = list;
            DataGridAddColumns(); //добавляем столбцы
            SetDataGridParams(DataGridDeps); //устанавливаем параметры датагрида отделов           
            SetDataGridParams(DataGridEmps); //устанавливаем параметры датагрида сотрудников
            SetInfoLabelText(); //устанавливаем дефолтный текст в инфо-лейблах
            ComboBoxDeps.DropDownStyle = ComboBoxStyle.DropDownList; //делаем комбобокс нередактируемым
            TextBoxMaxSalary.Enabled = false;
        }

        //Чтение конфига и размера логов в нем
        private void ReadConfig()
        {
            try
            {
                StreamReader sr = new StreamReader(nameOfConfig);
                while (!sr.EndOfStream)
                {
                    var str = sr.ReadLine();
                    MatchCollection matchesOne = sizeKbLogReg.Matches(str);
                    if (matchesOne.Count > 0)
                    {
                        foreach (Match match in matchesOne)
                        {
                            MatchCollection matchesTwo = sizeKbReg.Matches(match.ToString());
                            foreach (Match matchTwo in matchesTwo)
                            {
                                logSizeKb = int.Parse(matchTwo.ToString());
                                WriteLog($"Info. Файл {nameOfConfig} прочитан");
                                break;
                            }
                        }
                    }
                    else
                    {
                        logSizeKb = Program.defaultLogSize;
                        sr.Close();
                        ResetConfig();
                        WriteLog($"WARN. Нет нужных параметров в {nameOfConfig} Файл конфигурации перезаписан в default");
                        break;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logSizeKb = Program.defaultLogSize;
                ResetConfig();
                WriteLog($"ERROR. Невозможно прочитать {nameOfConfig}. Ошибка: {ex.Message}");
                WriteLog($"Info. Файл конфигурации перезаписан в default");
            }

        }
        //Сброс конфига
        private void ResetConfig()
        {
            try
            {
                StreamWriter sw = new StreamWriter(nameOfConfig, false);
                sw.WriteLineAsync($"LogSizeKb = {Program.defaultLogSize}");
                sw.Close();
            }
            catch (Exception ex)
            {
                WriteLog($"ERROR. Невозможно перезаписать {nameOfConfig}. Ошибка: {ex.Message}");
            }

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
        private void FillDepsList(List<Department> depList)
        {
            int selectedIndex = 0;
            int count = ComboBoxDeps.Items.Count;
            bool isCurrentItem = false; //обновляется ли текущий выбранный отдел
            if (count > 0)
                selectedIndex = ComboBoxDeps.SelectedIndex;
            AddDefaultSelect(); //добавляем пустое поле по умолчанию
            for (int i = 0; i < depList.Count; i++)
            {
                var currentIndex =
                    ComboBoxDeps.Items.Add(depList[i].Id + ". " + depList[i].Name); //добавляем отдел в комбобокс
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
            ComboBoxDeps.Items.Add(emptyDepField); //добавляем пункт по умолчанию
            ComboBoxDeps.SelectedIndex = 0; //его индекс нулевой 
        }

        //Обновление отделов
        public void RefreshMainForm(DataGridView dataGrid, List<Department> displayList)
        {
            Display(dataGrid, displayList);
            FillDepsList(list.Departments);
        }

        //Обновление сотрудников
        public void RefreshMainForm(DataGridView dataGrid, List<Employee> displayList)
        {
            ClearFilterTexBoxes();
            Display(dataGrid, displayList);
            RefreshTotalInfo();
            //FillDepsList(list.Departments);
        }

        //Очистка датагрида
        private void ClearDataGrid(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count > 1)
            {
                dataGrid.Rows.Clear(); //очищаем датагрид
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
                string[] row =
                {
                    el.Id.ToString(), el.FullName, salary, MakeDepName(el),
                    el.DateHired.ToLongDateString(), MakeDateFired(el)
                };
                dataGrid.Rows.Add(row); //добавляем массив строк в датагрид
            }
        }

        //Cоздание строки с датой увольнения
        private string MakeDateFired(Employee emp)
        {
            DateTime dateFired;
            if (emp.DateFired != null)
            {
                dateFired = (DateTime)emp.DateFired;
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
                    return elem.Name;
                }

            }

            return null;
        }

        //Файл-Загрузить
        private void ToolStripMenuLoad_Click(object sender, EventArgs e)
        {
            bool newLoad = true;
            if (!listTemp.Equals(list))
            {
                var logMessage = SaveWhenChanged(ref newLoad);
                WriteLog(logMessage);
            }
            if (newLoad)
            {
                var ex = LoadTables(ref list, Display, Display); //загружаем файл в программу
                if (ex == null)
                {
                    listTemp = list.Copy();
                    WriteLog($"Info. Файл {nameOfFile} успешно загружен");
                    //убираем выделения строк
                    DataGridDeps.ClearSelection();
                    DataGridEmps.ClearSelection();
                }
                else
                {
                    WriteLog($"ERROR. Файл {nameOfFile} не может быть загружен. Ошибка: {ex.Message}");
                    MessageBox.Show($"Загрузка невозможна. Ошибка: {ex.Message}");
                }
            }
        }

        //Загрузка
        private Exception LoadTables(ref EmployeeList list, DisplayMethod<Department> displayDeps,
            DisplayMethod<Employee> displayEmps)
        {
            BinaryFormatter formatter = new BinaryFormatter
            {
                AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };
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
            {
                listTemp = list;
                WriteLog($"Info. Файл {nameOfFile} успешно сохранен");
                MessageBox.Show("Данные сохранены!");
            }

            else
            {
                WriteLog($"ERROR. Файл {nameOfFile} не может быть сохранен. Ошибка: {ex.Message}");
                MessageBox.Show($"Сохранение невозможно. Ошибка: {ex.Message}");
            }
        }

        //Сохранение
        static Exception SaveTables(EmployeeList list)
        {
            BinaryFormatter formatter = new BinaryFormatter
            {
                AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };
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
            dataGrid.FirstDisplayedScrollingRowIndex = numOfRow - 1;
            dataGrid.Update();
        }

        //Cоздание дочерней формы отделов и переключение на нее
        private void ShowChildFormDep(string operation)
        {
            Enabled = false;
            var childForm =
                new FormChangeRemDep(list, this, DataGridDeps, DataGridEmps,
                    operation); //создаем форму изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed +=
                new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Info. Форма отделов \"{childForm.Name}\" активирована");
        }

        //Отделы-Добавить
        private void MenuAddDep_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var formAddDep = new FormAddDep(list, this, DataGridDeps); //создаем форму добавления отдела
            formAddDep.Show(); //показываем новую форму
            formAddDep.FormClosed +=
                new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Info. Форма отделов \"{formAddDep.Name}\" активирована");
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
            var childForm =
                new FormAddChangeRemEmp(list, this, DataGridEmps,
                    operation); //создаем форму добавления/изменения/удаления отдела
            childForm.Show(); //показываем новую форму
            childForm.FormClosed +=
                new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы 
            WriteLog($"Info. Форма сотрудников \"{childForm.Name}\" активирована");
        }

        //Cотрудники-Добавить
        private void MenuAddEmp_Click(object sender, EventArgs e)
        {
            if (list.Departments.Count > 0)
                ShowChildFormEmp(Program.Действия.Добавить.ToString()); //вызываем дочернюю форму
            else
            {
                WriteLog("WARN. Нет отделов для добавления сотрудника");
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
                WriteLog("WARN. Нет сотрудников для изменения");
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
                WriteLog("WARN. Нет сотрудников для удаления");
                MessageBox.Show($"Нет сотрудников для удаления!");
            }
        }

        //Cоздание дочерней формы cотрудников и переключение на нее
        private void ShowChildFormEmp()
        {
            Enabled = false;
            var childForm = new FormEmpFire(list, this, DataGridEmps); //создаем форму увольнения сотрудника
            childForm.Show(); //показываем новую форму
            childForm.FormClosed +=
                new FormClosedEventHandler(AnyChildFormClosed); //подписываемся на событие закрытия дочерней формы
            WriteLog($"Info. Форма сотрудников \"{childForm.Name}\" активирована");
        }

        //Вывод данных по отделу
        private void ComboBoxDeps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDeps.SelectedItem.ToString() != emptyDepField)
            {
                WriteLog(
                    $"Info. В списке выбора отдела для вывода данных был выбран отдел \"{ComboBoxDeps.SelectedItem.ToString()}\"");
                SelectRowInDataGrid(DataGridDeps, ComboBoxDeps.SelectedIndex);
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
                WriteLog("Info. Вывод кол-ва сотрудников по отделам");
                foreach (var el in list.CountOfEmpPerDep())
                {
                    string ending = CheckEndingOfWord(el); //задаем окончание слова
                    output += String.Format($"Отдел \"{el.Key}\": {el.Value} cотрудник{ending}.\r");
                }
            }
            else
            {
                WriteLog("WARN. Отделов для подсчета кол-ва сотрудников нет");
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

            return ending;
        }

        //Выход
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Кнопка "Фильтр"
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            if (CheckFilters(out List<Employee> emps))
            {
                WriteLog($"Info. К списку сотрудников применен фильтр");
                Display(DataGridEmps, emps);
            }

            else
            {
                WriteLog("WARN. Неверное значение фильтра");
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
                bool result = CheckAndCallRangeFilter(strSalary, strMaxSalary, out List<Employee> employees);
                emps = employees;
                return result;
            }
            else
            {
                strSalary = moreFilter ? TextBoxMinSalary.Text : TextBoxMaxSalary.Text;
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
            return tempList.EmployeeFilter(tempList.SalaryFilter, filterObj);
        }

        //Сброс фильтра
        private void ButtonResetFilter_Click(object sender, EventArgs e)
        {
            WriteLog($"Info. Фильтр сброшен");
            RefreshMainForm(DataGridEmps, list.Employees);
            RadioButtonMore.Checked = true;
        }

        //Выбран фильтр "больше"
        private void RadioButtonMore_CheckedChanged(object sender, EventArgs e)
        {
            WriteLog($"Info. Выбран фильтр \"зарплата-больше\"");
            moreFilter = true;
            lessFilter = false;
            TextBoxMinSalary.Enabled = true;
            TextBoxMaxSalary.Enabled = false;
            TextBoxMaxSalary.Clear();
        }

        //Выбран фильтр "меньше"
        private void RadioButtonLess_CheckedChanged(object sender, EventArgs e)
        {
            WriteLog($"Info. Выбран фильтр \"зарплата-меньше\"");
            moreFilter = false;
            lessFilter = true;
            TextBoxMaxSalary.Enabled = true;
            TextBoxMinSalary.Enabled = false;
            TextBoxMinSalary.Clear();
        }

        //Выбран фильтр "диапазон"
        private void RadioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            WriteLog($"Info. Выбран фильтр \"зарплата-диапазон\"");
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
        }

        //Cортировка А-Я
        private void ButtonSortAZ_Click(object sender, EventArgs e)
        {
            WriteLog("Info. Выбран фильтр сортировки ФИО по алфавиту");
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSortAZ.BackColor = Color.DeepSkyBlue;
            ButtonSortAZ.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Алфавит);
            Display(DataGridEmps, list.Employees);
        }

        //Cортировка Я-А
        private void ButtonSortZA_Click(object sender, EventArgs e)
        {
            WriteLog("Info. Выбран фильтр сортировки ФИО по алфавиту в обратном порядке");
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSortZA.BackColor = Color.DeepSkyBlue;
            ButtonSortZA.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Алфавитобратная);
            Display(DataGridEmps, list.Employees);
        }

        //Cортировка 0-9
        private void ButtonSort09_Click(object sender, EventArgs e)
        {
            WriteLog("Info. Выбран фильтр сортировки зарплаты по возрастанию");
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSort09.BackColor = Color.DeepSkyBlue;
            ButtonSort09.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Позарплате);
            Display(DataGridEmps, list.Employees);
        }

        //Cортировка 9-0
        private void ButtonSort90_Click(object sender, EventArgs e)
        {
            WriteLog("Info. Выбран фильтр сортировки зарплаты по убыванию");
            ClearFilterTexBoxes();
            ResetColorOfSortButton();
            ButtonSort90.BackColor = Color.DeepSkyBlue;
            ButtonSort90.ForeColor = Color.White;
            list.SortEmp((int)Program.Сортировка.Позарплатеобратная);
            Display(DataGridEmps, list.Employees);
        }

        //Сотрудники-Уволить
        private void MenuEmpFire_Click(object sender, EventArgs e)
        {
            if (list.Employees.Count > 0)
                ShowChildFormEmp(); //вызываем дочернюю форму
            else
            {
                WriteLog("WARN: Нет сотрудников для увольнения");
                MessageBox.Show($"Нет сотрудников для увольнения!");
            }

        }

        //Экспорт-Работники
        private void MenuExportHire_Click(object sender, EventArgs e)
        {
            string message = Export(nameOfExportHired, true, out string logString);
            WriteLog(logString);
            MessageBox.Show(message);

        }

        //Экспорт-Уволенные
        private void MenuExportFire_Click(object sender, EventArgs e)
        {
            string message = Export(nameOfExportFired, false, out string logString);
            WriteLog(logString);
            MessageBox.Show(message);

        }
        //Экспорт
        private string Export(string nameOfExport, bool typeOfExport, out string logString)
        {
            if (list.Employees.Count > 0)
            {
                try
                {
                    var checkAndCallDll = new CheckingExportDllClass(list, nameOfExport, typeOfExport);
                    string message = checkAndCallDll.CallExport(out string logMessage);
                    logString = logMessage;
                    return message;
                }
                catch (Exception ex)
                {
                    logString =
                        $"FATAL. Функция экспорта недоступна. Отсутствует библиотека ExportManager.dll Ошибка: {ex.Message}";
                    return $"Функция экспорта недоступна. Отсутствует библиотека ExportManager.dll";
                }
            }
            else
            {
                logString = "WARN. Нет сотрудников для экспорта";
                return $"Нет сотрудников для экспорта!";
            }
        }

        public void WriteLog(string message)
        {
            StreamWriter sw = new StreamWriter(Program.mainLog, true);
            sw.WriteLineAsync($"[{DateTime.Now.ToString()}] : {message}");
            sw.Close();
            FileInfo file = new FileInfo(Program.mainLog);
            //if(file.Length/Program.bytePerKb >= Size)
            //    File.Delete(Program.mainLog);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteLog("Info. Выход из приложения");
            WriteLog("---End Log---");
        }

        //Действия при закрытии приложения
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!listTemp.Equals(list))
            {
                var logMessage = SaveWhenChanged(e);
                WriteLog(logMessage);
            }
        }

        //Сохранение при изменениях
        private string SaveWhenChanged(FormClosingEventArgs e)
        {
            string logMessage = string.Empty;
            switch (MessageBox.Show("Вы хотите сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel))
            {

                case DialogResult.Cancel:
                    logMessage = "Info. Выход из приложения отменен";
                    e.Cancel = true;
                    break;
                case DialogResult.No:
                    logMessage = "Info. Сохранение изменений отклонено";
                    break;
                case DialogResult.Yes:
                    logMessage = "Info. Изменения будут сохранены";
                    var ex = SaveTables(list);
                    if (ex == null)
                    {
                        logMessage = $"Info. Файл {nameOfFile} успешно сохранен";
                    }
                    else
                    {
                        logMessage = $"ERROR. Файл {nameOfFile} не может быть сохранен. Ошибка: {ex.Message}";
                        MessageBox.Show($"Сохранение невозможно. Ошибка: {ex.Message}");
                        e.Cancel = true;
                    }
                    break;
            }
            return logMessage;
        }
        private string SaveWhenChanged(ref bool newLoad)
        {
            string logMessage = string.Empty;
            switch (MessageBox.Show("Вы хотите сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    logMessage = "Info. Загрузка нового файла отменена";
                    newLoad = false;
                    break;
                case DialogResult.No:
                    logMessage = "Info. Сохранение изменений отклонено";
                    newLoad = true;
                    break;
                case DialogResult.Yes:
                    logMessage = "Info. Изменения будут сохранены";
                    var ex = SaveTables(list);
                    if (ex == null)
                    {
                        logMessage = $"Info. Файл {nameOfFile} успешно сохранен";
                        newLoad = true;
                    }
                    else
                    {
                        logMessage = $"ERROR. Файл {nameOfFile} не может быть сохранен. Ошибка: {ex.Message}";
                        newLoad = false;
                        MessageBox.Show($"Сохранение невозможно. Ошибка: {ex.Message}");
                    }
                    break;
            }
            return logMessage;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Учебная программа EmployeeList, версия 2.0.9\rCopyright ©Sushkov D.I.  2018", "О программе");
        }
    }
}
