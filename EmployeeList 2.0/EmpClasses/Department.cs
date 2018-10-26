using System;

namespace EmployeeList_2._0.EmpClasses
{
    [Serializable]
    //класс Отдел
    public class Department 
    {
        public int Id { get; set; } //уник. Id - формируется в EmployeeList
        public string Name { get; set; } //имя
        public DateTime DateCreate { get; set; } //дата создания
        public Department()
        {
        }
        public Department(string name)
        {
            Name = name;
            DateCreate = DateTime.Now;
        }
    }
}
