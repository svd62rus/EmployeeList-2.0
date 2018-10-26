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
    public partial class FormChangeDep : Form
    {
        private EmployeeList list; //лист таблиц
        private Form1 mainForm; //главная форма для обновления
        private DataGridView dataGrid; //датагрид
        private Department requiredDep; //искомый отдел

        public FormChangeDep(EmployeeList list, Form1 mainForm, DataGridView dataGrid)
        {
            InitializeComponent();
            this.list = list;
            this.mainForm = mainForm;
            this.dataGrid = dataGrid;
            dataGrid.ClearSelection();
            textBoxNewDepName.Enabled = false;
            buttonOK.Enabled = false;
            buttonSearch.Enabled = false;
            textBoxDesiredDep.TextChanged += TextBoxDesiredDep_TextChanged; //подписка на изменение текстбокса поиска
            textBoxNewDepName.TextChanged += TextBoxNewDepName_TextChanged; //подписка на изменение текстбокса нового имени отдела

        }
        
        //Проверка на пустую строку поиска
        private void TextBoxDesiredDep_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDesiredDep.Text))
                buttonSearch.Enabled = false;
            else
                buttonSearch.Enabled = true;
        }
        //Проверка на пустую строку нового имени отдела
        private void TextBoxNewDepName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNewDepName.Text))
                buttonOK.Enabled = false;
            else
                buttonOK.Enabled = true;
        }
        //Кнопка "Отмена"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Кнопка "Найти"
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var strId = textBoxDesiredDep.Text; //данные для поиска
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
            if (same) //при нахождении отдела, делаем доступными элементы формы
            {
                mainForm.selectRowInDataGrid(dataGrid,requiredDep.Id);
                textBoxDesiredDep.Enabled = false;
                buttonSearch.Enabled = false;
                textBoxNewDepName.Enabled = true;
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
                if (el.Name == name)
                {
                    requiredDep = el; //присваиваем значение искомому отделу
                    return true;
                }
            }
            return false;
        }
        //Кнопка "Изменить"
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string oldName = requiredDep.Name; //сохраняем старое имя отдела
            list.СhangeDep(requiredDep,textBoxNewDepName.Text); //изменяем название отдела
            mainForm.refreshMainForm(); //обновляем главную форму
            mainForm.selectRowInDataGrid(dataGrid, requiredDep.Id);
            MessageBox.Show($"Имя отдела '{oldName}' изменено на '{requiredDep.Name}'");

            //далее возвращаем элементы формы в исходный вид
            textBoxNewDepName.Clear();
            textBoxDesiredDep.Clear();
            textBoxDesiredDep.Enabled = true;
            buttonSearch.Enabled = false;
            textBoxNewDepName.Enabled = false;
            buttonOK.Enabled = false;
        }
    }
}
