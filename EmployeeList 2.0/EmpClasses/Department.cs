using System;
using System.Collections.Generic;

namespace EmployeeList_2._0.EmpClasses
{
    [Serializable]
    //класс Отдел
    public class Department : IEquatable<Department>
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

        public bool Equals(Department other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id.Equals(other.Id) && Name.Equals(other.Name) && DateCreate.Equals(other.DateCreate);    
        }
    }
}
