using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//namespace lesson4_1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            EmployeeList list = new EmployeeList(); //cоздаем экземпляр таблиц
//            Title(); //выводим заголовок и хелп
//            do
//            {
//                Console.Write("Введите команду и нажмите ENTER: ");
//                string command = Console.ReadLine();
//                if (command.ToLower()!= "q")
//                {
//                    Title();
//                    switch (command.ToLower())
//                    {
//                        case "1":
//                            list.DisplayDep(); //выводим отделы
//                            break;
//                        case "2":
//                            InputDep(list); //добавляем отдел
//                            break;
//                        case "3":
//                            list.DisplayDep();
//                            InputChangeDep(list); //изменяем отдел
//                            break;
//                        case "4":
//                            list.DisplayDep();
//                            InputRemoveDep(list); //удаляем отдел
//                            break;
//                        case "5":
//                            list.DisplayEmp(); //выводим сотрудников
//                            break;
//                        case "6":
//                            list.DisplayDep();
//                            InputEmp(list); //добавляем сотрудника
//                            break;
//                        case "7":
//                            list.DisplayEmp();
//                            InputChangeEmp(list); //изменяем сотрудника
//                            break;
//                        case "8":
//                            list.DisplayEmp();
//                            InputRemoveEmp(list); //удаляем сотрудника
//                            break;
//                        case "9":
//                            list.DisplayEmp();
//                            Console.WriteLine("Средняя зарплата всех работников = {0:F2}", list.AvgSalary()); 
//                            Console.WriteLine();
//                            break;
//                        case "10":
//                            list.DisplayEmp();
//                            Console.WriteLine($"Общая зарплата всех работников = {list.SumSalary()}");
//                            Console.WriteLine();
//                            break;
//                        case "11":
//                            list.DisplayDep();
//                            list.DisplayEmp();
//                            AvgDepSalary(list); //выводим среднюю зп по конкретному отделу
//                            break;
//                        case "12":
//                            list.DisplayDep();
//                            list.DisplayEmp();
//                            SumDepSalary(list); //выводим сумму зп по конкретному отделу
//                            break;
//                        case "13":
//                            list.DisplayEmp();
//                            Console.WriteLine($"Кол-во сотрудников (всего) = {list.CountOfEmp()}");
//                            Console.WriteLine();
//                            break;
//                        case "14":
//                            list.DisplayEmp();
//                            list.CountOfEmpInDep(); //выводим кол-во сотрудников по отделам
//                            break;
//                        case "15":
//                            list.DisplayDep();
//                            list.DisplayEmp();
//                            InputCountOfEmpInDep(list); //выводим кол-во сотрудников в конкретном отделе
//                            break;
//                        case "s":
//                            SaveTables(list); //сохраняем изменения в файл
//                            break;
//                        case "l":
//                            LoadTables(ref list); //загружаем файл в программу
//                            break;
//                        default:
//                            Console.WriteLine("Такой команды нет");
//                            Console.WriteLine();
//                            break;
//                    }
//                }
//                else
//                    break;
//            } while (true);
//        }

//        //заголовок и хелп
//        static void Title()
//        {
//            Console.Clear();
//            Console.SetCursorPosition(40, 0);
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Программа \"Лист сотрудников\"");
//            Console.SetCursorPosition(0, 1);
//            Console.WriteLine();
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine("1.Таблица \"Отделы\"        2.Добавить отдел                  3.Изменить отдел               4.Удалить отдел");
//            Console.WriteLine("5.Таблица \"Сотрудники\"    6.Добавить сотруд-ка              7.Изменить сотруд-ка           8.Удалить сотруд-ка");
//            Console.WriteLine("9.Средняя зарплата        10.Общая зарплата                 11.Сред. зарплата по отделу    12.Общая зарплата по отделу");
//            Console.WriteLine("13.Количество сотруд-ков  14.Кол-во сотруд-ков по отделам   15.Кол-во сотруд-ков в отделе");
//            Console.WriteLine("s.Сохранить изменения     l.Загрузить файл данных           q.Выход");
//            Console.WriteLine();
//        }

//        //ввод нового отдела
//        static void InputDep(EmployeeList list)
//        {
//            Console.Write("Введите имя отдела: ");
//            string name = Console.ReadLine();
//            list.AddDep(name);
//        }
//        //ввод изменений отдела
//        static void InputChangeDep(EmployeeList list)
//        {
//            Console.Write("Введите № или имя отдела, который вы хотите изменить: ");
//            string strId = Console.ReadLine();
//            if (int.TryParse(strId, out int id))
//                list.ChangeDep(id);
//            else
//                list.ChangeDep(strId);
//        }
//        //ввод удаляемого отдела
//        static void InputRemoveDep(EmployeeList list)
//        {
//            Console.Write("Введите № или имя отдела, который вы хотите удалить: ");
//            string strId = Console.ReadLine();
//            if (int.TryParse(strId, out int id))
//                list.RemoveDep(id);
//            else
//                list.RemoveDep(strId);
//        }

//        //ввод нового сотрудника
//        static void InputEmp(EmployeeList list)
//        {
//            try
//            {
//                Console.Write("Введите фамилию нового сотруд-ка: ");
//                string surname = Console.ReadLine();
//                Console.Write("Введите имя нового сотруд-ка: ");
//                string name = Console.ReadLine();
//                Console.Write("Введите отчество нового сотруд-ка: ");
//                string patronymic = Console.ReadLine();
//                Console.Write("Введите номер отдела: ");
//                int depId = int.Parse(Console.ReadLine());
//                Console.Write("Введите зарплату: ");
//                double salary = double.Parse(Console.ReadLine());
//                list.AddEmp(surname, name, patronymic, depId, salary);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Добавить сотрудника невозможно. Ошибка: {ex.Message}");
//                Console.WriteLine();
//            }
//        }
//        //ввод изменений сотрудника
//        static void InputChangeEmp(EmployeeList list)
//        {
//            Console.Write("Введите № или  ФИО сотруд-ка, который вы хотите изменить: ");
//            string strId = Console.ReadLine();
//            if (int.TryParse(strId, out int id))
//                list.ChangeEmp(id);
//            else
//                list.ChangeEmp(strId);
//        }
//        //ввод удаляемого сотрудника
//        static void InputRemoveEmp(EmployeeList list)
//        {
//            Console.Write("Введите № или  ФИО сотруд-ка, который вы хотите удалить: ");
//            string strId = Console.ReadLine();
//            if (int.TryParse(strId, out int id))
//                list.RemoveEmp(id);
//            else
//                list.RemoveEmp(strId);
//        }

//        //ввод отдела для подсчета ср. зп
//        static double InputAvgDepSalary(EmployeeList list, out bool Same, out int id)
//        {
//            bool same = false; //true - поиск ввода успешен, false - нет
//            try
//            {
//                Console.Write("Введите № отдела, по которому нужно посчитать среднюю зарплату: ");
//                int depId = int.Parse(Console.ReadLine());
//                id = depId;
//                double res = list.AvgDepSalary(depId, out same);
//                Same = same;
//                return res;
//            }
//            catch (Exception ex)
//            {
//                same = false;
//                Console.WriteLine($"Подсчет невозможен. Ошибка: {ex.Message}");
//                Console.WriteLine();
//                Same = same;
//                id = 0;
//                return 0;
//            }
//        }
//        static void AvgDepSalary(EmployeeList list)
//        {
//            bool Same; //true - поиск ввода успешен, false - нет
//            int id;
//            var sum = InputAvgDepSalary(list, out Same, out id);
//            if (Same)
//                Console.WriteLine($"Средняя зарплата по отделу №{id} = {sum}");
//            Console.WriteLine();
//        }
//        //ввод отдела для подсчета общей зп
//        static double InputSumDepSalary(EmployeeList list, out bool Same, out int id)
//        {
//            bool same = false; //true - поиск ввода успешен, false - нет
//            try
//            {
//                Console.Write("Введите № отдела, по которому нужно посчитать общую зарплату: ");
//                int depId = int.Parse(Console.ReadLine());
//                id = depId;
//                double res = list.SumDepSalary(depId, out same);
//                Same = same;
//                return res;
//            }
//            catch (Exception ex)
//            {
//                same = false;
//                Console.WriteLine($"Подсчет невозможен. Ошибка: {ex.Message}");
//                Console.WriteLine();
//                Same = same;
//                id = 0;
//                return 0;
//            }
//        }
//        static void SumDepSalary(EmployeeList list)
//        {
//            bool Same; //true - поиск ввода успешен, false - нет
//            int id;
//            var sum = InputSumDepSalary(list, out Same, out id);
//            if (Same)
//                Console.WriteLine($"Общая зарплата по отделу №{id} = {sum}");
//            Console.WriteLine();
//        }

//        //ввод отдела для подсчета кол-ва сотрудников
//        static void InputCountOfEmpInDep(EmployeeList list)
//        {
//            try
//            {
//                Console.Write("Введите № отдела, по которому нужно посчитать кол-во сотруд-ков: ");
//                int depId = int.Parse(Console.ReadLine());
//                list.CountOfEmpInDep(depId);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Подсчет невозможен. Ошибка: {ex.Message}");
//                Console.WriteLine();
//            }
//        }

//        //сохранение
//        static void SaveTables(EmployeeList list)
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            try
//            {
//                using (FileStream fs = new FileStream("List.dat", FileMode.OpenOrCreate))
//                {

//                    formatter.Serialize(fs, list);
//                    Console.WriteLine("Данные сохранены!");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Сохранение невозможно. Ошибка: {ex.Message}");
//            }
//            Console.WriteLine();
//        }
//        //загрузка
//        static void LoadTables(ref EmployeeList list)
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            try
//            {
//                using (FileStream fs = new FileStream("List.dat", FileMode.Open))
//                {
//                    list = (EmployeeList)formatter.Deserialize(fs);
//                    Console.WriteLine("Данные загружены!");
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Загрузка невозможна. Ошибка: {ex.Message}");
//            }
//            Console.WriteLine();
//        }

        
        
        
        

        
//    }
//}
