using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeList_2._0
{
    public partial class FormAddDep : Form
    {
        private EmployeeList list; //лист таблиц
        private Form1 mainForm; //главная форма для обновления
        private DataGridView dataGrid; //датагрид

        public FormAddDep(EmployeeList list,Form1 mainForm, DataGridView dataGrid)
        {
            InitializeComponent();
            this.list = list;
            this.mainForm = mainForm;
            this.dataGrid = dataGrid;
            dataGrid.ClearSelection();
            TextBoxDepName.TextChanged += TextBoxDepName_TextChanged; //подписка на изменение текстбокса ввода имени отдела
        }

        //Проверка на пустую строку ввода имени отдела
        private void TextBoxDepName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxDepName.Text))
                buttonOK.Enabled = false;
            else
                buttonOK.Enabled = true;
        }

        //Кнопка "Добавить"
        private void buttonOK_Click(object sender, EventArgs e)
        {
            var inputName = TextBoxDepName.Text; //название отдела в текстбоксе
            bool ident = false; //true - есть совпадение, false - нет 
            if (list.Departments.Count > 0) //если кол-во отделов > 0
            {
                foreach (var el in list.Departments.ToArray())
                    if (el.Name.ToLower() == inputName.ToLower()) //проверка отдела на дубликат
                    {
                        var selectedRow = el.Id;
                        mainForm.SelectRowInDataGrid(dataGrid, selectedRow); //выделяем строку-дубликат
                        MessageBox.Show($"Отдел c именем '{inputName}' или похожим именем уже есть!");
                        ident = true;
                        break;
                    }

                if (!ident)
                {
                    AddAndShowChanges(inputName);
                    MessageBox.Show($"Отдел '{inputName}' добавлен");
                }                    
            }
            else
                //если отделов < 0 - добавить в любом случае
            {
                AddAndShowChanges(inputName);
                MessageBox.Show($"Отдел '{inputName}' добавлен");                
            }
                
        }

        //Процесс добавления отдела и отображение изменений в датагриде
        private void AddAndShowChanges(string inputName)
        {
            var selectedRow = list.AddDep(inputName); //добавляем отдел
            mainForm.RefreshMainForm(dataGrid,list.Departments); //обновляем главную форму
            mainForm.SelectRowInDataGrid(dataGrid, selectedRow);//выделяем новую строку с данными
            TextBoxDepName.Clear();
        }
        //Кнопка "Отмена"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
