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

            ShiftDeps();

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
        private void ShiftDeps()
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
        private void ShiftEmps()
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
            ShiftEmps();
        }

        //Cредняя ЗП
        public double AvgSalary()
        {
            return SumSalary() / Employees.Count;
        }
        //Общая ЗП 
        public double SumSalary()
        {
            double sumSalary = 0;
            foreach (var el in Employees)
                sumSalary += el.Salary;
            return sumSalary;
        }
        //Кол-во сотрудников
        public int CountOfEmp()
        {
            return Employees.Count;
        }
        //Общая ЗП по отделу
        public double SumSalary(int id)
        {
            double sumDepSalary = 0;
            foreach (var el in Employees)
            {
                if (el.DepartmentId == id)
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
                if (el.DepartmentId == id)
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
                        if (elem.DepartmentId == el.Id)
                            count++;
                    }

                    return count;
                }
            }
            return count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Departments.GetEnumerator();
        }
    }
}
