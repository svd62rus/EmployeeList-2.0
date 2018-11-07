using System;
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
            ButtonOK.Enabled = false;
        }



        //Кнопка "Добавить"
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            var inputName = TextBoxDepName.Text; //название отдела в текстбоксе 
            if (list.Departments.Count > 0) //если кол-во отделов > 0
            {
                if(CheckDub(inputName))
                    MessageBox.Show($"Отдел \"{inputName}\" добавлен!");
                else
                    MessageBox.Show($"Отдел c именем \"{inputName}\" или похожим именем уже есть!");
            }
            else //если отделов < 0 - добавить в любом случае
            {
                AddAndShowChanges(inputName);
                MessageBox.Show($"Отдел \"{inputName}\" добавлен!");                
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
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Проверка на ввод
        private void TextBoxDepName_TextChanged(object sender, EventArgs e)
        {
            var checkVar = new CheckTextString(TextBoxDepName.Text);
            ButtonOK.Enabled = checkVar.CheckText();
        }

        //Проверка на дубликат
        private bool CheckDub(string inputName)
        {
            bool ident = false; //true - есть совпадение, false - нет
            foreach (var el in list.Departments.ToArray())
                if (el.Name.ToLower() == inputName.ToLower()) //проверка отдела на дубликат
                {
                    var selectedRow = el.Id;
                    mainForm.SelectRowInDataGrid(dataGrid, selectedRow); //выделяем строку-дубликат
                    ident = true;
                    break;
                }

            if (!ident)
                AddAndShowChanges(inputName);

            return !ident;
        }
    }
}
