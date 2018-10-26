using System;
using System.Collections;
using System.Collections.Generic;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    [Serializable]
    //класс Список сотрудников
    public class EmployeeList : IEnumerable
    {
        public List<Employee> Employees { get; set; } //cписок самих сотрудников
        public List<Department> Departments { get; set; } //список отделов

        public EmployeeList()
        {
            Employees = new List<Employee>();
            Departments = new List<Department>();
        }

        //Добавление отдела
        public int AddDep(string name)
        {
            var dep = new Department(name);
            Departments.Add(dep);
            dep.Id = Departments.IndexOf(dep);
            return dep.Id;
        }
        //Изменение отдела
        public void СhangeDep(Department requiredDep, string name /*,out string newName*/)
        {
            requiredDep.Name = name;
        }

        ////удалить отдел по Id
        //public void RemoveDep(int id)
        //{
        //    bool haveEmp = false; //true - отдел содержит сотрудников, false - нет
        //    foreach (var elem in employees)
        //    {
        //        if (elem.DepartmentId == id)
        //        {
        //            Console.WriteLine($"Отдел №{id} удалить нельзя, так как он содержит сотрудников");
        //            haveEmp = true;
        //            break;
        //        }
        //    }
        //    if (!haveEmp)
        //    {
        //        bool same = false;
        //        foreach (var el in departaments)
        //        {
        //            if (el.Id == id)
        //            {
        //                departaments.Remove(el);
        //                Console.WriteLine($"Отдел №{id} удален");
        //                same = true;
        //                break;
        //            }
        //        }
        //        if (!same)
        //            Console.Write($"Отдела №{id} нет");
        //    }
        //    Console.WriteLine();
        //}
        ////удалить отдел по имени
        //public void RemoveDep(string name)
        //{
        //    int targetId = 2147483640; //нач. знач. целевого Id - бесконечность
        //    bool haveEmp = false; //true - отдел содержит сотрудников, false - нет
        //    foreach (var elem in departaments)
        //        if (elem.Name == name)
        //            targetId = elem.Id;
        //    foreach (var elem in employees)
        //    {
        //        if (elem.DepartmentId == targetId)
        //        {
        //            Console.WriteLine($"Отдел '{name}' удалить нельзя, так как он содержит сотрудников");
        //            haveEmp = true;
        //            break;
        //        }
        //    }
        //    if (!haveEmp)
        //    {
        //        bool same = false;
        //        foreach (var el in departaments)
        //        {
        //            if (el.Name == name)
        //            {
        //                departaments.Remove(el);
        //                Console.WriteLine($"Отдел '{name}' удален");
        //                same = true;
        //                break;
        //            }
        //        }
        //        if (!same)
        //            Console.Write($"Отдела {name} нет");
        //    }
        //    Console.WriteLine();
        //}

        ////добавить сотрудника
        ////проверка и вызов
        //public void AddEmp(string surname, string name, string patronymic, int depId, double salary)
        //{
        //    bool same = false; //true - есть совпадение, false - нет 
        //    foreach (var elem in departaments)
        //    {
        //        if (elem.Id == depId)
        //        {
        //            bool ident = false; //false - сотрудника еще нет
        //            string fullName = $"{surname} {name} {patronymic}";
        //            if (employees.Count > 0)
        //            {
        //                foreach (var el in employees.ToArray())
        //                    if (el.FullName == fullName)
        //                    {
        //                        Console.WriteLine($"Сотрудник '{fullName}' уже есть");
        //                        Console.WriteLine();
        //                        ident = true; //true - cотрудник уже существует
        //                        break;
        //                    }
        //                if (!ident)
        //                    CreateEmp(surname, name, patronymic, depId, salary);
        //            }
        //            else
        //                CreateEmp(surname, name, patronymic, depId, salary);
        //            same = true;
        //            break;
        //        }
        //    }
        //    if (!same)
        //    {
        //        Console.WriteLine($"Добавить сотрудника невозможно. Отдела №{depId} нет");
        //        Console.WriteLine();
        //    }
        //}
        ////добавление
        //private void CreateEmp(string surname, string name, string patronymic, int depId, double salary)
        //{
        //    var emp = new Employee(surname, name, patronymic, depId, salary);
        //    employees.Add(emp);
        //    emp.Id = employees.IndexOf(emp);
        //    Console.WriteLine($"Сотрудник '{emp.FullName}' добавлен");
        //    Console.WriteLine();
        //}

        ////изменить сотрудника
        ////поиск по Id
        //public void ChangeEmp(int id)
        //{
        //    bool same = false; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.Id == id)
        //        {
        //            ModifyEmp(el, ref same);
        //            break;
        //        }
        //    }
        //    if (!same)
        //        Console.WriteLine($"Сотрудника №{id} нет");
        //    Console.WriteLine();
        //}
        ////поиск по имени
        //public void ChangeEmp(string fio)
        //{
        //    bool same = false; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.FullName == fio)
        //        {
        //            ModifyEmp(el, ref same);
        //            break;
        //        }
        //    }
        //    if (!same)
        //        Console.WriteLine($"Сотрудника '{fio}' нет");
        //    Console.WriteLine();
        //}
        ////изменение
        //private void ModifyEmp(Employee el, ref bool same)
        //{
        //    string oldFio = el.FullName;
        //    Console.Write("Введите новую фамилию:");
        //    el.Surname = Console.ReadLine();
        //    Console.Write("Введите новое имя:");
        //    el.Name = Console.ReadLine();
        //    Console.Write("Введите новое отчество:");
        //    el.Patronymic = Console.ReadLine();
        //    el.FullName = $"{el.Surname} {el.Name} {el.Patronymic}";
        //    Console.WriteLine($"ФИО сотрудника '{oldFio}' изменено на '{el.FullName}'");
        //    same = true;
        //}

        ////удалить сотрудника по Id
        //public void RemoveEmp(int id)
        //{
        //    bool same = false; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.Id == id)
        //        {
        //            employees.Remove(el);
        //            Console.WriteLine($"Сотрудник №{id} удален");
        //            same = true;
        //            break;
        //        }
        //    }
        //    if (!same)
        //        Console.Write($"Сотрудника №{id} нет");
        //    Console.WriteLine();
        //}
        ////удалить сотрудника по имени
        //public void RemoveEmp(string fio)
        //{
        //    bool same = false; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.FullName == fio)
        //        {
        //            employees.Remove(el);
        //            Console.WriteLine($"Сотрудник {fio} удален");
        //            same = true;
        //            break;
        //        }
        //    }
        //    if (!same)
        //        Console.WriteLine($"Сотрудника '{fio}' нет");
        //    Console.WriteLine();
        //}

        ////вывод отделов
        //public void DisplayDep()
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("\"Отделы\"");
        //    Console.WriteLine();
        //    Console.WriteLine("№ \t|Отдел \t\t\t\t|Дата создания");
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine();
        //    foreach (var el in departaments)
        //        Console.WriteLine("{0,-7} |{1,-30} |{2:g}", el.Id, el.Name, el.DateCreate);
        //    Console.WriteLine();
        //}
        ////вывод сотрудников
        //public void DisplayEmp()
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("\"Cотрудники\"");
        //    Console.WriteLine();
        //    Console.WriteLine("№ \t|ФИО \t\t\t\t|Зарплата \t|Отдел \t\t\t\t|Нанят \t\t\t|Уволен ");
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine();
        //    foreach (var el in employees)
        //    {
        //        string dateFired = "";
        //        if (!el.IsFired)
        //            dateFired = "null";
        //        var dep = new Department();
        //        foreach (var elem in departaments)
        //        {
        //            if (elem.Id == el.DepartmentId)
        //            {
        //                dep = elem;
        //                break;
        //            }
        //        }
        //        Console.WriteLine("{0,-7} |{1,-30} |{2,-14} |{3,-30} |{4,-14:d} |{5:d}", el.Id, el.FullName, el.Salary, dep.Name, el.DateHired, dateFired);

        //    }
        //    Console.WriteLine();
        //}

        ////средная зп
        //public double AvgSalary()
        //{
        //    return SumSalary() / employees.Count;
        //}
        ////общая зп
        //public double SumSalary()
        //{
        //    double sumSalary = 0;
        //    foreach (var el in employees)
        //        sumSalary += el.Salary;
        //    return sumSalary;
        //}
        ////средняя зп по отделу
        //public double AvgDepSalary(int id,out bool Same)
        //{
        //    int count = 0;
        //    bool same = true; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.DepartmentId == id)
        //            count++;
        //    }
        //    if(count==0)
        //    {
        //        Console.WriteLine($"Отдела №{id} нет");
        //        Same = false;
        //        Console.WriteLine();
        //        return 0;
        //    }
        //    SumDepSalary(id, out same);
        //    Same = same;
        //    return SumDepSalary(id, out same) / count;
        //}
        ////общая зп по отделу
        //public double SumDepSalary(int id, out bool same)
        //{
        //    double sumDepSalary = 0;
        //    same = true; //true - есть совпадение, false - нет
        //    foreach (var el in employees)
        //    {
        //        if (el.DepartmentId == id)
        //        {
        //            sumDepSalary += el.Salary;
        //        }

        //    }
        //    if(sumDepSalary==0)
        //    {
        //        Console.WriteLine($"Отдела №{id} нет");
        //        same = false;
        //        Console.WriteLine();
        //        return 0;
        //    }
        //    return sumDepSalary;        
        //}

        ////кол-во сотрудников
        //public int CountOfEmp()
        //{
        //    return employees.Count;
        //}
        ////кол-во сотрудников по отделам
        //public void CountOfEmpInDep()
        //{
        //    Dictionary<string, int> inDepDict = new Dictionary<string, int>(departaments.Count); //cловарь, key - имя отдела, value - кол-во сотрудников
        //    foreach (var el in departaments)
        //    {
        //        int count = 0;
        //        foreach (var elem in employees)
        //        {
        //            if (elem.DepartmentId == el.Id)
        //                count++;
        //        }
        //        inDepDict.Add(el.Name, count);
        //    }
        //    foreach (KeyValuePair<string, int> keyValue in inDepDict)
        //        Console.WriteLine($"Кол-во сотрудников в отделе {keyValue.Key} = {keyValue.Value}");
        //    Console.WriteLine();
        //}
        ////кол-во сотрудников в конкретном отделе
        //public void CountOfEmpInDep(int id)
        //{
        //    bool same = false;  //true - есть совпадение, false - нет
        //    foreach (var el in departaments)
        //    {
        //        if (el.Id == id)
        //        {
        //            int count = 0;
        //            same = true;
        //            foreach (var elem in employees)
        //            {
        //                if (elem.DepartmentId == el.Id)
        //                    count++;
        //            }
        //            Console.WriteLine($"Кол-во сотрудников в отделе {el.Name} = {count}");
        //            break;
        //        }
        //    }
        //    if (!same)
        //        Console.WriteLine($"Отдела №{id} нет");
        //    Console.WriteLine();
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Departments.GetEnumerator();
        }
    }
}
