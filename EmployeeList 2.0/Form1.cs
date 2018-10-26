using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeList_2._0
{
    public partial class Form1 : Form
    {
        private EmployeeList list; //лист таблиц

        public delegate void SimpleMethod(); /*делегат для:
                                             - передачи метода вывода данных в таблицу
                                            */

        public Form1()
        {
            InitializeComponent();
            list = new EmployeeList(); //cоздаем экземпляр таблиц
            //добавляем столбцы в датагрид
            dataGridDeps.Columns.Add("Id", "№");
            dataGridDeps.Columns.Add("Name", "Отдел");
            dataGridDeps.Columns.Add("DateCreate", "Дата создания");
            dataGridDeps.ReadOnly = true;
            dataGridDeps.RowHeadersVisible = false;
            dataGridDeps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDeps.MultiSelect = false;
        }

        //Вывод отделов (можно подумать на реализацией для вывода и сотрудников через этот метод)
        public void DisplayDep()
        {
            if (dataGridDeps.Rows.Count > 1)
            {
                dataGridDeps.Rows.Clear(); //очищаем датагрид
            }
            foreach (var el in list.Departments)
            {
                string[] row = { el.Id.ToString(), el.Name, el.DateCreate.ToLongDateString() }; 
                dataGridDeps.Rows.Add(row); //добавляем массив строк в датагрид
            }
        }

        //Файл-Загрузить
        private void toolStripMenuLoad_Click(object sender, EventArgs e)
        {
            LoadTables(ref list, DisplayDep); //загружаем файл в программу
        }
        private void toolButtonLoad_Click(object sender, EventArgs e)
        {
            LoadTables(ref list, DisplayDep); //загружаем файл в программу
        }
        //Загрузка
        static void LoadTables(ref EmployeeList list, SimpleMethod display)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            try
            {
                using (FileStream fs = new FileStream("List.dat", FileMode.Open))
                {
                    list = (EmployeeList)formatter.Deserialize(fs);
                    display(); //выводим данные в датагрид
                    //MessageBox.Show("Данные загружены!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Загрузка невозможна. Ошибка: {ex.Message}");
            }
        }

        //Файл-Сохранить
        private void toolStripMenuSave_Click(object sender, EventArgs e)
        {
            SaveTables(list); //сохраняем изменения в файл
        }
        private void toolButtonSave_Click(object sender, EventArgs e)
        {
            SaveTables(list); //сохраняем изменения в файл
        }
        //Сохранение
        static void SaveTables(EmployeeList list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            try
            {
                using (FileStream fs = new FileStream("List.dat", FileMode.OpenOrCreate))
                {

                    formatter.Serialize(fs, list);
                    MessageBox.Show("Данные сохранены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сохранение невозможно. Ошибка: {ex.Message}");
            }
        }

        //Отделы-Добавить
        private void menuAddDep_Click(object sender, EventArgs e)
        {
            AddDepProcess(); //начинаем процесс добавления отдела
        }
        private void toolButtonAddDep_Click(object sender, EventArgs e)
        {
            AddDepProcess(); //начинаем процесс добавления отдела
        }
        //Cамо добавление
        private void AddDepProcess()
        {
            this.Enabled = false;
            var formAddDep = new FormAddDep(list, this, dataGridDeps); //создаем форму добавления отдела
            formAddDep.Show(); //показываем новую форму
            formAddDep.FormClosed += new FormClosedEventHandler(anyChildFormClosed); //подписываемся на событие закрытия дочерней формы
        }
        //Обработка закрытия дочерних форм
        private void anyChildFormClosed(object sender, EventArgs e)
        {
            this.Enabled = true;
        }
        //Обновление датагрида
        public void refreshMainForm()
        {
            this.Enabled = true;
            DisplayDep();
            this.Enabled = false;
        }

        //Выделение конкретной строки с данными
        public void selectRowInDataGrid(DataGridView dataGrid, int numOfRow)
        {
            dataGrid.Rows[numOfRow].Selected = true;
            dataGrid.FirstDisplayedScrollingRowIndex = numOfRow;
            dataGrid.Update();
        }

        //Выход
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Отделы-Изменить-По данным
        private void menuChangeDepByData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var formChangeDep = new FormChangeDep(list,this,dataGridDeps); //создаем форму изменения отдела
            formChangeDep.Show(); //показываем новую форму
            formChangeDep.FormClosed += new FormClosedEventHandler(anyChildFormClosed); //подписываемся на событие закрытия дочерней формы
        }

        
    }
}
