using miniHW1_KPO_Tolmacheva.Interfaces;

namespace miniHW1_KPO_Tolmacheva.Names.Employees
{
    public class Employee : IAlive
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int EmployeeId { get; set; }

        public Employee(string name, int food, int employeeId)
        {
            Name = name;
            Food = food;
            EmployeeId = employeeId;
        }
    }
}
