namespace ServiceBusObjectSender;

internal class Employee
{
    public Employee(string frirstName, string lastName, int salary)
    {
        FirstName = frirstName;
        LastName = lastName;
        Salary = salary;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public int Salary { get; }

    public static Employee Create(string firstName, string lastName, int salary)
    {
        return new Employee(firstName, lastName, salary);
    }
}
