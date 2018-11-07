namespace EmployeeList_2._0
{
    public class FilterClass
    {
        public bool More { get; set; }
        public bool Less { get; set; }
        public double Salary { get; set; }
        public double MaxSalary { get; set; }

        public FilterClass(bool more, bool less, double salary)
        {
            More = more;
            Less = less;
            Salary = salary;
        }
        public FilterClass(double minSalary, double maxSalary)
        {
            More = true;
            Less = true;
            Salary = minSalary;
            MaxSalary = maxSalary;
        }

    }
}
