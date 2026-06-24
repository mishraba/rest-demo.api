[ExtendObjectType(typeof(Query))]
public class EmployeeQuery
{
    public IEnumerable<EmployeeModel> GetEmployees([Service] EmployeeService employeeService)
    {
        return employeeService.GetEmployees();
    }
}