using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data.Dtos;
using RepositoryPattern.Services.Abstracts;
using System.Threading.Tasks;

namespace RepositoryPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetEmployees()
        {
            var employeeList = await _employeeService.GetAllAsync();
            return Ok(employeeList);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetAsync(id);
            return Ok(employee);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            await _employeeService.AddAsync(employeeDto);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto, int id)
        {

            await _employeeService.Update(employeeDto, id);
            return Ok();


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }
    }
}
