using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace rest_demo.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppSettings _settings;

        public EmployeeController(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        // [Authorize]
        [HttpGet]
        [Route("GetEmployees")]
        public IEnumerable<EmployeeModel> Get()
        {
            // Return a list of employees (replace with actual data retrieval logic)
           
            return new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1, Name = "John Doe", Department = "Engineering" },
                new EmployeeModel { Id = 2, Name = "Jane Smith", Department = "Marketing" },
                new EmployeeModel { Id = 3, Name = "Bob Johnson", Department = "Sales" },
                new EmployeeModel { Id = 4, Name = "Alice Brown", Department = "HR" },
                new EmployeeModel { Id = 5, Name = "Charlie Davis", Department = "Finance" },
                new EmployeeModel { Id = 6, Name = "Emily Wilson", Department = "Customer Support" },
                new EmployeeModel { Id = 7, Name = "David Lee", Department = "IT" },
            };
        }

        [HttpGet]
        [Route("SearchEmployees")]
        public IEnumerable<EmployeeModel> Search(string? name)
        {   
           
            var employees = new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1, Name = "John Doe", Department = "Engineering" },
                new EmployeeModel { Id = 2, Name = "Jane Smith", Department = "Marketing" },
                new EmployeeModel { Id = 3, Name = "Bob Johnson", Department = "Sales" },
                new EmployeeModel { Id = 4, Name = "Alice Brown", Department = "HR" },
                new EmployeeModel { Id = 5, Name = "Charlie Davis", Department = "Finance" },
                new EmployeeModel { Id = 6, Name = "Emily Wilson", Department = "Customer Support" },
                new EmployeeModel { Id = 7, Name = "David Lee", Department = "IT" },
            };

            if (string.IsNullOrWhiteSpace(name))
            {
                return employees;
            }

            return employees
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}

