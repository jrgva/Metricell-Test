using InterviewTest.Model;
using InterviewTest.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api")]
    public class ListController : ControllerBase
    {
        public readonly IEmployeeService employeeService;
        public ListController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("listAllEmployees")]
        public async Task<List<Employee>> ListAllEmployees()
        {
            return await employeeService.GetAllEmployees();
        }


        [Route("deleteEmployee")]
        [HttpDelete]
        public async Task<List<Employee>> DeleteEmployee(string name, int value)
        {
            return await employeeService.DeleteEmployee(name, value);
        }

        [Route("addEmployee")]
        [HttpPost]
        public async Task<List<Employee>> AddEmployee(string name, int value)
        {
            return await employeeService.AddEmployee(name, value);
        }

        [Route("editEmployee")]
        [HttpPatch]
        public async Task<List<Employee>> EditEmployee(string name, int value, [FromBody]Employee employee)
        {
            return await employeeService.EditEmployee(name, value, employee.Name, employee.Value);
        }

        [HttpGet("incrementValueBasedOnName")]
        public async Task<List<Employee>> IncrementValueBasedOnName()
        {
            return await employeeService.IncrementValueBasedOnName();
        }

        [HttpGet("sumValuesBasedOnName")]
        public async Task<List<Summatory>> SumValuesBasedOnName()
        {
            return await employeeService.SumValuesBasedOnName();
        }
    }
}
