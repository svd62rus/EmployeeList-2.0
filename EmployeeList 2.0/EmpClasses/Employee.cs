using System;

namespace EmployeeList_2._0.EmpClasses
{
    [Serializable]
    //класс Сотрудник
    public class Employee
    {
        public int Id { get; set; } //уник. Id - формируется в EmployeeList
        public string Name { get; set; } //имя
        public string Surname { get; set; } //фамилия
        public string Patronymic { get; set; } //отчество
        public string FullName { get; set; } //фио
        public int DepartmentId { get; set; } //номер отдела из Departament.Id
        public bool IsFired { get; set; } //true - уволен, false - работает
        public double Salary { get; set; } //зарплата
        public DateTime DateHired { get; set; } //дата найма
        public DateTime? DateFired { get; set; } //дата увольнения


        public Employee(string surname, string name, string patronymic, int departmentId, double salary)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            FullName = $"{Surname} {Name} {Patronymic}";
            DepartmentId = departmentId;
            IsFired = false;
            Salary = salary;
            DateHired = DateTime.Now;
            DateFired = null;
        }
    }
}
