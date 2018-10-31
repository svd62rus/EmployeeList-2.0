using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    public partial class FormChangeRemDep : Form
    {
        private EmployeeList list; //лист таблиц
        private Form1 mainForm; //главная форма для обновления
        private DataGridView dataGrid; //датагрид
        private DataGridView dataGridEmp; //датагрид сотрудников
        private Department requiredDep; //искомый отдел

        private string oper; //операция

        //строковые константы
        private const string dep = "отдел";

        public FormChangeRemDep(EmployeeList list, Form1 mainForm, DataGridView dataGrid, DataGridView dataGridEmp,string operation)
        {
            InitializeComponent();
            oper = operation;
            Text = oper + " " + dep; //задаем заголовок формы
            labelDepIdOrName.Text += oper.ToLower(); //задаем окончание текста лейбла
            ButtonOK.Text = operation; //задаем название кнопки действия
            //передаем параметры главной формы
            this.list = list;
            this.mainForm = mainForm;
            this.dataGrid = dataGrid;
            this.dataGridEmp = dataGridEmp;
            dataGrid.ClearSelection();
            //устанавливаем доступность элементов
            TextBoxNewDepName.Enabled = false;
            ButtonOK.Enabled = false;
            ButtonSearch.Enabled = false;
            TextBoxDesiredDep.TextChanged += TextBoxDesiredDep_TextChanged; //подписка на изменение текстбокса поиска
            TextBoxNewDepName.TextChanged += TextBoxNewDepName_TextChanged; //подписка на изменение текстбокса нового имени отдела

        }
        
        //Проверка на пустую строку поиска
        private void TextBoxDesiredDep_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxDesiredDep.Text))
                ButtonSearch.Enabled = false;
            else
                ButtonSearch.Enabled = true;
        }
        //Проверка на пустую строку нового имени отдела
        private void TextBoxNewDepName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNewDepName.Text))
                ButtonOK.Enabled = false;
            else
                ButtonOK.Enabled = true;
        }
  
        //Кнопка "Найти"
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var strId = TextBoxDesiredDep.Text; //данные для поиска
            bool same = false; //true - поиск успешен, false - нет
            bool isInt = false; //true - введен Id, false - введено имя 
            if (int.TryParse(strId, out int id))
            {
                isInt = true;
                same = SearchDep(id,ref requiredDep); //ищем отдел
            }
            else
                same = SearchDep(strId, ref requiredDep); //ищем отдел  
            if (!same && isInt)
                MessageBox.Show($"Отдела №{id} нет");
            if (!same && !isInt)
                MessageBox.Show($"Отдела c именем '{strId}' нет");
            if (same) //при нахождении отдела, изменяем доступность элементов формы
            {
                mainForm.SelectRowInDataGrid(dataGrid,requiredDep.Id);
                TextBoxDesiredDep.Text = requiredDep.Name;
                TextBoxDesiredDep.Enabled = false;
                ButtonSearch.Enabled = false;
                if (oper==Program.Действия.Изменить.ToString())
                    TextBoxNewDepName.Enabled = true;
                else
                {
                    TextBoxNewDepName.TextChanged -= TextBoxNewDepName_TextChanged; //отписка от изменений текстбокса нового имени отдела
                    ButtonOK.Enabled = true;
                }
            }          
        }
        //Поиск отдела по Id
        private bool SearchDep(int id, ref Department requiredDep)
        {
            foreach (var el in list.Departments)
            {
                if (el.Id == id)
                {
                    requiredDep = el; //присваиваем значение искомому отделу
                    return true;
                }
            }
            return false;
        }
        //Поиск отдела по имени
        private bool SearchDep(string name, ref Department requiredDep)
        {
            foreach (var el in list.Departments)
            {
                var currentName = el.Name.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из текущего имени
                var inputName = name.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из переданного имени
                if (currentName==inputName)
                {
                    requiredDep = el;//присваиваем значение искомому отделу
                    return true;
                }
            }
            return false;
        }
        //Поиск отдела по имени, исключая старое имя
        private bool SearchDep(string name, ref Department requiredDep, string oldName)
        {
            oldName = oldName.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из cтарого имени
            var inputName = name.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из переданного имени
            foreach (var el in list.Departments)
            {
                var currentName = el.Name.ToLower().Replace(" ", String.Empty); //убираем регистр и пробелы из текущего имени
                //проверяем что мы не ищем тоже самое
                if (currentName != oldName)
                {
                    //проверяем совпадение
                    if (currentName == inputName)
                    {
                        requiredDep = el;//присваиваем значение искомому отделу
                        return true;
                    }
                }
                
            }
            return false;
        }

        //Кнопка "Изменить" или "Удалить"
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string oldName = requiredDep.Name; //сохраняем старое имя отдела
            //если операция - изменение
            if (oper == Program.Действия.Изменить.ToString())
            {
                var newDepName = TextBoxNewDepName.Text;
                Department sameDep=null;
                //проверяем, что похожего отдела нет. если меняем тот же отдел, проверка исключается
                if (SearchDep(TextBoxNewDepName.Text,ref sameDep,oldName))
                {
                    mainForm.SelectRowInDataGrid(dataGrid, sameDep.Id); //выделяем строку с похожим отделом
                    MessageBox.Show($"Отдел '{newDepName}' или похожий уже есть!");
                }   
                else
                {
                    list.СhangeDep(requiredDep, TextBoxNewDepName.Text); //изменяем название отдела
                    mainForm.RefreshMainForm(dataGrid, list.Departments); //обновляем главную форму
                    mainForm.SelectRowInDataGrid(dataGrid, requiredDep.Id); //выделяем нужную строку
                    MessageBox.Show($"Имя отдела '{oldName}' изменено на '{requiredDep.Name}'");
                    RestoreVisibleToOrigin(oper); //восстанавливаем видимость элементов
                }                
            }
            //иначе (операция - удаление)
            if (oper == Program.Действия.Удалить.ToString())
            {
                //если отдел содержит сотрудников
                if (IsEmpInDep())
                {
                    MessageBox.Show($"Отдел '{requiredDep.Name}' удалить нельзя, так как он содержит сотрудников");
                    RestoreVisibleToOrigin(oper);
                }   
                //иначе
                else
                {
                    list.RemoveDep(requiredDep.Id); //удаляем отдел
                    mainForm.RefreshMainForm(dataGrid,list.Departments); //обновляем главную форму
                    mainForm.RefreshMainForm(dataGridEmp, list.Employees);
                    dataGrid.ClearSelection(); //убираем выделение строки
                    dataGridEmp.ClearSelection();
                    MessageBox.Show($"Отдел {requiredDep.Name} удален");
                    RestoreVisibleToOrigin(oper);
                }

            }
        }

        //Проверка наличия сотрудников в отделе
        private bool IsEmpInDep()
        {
            foreach (var elem in list.Employees)
            {
                if (elem.DepartmentId == requiredDep.Id)
                    return true;
            }

            return false;
        }

        //Возвращение элементов формы в исходный вид
        private void RestoreVisibleToOrigin(string oper)
        {
            if (oper == Program.Действия.Изменить.ToString())
            {
                TextBoxNewDepName.Clear();
                TextBoxNewDepName.Enabled = false;
            }
            TextBoxDesiredDep.Clear();
            TextBoxDesiredDep.Enabled = true;
            ButtonSearch.Enabled = false;
            ButtonOK.Enabled = false;
        }

        //Кнопка "Отмена"
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
