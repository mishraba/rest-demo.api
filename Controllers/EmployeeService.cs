// public class EmployeeModel
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Department { get; set; }
// }

public class EmployeeService
{
    public IEnumerable<EmployeeModel> GetEmployees()
    {
        // Return a list of employees (replace with actual data retrieval logic)
        return new List<EmployeeModel>
        {
            new EmployeeModel { Id = 1, Name = "Digvijay E", Department = "Engineering E" },
            new EmployeeModel { Id = 2, Name = "Jane Smith", Department = "Marketing" },
            new EmployeeModel { Id = 3, Name = "Bob Johnson", Department = "Sales" },
            new EmployeeModel { Id = 4, Name = "Alice Brown", Department = "HR" },
            new EmployeeModel { Id = 5, Name = "Charlie Davis", Department = "Finance" },
            new EmployeeModel { Id = 6, Name = "Emily Wilson", Department = "Customer Support" },
            new EmployeeModel { Id = 7, Name = "David Lee", Department = "IT" },
        };
    }
}