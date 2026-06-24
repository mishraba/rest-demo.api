public record Employee(string Name, string Department);
public class Query
{
    public IEnumerable<Employee> GetEmployees1()
    {
        return new List<Employee>
        {
            new Employee("Anhsul", "Engineering"),
            new Employee("Jane Smith", "Marketing"),
            new Employee("Bob Johnson", "Sales"),
            new Employee("Alice Brown", "HR"),
            new Employee("Charlie Davis", "Finance"),
            new Employee("Emily Wilson", "Customer Support"),
            new Employee("David Lee", "IT")
        };
    }
}