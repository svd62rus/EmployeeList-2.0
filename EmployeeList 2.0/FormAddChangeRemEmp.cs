using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    public partial class FormAddChangeRemEmp : Form
    {
        private const string _emptyDepField = "[не выбрано]"; //пустое поле комбобокса с отделами

        private EmployeeList list; //лист таблиц
        private Form1 mainForm; //главная форма для обновления
        private DataGridView dataGrid; //датагрид
        private Employee requiredEmp; //искомый сотрудник

        private string oper; //операция

        //строковые константы
        private const string emp = "сотрудника";

        public FormAddChangeRemEmp(EmployeeList list, Form1 mainForm, DataGridView dataGrid, string operation)
        {
            InitializeComponent();
            oper = operation;
            Text = oper + " " + emp; //задаем заголовок формы
            ButtonOK.Text = operation; //задаем название кнопки действия
            this.list = list;
            this.mainForm = mainForm;
            this.dataGrid = dataGrid;
            dataGrid.ClearSelection();
            SetEnabledSearchButton(oper);//устанавливаем доступность кнопки поиска
            ComboBoxDeps.DropDownStyle = ComboBoxStyle.DropDownList; //делаем комбобокс нередактируемым
            FillDepsList(list.Departments); //заполняем комбобокс отделами            
        }

        //Заполнение списка отдела для выбора
        private void FillDepsList(List<EmpClasses.Department> depList)
        {
            ComboBoxDeps.Items.Add(_emptyDepField); //добавляем пункт по умолчанию
            ComboBoxDeps.SelectedIndex = 0; //его индекс нулевой 
            for (int i = 0; i < depList.Count; i++)
            {
                ComboBoxDeps.Items.Add(depList[i].Id + ". " + depList[i].Name); //добавляем отдел в комбобокс
            }
        }

        //Проверка ФИО на заполнение
        private bool CheckFillOfFields(Dictionary<string, string> fields)
        {
            foreach (var el in fields)
            {
                var checkVar = new CheckTextString(el.Value);
                if(!checkVar.CheckText())
                    return false;
            }

            return true;
        }
        //Формирование строки с ФИО
        private string MakeFullName(Dictionary<string, string> fioFields)
        {
            string space = " "; //пробел - разделитель
            return string.Join(space,
                fioFields[Program.ФИО.Фамилия.ToString()],
                fioFields[Program.ФИО.Имя.ToString()],
                fioFields[Program.ФИО.Отчество.ToString()]);
        }
        //Кнопка Кнопка "Изменить","Добавить", "Удалить"
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (oper == Program.Действия.Удалить.ToString())
            {
                RemoveDepAndRefreshElems();
                MessageBox.Show($"Сотрудник \"{requiredEmp.FullName}\" удален!");
            }
            else
            {
                var fioFields = MakeFullNameFromTextBox(); //создаем ФИО типа словарь из текстбоксов
                //проверяем заполнено ли ФИО и выбран ли отдел отличный от того, который по умолчанию
                if (CheckFillOfFields(fioFields) && ComboBoxDeps.SelectedItem.ToString() != _emptyDepField)
                {
                    if (double.TryParse(TextBoxSalary.Text, out double salary)) //проверяем введена ли правильная зарплата
                    {
                        var newFullName = MakeFullName(fioFields); //формируем cтроку с ФИО
                        if (list.Employees.Count > 0) //если кол-во сотрудников > 0
                        {
                            if (oper == Program.Действия.Добавить.ToString())
                            {
                                if(CheckDub(newFullName,fioFields,salary))
                                    MessageBox.Show($"Сотрудник \"{newFullName}\" добавлен!");
                                else
                                MessageBox.Show($"Cотрудник \"{newFullName}\" или похожим именем уже есть!");
                                
                            }
                            if (oper == Program.Действия.Изменить.ToString())
                            {
                                if(CheckDub(newFullName,fioFields,salary,out string oldFullName))
                                    MessageBox.Show($"Сотрудник \"{oldFullName}\" изменен!");
                                else
                                    MessageBox.Show($"Cотрудник \"{newFullName}\" или похожим именем уже есть!");
                            }
                        }
                        else //если cотрудников < 0 - добавить в любом случае
                        {
                            MakeActionAndShowChanges(fioFields, ComboBoxDeps.SelectedIndex,salary, Program.Действия.Добавить.ToString()); //вызываем добавление //вызываем добавление
                            MessageBox.Show($"Сотрудник \"{newFullName}\" добавлен");
                        }
                    }
                    else MessageBox.Show("Зарплата должна быть указана в числовом виде!\rДля отделения руб. от коп. используйте запятую."); //зарплата введена неверно
                }
                else MessageBox.Show("Вы неверно заполнили поля,\rлибо не выбрали отдел!"); //поля фио не заполнены, либо отдел выбран по умолчанию
            }
        }

        //Процесс действий с cотрудником и отображение изменений в датагриде
        private void MakeActionAndShowChanges(Dictionary<string, string> fioFields, int depId, double salary, string oper)
        {
            int selectedRow = 0;
            ClearTextBoxes(); //очищаем текстбоксы
            if (oper == Program.Действия.Добавить.ToString())
            {
                selectedRow = list.AddEmp(
                    fioFields[Program.ФИО.Фамилия.ToString()],
                    fioFields[Program.ФИО.Имя.ToString()],
                    fioFields[Program.ФИО.Отчество.ToString()],
                    depId,
                    salary);
            }
            if (oper == Program.Действия.Изменить.ToString())
            {
                selectedRow = list.ChangeEmp(requiredEmp,
                    fioFields[Program.ФИО.Фамилия.ToString()],
                    fioFields[Program.ФИО.Имя.ToString()],
                    fioFields[Program.ФИО.Отчество.ToString()],
                    depId,
                    salary);
                RestoreElemsAfterAction();
            }
            mainForm.RefreshMainForm(dataGrid, list.Employees); //обновляем главную форму
            mainForm.SelectRowInDataGrid(dataGrid, selectedRow); //выделяем новую строку с данными
        }

        //Кнопка "Отмена"
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Кнопка "Найти"
        private void ButtonSearch_Click(object sender, EventArgs e)
        { 
            var fioFields = MakeFullNameFromTextBox();
            bool same = false; //true - поиск успешен, false - нет
            var empFullName = MakeFullName(fioFields); //cоздаем строку с ФИО
            same = SearchEmp(empFullName, ref requiredEmp, out bool isFired); 
            if (same) //если поиск успешен
            {
                if (!isFired)
                {
                    ButtonSearch.Enabled = false; //делаем кнопку поиска недоступной
                    if (oper == Program.Действия.Изменить.ToString())
                    {
                        ComboBoxDeps.Enabled = true;
                        TextBoxSalary.Enabled = true;
                    }
                    else //при удалении делаем недоступными и поля ФИО тоже
                        DisableFullNameFields();
                    ButtonOK.Enabled = true; 
                }
                FillTextBoxes(); //далее считываем данные сотрудника и заполняем соответствующие поля
                mainForm.SelectRowInDataGrid(dataGrid, requiredEmp.Id); //выделяем найденную строку
                if (isFired)
                    MessageBox.Show($"Cотрудник \"{empFullName}\" уволен\rи больше не доступен для изменений!");
            }
            else
                MessageBox.Show($"Cотрудника \"{empFullName}\" нет!");
        }

        //Поиск сотрудника по ФИО
        private bool SearchEmp(string fullName, ref Employee requiredEmp, out bool isFired)
        {
            foreach (var el in list.Employees)
            {
                var currentFullName = el.FullName.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из текущего имени
                var inputFullName = fullName.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из переданного имени
                if (currentFullName == inputFullName)
                {
                    requiredEmp = el;//присваиваем значение искомому отделу
                    isFired = el.IsFired ? true : false;
                    return true;
                }
            }
            isFired = false;
            return false;
        }
        private bool SearchEmp(string fullName, ref Employee requiredEmp, string oldFullName)
        {
            oldFullName = oldFullName.ToLower().Replace(" ", string.Empty); //убираем регистр и пробелы из cтарого ФИО
            var inputFullName = fullName.ToLower().Replace(" ", string.Empty); //убираем регистр и пробелы из переданного имени
            foreach (var el in list.Employees)
            {
                var currentFullName = el.FullName.ToLower().Replace(" ", string.Empty); //убираем регистр и пробелы из текущего имени
                //проверяем что мы не ищем тоже самое
                if (currentFullName != oldFullName)
                {
                    //проверяем совпадение
                    if (currentFullName == inputFullName)
                    {
                        requiredEmp = el;//присваиваем значение искомому отделу
                        return true;
                    }
                }

            }

            return false;
        }
        //Проверка на ввод корректной величины зарплаты
        private void TextBoxSalary_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxSalary.Text.Length > Program.digitInSalary)
                ButtonOK.Enabled = false;
            else
                ButtonOK.Enabled = true;
        }

        //Восстановление видимости элементов
        private void RestoreElemsVisible()
        {
            TextBoxSurname.Enabled = true;
            TextBoxName.Enabled = true;
            TextBoxPatronymic.Enabled = true;
            TextBoxSurname.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            TextBoxPatronymic.Text = string.Empty;
            TextBoxSalary.Text = string.Empty;
            ComboBoxDeps.SelectedIndex = 0;
            ComboBoxDeps.Enabled = false;
            TextBoxSalary.Enabled = false;
            ButtonOK.Enabled = false;
            ButtonSearch.Enabled = true;
        }
        //Восстановление элементов после действия
        private void RestoreElemsAfterAction()
        {
            ComboBoxDeps.SelectedIndex = 0;
            ComboBoxDeps.Enabled = false;
            TextBoxSalary.Enabled = false;
            ButtonOK.Enabled = false;
            ButtonSearch.Enabled = true;
        }

        //Проверка на дубликаты при добавлении
        private bool CheckDub(string newFullName, Dictionary<string, string> fioFields, double salary)
        {
            //проверяем дубликаты
            if (SearchEmp(newFullName, ref requiredEmp, out bool isFired))
            {
                var selectedRow = requiredEmp.Id;
                mainForm.SelectRowInDataGrid(dataGrid, selectedRow); //выделяем строку-дубликат
                return false;
            }
            else
            {
                MakeActionAndShowChanges(fioFields, ComboBoxDeps.SelectedIndex,salary, Program.Действия.Добавить.ToString()); //вызываем добавление
                return true;
            }
        }
        //Проверка на дубликаты при изменении
        private bool CheckDub(string newFullName, Dictionary<string, string> fioFields, double salary, out string oldFullName)
        {
            Employee sameEmp = null;
            oldFullName = requiredEmp.FullName;
            //проверяем, что похожего отдела нет. если меняем тот же отдел, проверка исключается
            if (SearchEmp(newFullName, ref sameEmp, requiredEmp.FullName))
            {
                var selectedRow = sameEmp.Id;
                mainForm.SelectRowInDataGrid(dataGrid, selectedRow); //выделяем строку-дубликат
                return false;
            }
            else
            {
                MakeActionAndShowChanges(fioFields, ComboBoxDeps.SelectedIndex,salary, Program.Действия.Изменить.ToString()); //вызываем изменение
                return true;
                
            }
        }

        //Cоздание ФИО из текстбоксов
        private Dictionary<string, string> MakeFullNameFromTextBox()
        {
            var fioFields = new Dictionary<string, string>
            {
                {Program.ФИО.Фамилия.ToString(),TextBoxSurname.Text},
                {Program.ФИО.Имя.ToString(),TextBoxName.Text},
                {Program.ФИО.Отчество.ToString(),TextBoxPatronymic.Text}
            };
            return fioFields;
        }

        //Удаление отдела и обновление элементов
        private void RemoveDepAndRefreshElems()
        {
            list.RemoveEmp(requiredEmp.Id); //удаляем отдел
            mainForm.RefreshMainForm(dataGrid, list.Employees); //обновляем главную форму
            dataGrid.ClearSelection(); //убираем выделение строки
            RestoreElemsVisible(); //восстанавливаем видимость элементов           
        }
        //Очистка текстбоксов
        private void ClearTextBoxes()
        {
            TextBoxSurname.Clear();
            TextBoxName.Clear();
            TextBoxPatronymic.Clear();
            TextBoxSalary.Clear();
        }

        //Заполнение текстбоксов
        private void FillTextBoxes()
        {
            TextBoxSurname.Text = requiredEmp.Surname;
            TextBoxName.Text = requiredEmp.Name;
            TextBoxPatronymic.Text = requiredEmp.Patronymic;
            if (!requiredEmp.IsFired)
            {
                TextBoxSalary.Text = requiredEmp.Salary.ToString();
                ComboBoxDeps.SelectedIndex = requiredEmp.DepartmentId;
            }
        }

        //Выключение доступности полей ФИО
        private void DisableFullNameFields()
        {
            TextBoxSurname.Enabled = false;
            TextBoxName.Enabled = false;
            TextBoxPatronymic.Enabled = false;
        }

        //Установка доступности кнопки поиска
        private void SetEnabledSearchButton(string operation)
        {
            if (operation == Program.Действия.Добавить.ToString())
                ButtonSearch.Visible = false;
            else
            {
                ComboBoxDeps.Enabled = false;
                TextBoxSalary.Enabled = false;
                ButtonOK.Enabled = false;
            }
        }
    }
}
