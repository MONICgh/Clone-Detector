namespace task3
{
    class Program
    {
        public static void Main(string[] args)
        {
           Employee employee = new Employee("Abastract", "Man", new DateTime(1985, 6, 14));
           Console.WriteLine(employee.GetAge()); // 37
           Console.WriteLine(employee.GetSalary()); // 0

           Programmer programmer = new Programmer("Bob", "Johnson", new DateTime(1994, 7, 7));
           Console.WriteLine(programmer.GetAge()); // 28
           Console.WriteLine(programmer.GetSalary()); //100000

        }
    }
}