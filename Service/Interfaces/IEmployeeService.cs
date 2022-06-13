using InterviewTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> AddEmployee(string name, int value);
        Task<List<Employee>> EditEmployee(string name, int value, string newName, int newValue);
        Task<List<Employee>> DeleteEmployee(string name, int value);
        Task<List<Employee>> IncrementValueBasedOnName();
        Task<List<Summatory>> SumValuesBasedOnName();
    }
}
