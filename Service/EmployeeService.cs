using InterviewTest.Model;
using InterviewTest.Repository.Interfaces;
using InterviewTest.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> AddEmployee(string name, int value)
        {
            return await employeeRepository.AddEmployee(name, value);
        }

        public async Task<List<Employee>> DeleteEmployee(string name, int value)
        {
            return await employeeRepository.DeleteEmployee(name, value);
        }

        public async Task<List<Employee>> EditEmployee(string name, int value, string newName, int newValue)
        {
            return await employeeRepository.EditEmployee(name, value, newName, newValue);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await employeeRepository.GetAllEmployees();
        }

        public async Task<List<Employee>> IncrementValueBasedOnName()
        {
            return await employeeRepository.IncrementValueBasedOnName();
        }

        public async Task<List<Summatory>> SumValuesBasedOnName()
        {
            return await employeeRepository.SumValuesBasedOnName();
        }
    }
}
