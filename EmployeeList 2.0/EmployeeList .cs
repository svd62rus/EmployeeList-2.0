using System;
using System.Collections;
using System.Collections.Generic;
using EmployeeList_2._0.EmpClasses;

namespace EmployeeList_2._0
{
    public delegate bool Filter(Employee employee, FilterClass filterParams);
    public delegate bool CheckEmp(bool typeOfEmp);

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
            dep.Id = Departments.IndexOf(dep) + 1;
            return dep.Id;
        }
        //Изменение отдела
        public void СhangeDep(Department requiredDep, string name)
        {
            requiredDep.Name = name;
        }
        //Удаление отдела
        public void RemoveDep(int id)
        {
            foreach (var el in Departments)
            {
                if (el.Id == id)
                {
                    Departments.Remove(el);
                    break;
                }
            }

            ShiftDepsId();

        }

        //Добавление сотрудника
        public int AddEmp(string surname, string name, string patronymic, int depId, double salary)
        {
            var emp = new Employee(surname, name, patronymic, depId, salary);
            Employees.Add(emp);
            emp.Id = Employees.IndexOf(emp) + 1;
            return emp.Id;
        }
        //Изменение сотрудника
        public int ChangeEmp(Employee requiredEmp, string surname, string name, string patronymic, int depId, double salary)
        {
            requiredEmp.Surname = surname;
            requiredEmp.Name = name;
            requiredEmp.Patronymic = patronymic;
            requiredEmp.DepartmentId = depId;
            requiredEmp.Salary = salary;
            requiredEmp.FullName = $"{surname} {name} {patronymic}";
            return requiredEmp.Id;
        }
        //Cдвиг адишников отделов в отделах
        private void ShiftDepsId()
        {
            foreach (var el in Departments)
            {
                int oldId = el.Id;
                el.Id = Departments.IndexOf(el) + 1;
                ShiftDepartmentId(oldId, el.Id);
            }
        }
        //Сдвиг айдишников отделов в сотрудниках
        private void ShiftDepartmentId(int oldId, int newId)
        {
            foreach (var el in Employees)
            {
                if (el.DepartmentId == oldId)
                    el.DepartmentId = newId;
            }
        }
        //Cдвиг айдишников самих сотрудников
        private void ShiftEmpsId()
        {
            foreach (var el in Employees)
            {
                el.Id = Employees.IndexOf(el) + 1;
            }
        }
        //Удаление сотрудника
        public void RemoveEmp(int id)
        {
            foreach (var el in Employees)
            {
                if (el.Id == id)
                {
                    Employees.Remove(el);
                    break;
                }
            }
            ShiftEmpsId();
        }

        //Cредняя ЗП
        public double AvgSalary()
        {
            return SumSalary() / CountOfEmp();
        }
        //Общая ЗП 
        public double SumSalary()
        {
            double sumSalary = 0;
            foreach (var el in Employees)
            {
                if (!el.IsFired)
                    sumSalary += el.Salary;
            } 
            return sumSalary;
        }
        //Кол-во сотрудников
        public int CountOfEmp()
        {
            int count = 0;
            foreach (var el in Employees)
            {
                if (!el.IsFired)
                    count++;
            }
            return count;
        }
        //Общая ЗП по отделу
        public double SumSalary(int id)
        {
            double sumDepSalary = 0;
            foreach (var el in Employees)
            {
                if (el.DepartmentId == id && !el.IsFired)
                {
                    sumDepSalary += el.Salary;
                }

            }
            return sumDepSalary;
        }
        //Cредняя ЗП по отделу
        public double AvgSalary(int id)
        {
            int count = 0;
            foreach (var el in Employees)
            {
                if (el.DepartmentId == id && !el.IsFired)
                    count++;
            }
            return SumSalary(id) / count;
        }

        //Кол-во сотрудников по отделам
        public Dictionary<string, int> CountOfEmpPerDep()
        {
            Dictionary<string, int> perDepDict = new Dictionary<string, int>(Departments.Count); //cловарь, key - имя отдела, value - кол-во сотрудников
            foreach (var el in Departments)
            {
                perDepDict.Add(el.Name, CountOfEmp(el.Id));
            }
            return perDepDict;
        }
        //Кол-во сотрудников в конкретном отделе
        public int CountOfEmp(int id)
        {
            int count = 0;
            foreach (var el in Departments)
            {
                if (el.Id == id)
                {
                    foreach (var elem in Employees)
                    {
                        if (elem.DepartmentId == el.Id && !elem.IsFired)
                            count++;
                    }

                    return count;
                }
            }
            return count;
        }

        //Фильтр по зарплате
        public bool SalaryFilter(Employee employee, FilterClass filterParams)
        {
            if (filterParams.More && filterParams.Less)
            {
                if (employee.Salary > filterParams.Salary && employee.Salary < filterParams.MaxSalary)
                    return true;
            }
            else
            {
                if (filterParams.More)
                {
                    if (employee.Salary > filterParams.Salary)
                        return true;
                }
                if (filterParams.Less)
                {
                    if (employee.Salary < filterParams.Salary)
                        return true;
                }
            }
            
            return false;
        }
        //Фильтрация сотрудников
        public List<Employee> EmployeeFilter(Filter filter, FilterClass filterParams)
        {
            List<Employee> emps = new List<Employee>();
            foreach (var elem in Employees)
            {
                if (filter(elem, filterParams))
                    emps.Add(elem);
            }

            return emps;
        }

        //Cравнение ФИО А-Я
        private int CompareEmpIncreaseLetter(Employee emp1, Employee emp2)
        {
            return emp1.FullName.CompareTo(emp2.FullName);
        }
        //Cравнение ФИО Я-А
        private int CompareEmpDescendLetter(Employee emp1, Employee emp2)
        {
            return emp2.FullName.CompareTo(emp1.FullName);
        }
        //Cравнение зарплаты 0-9
        private int CompareEmpIncreaseSalary(Employee emp1, Employee emp2)
        {
            return emp1.Salary.CompareTo(emp2.Salary);
        }
        //Cравнение зарплаты 9-0
        private int CompareEmpDescendSalary(Employee emp1, Employee emp2)
        {
            return emp2.Salary.CompareTo(emp1.Salary);
        }
        //Сортировка
        public void SortEmp(int typeOfSort)
        {
            switch (typeOfSort)
            {
                case 0:
                    Employees.Sort(new Comparison<Employee>(CompareEmpIncreaseLetter));
                    break;
                case 1:
                    Employees.Sort(new Comparison<Employee>(CompareEmpDescendLetter));
                    break;
                case 2:
                    Employees.Sort(new Comparison<Employee>(CompareEmpIncreaseSalary));
                    break;
                case 3:
                    Employees.Sort(new Comparison<Employee>(CompareEmpDescendSalary));
                    break;
            }
            ShiftEmpsId();
        }
    
        //Увольнение
        public void FireEmp(Employee emp)
        {
            emp.IsFired = true;
            emp.DepartmentId = int.MinValue;
            emp.DateFired = DateTime.Now;
        }

        //Проверка работает ли сотрудник
        public bool CheckEmpType(bool typeOfEmp)
        {
            if (typeOfEmp)
                return true;
            else
                return false;
        }
        //Формирование листа с ФИО рабочих либо уволенных
        public List<string> FullNames(CheckEmp checkemp, bool typeOfEmp)
        {
            
            bool requiredType = true;
            if (checkemp(typeOfEmp))
                requiredType = false;
            var outStringList = new List<string>();
            foreach (var elem in Employees)
            {
                if (elem.IsFired==requiredType)
                    outStringList.Add($"{elem.Id}. {elem.FullName}");
            }
            return outStringList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Departments.GetEnumerator();
        }
    }
}
