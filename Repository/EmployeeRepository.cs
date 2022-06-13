using InterviewTest.Helper.Interfaces;
using InterviewTest.Model;
using InterviewTest.Repository.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlLiteHandler sqlLiteHandler;
        private string querySelectAll = "SELECT * FROM Employees e ORDER BY e.Name ASC";

        public EmployeeRepository(ISqlLiteHandler sqlLiteHandler)
        {
            this.sqlLiteHandler = sqlLiteHandler;
        }

        public async Task<List<Employee>> AddEmployee(string name, int value)
        {
            string query = $"INSERT INTO Employees VALUES ('{name}', {value})";
            int rowsChanged = await sqlLiteHandler.ExecuteNonQueryAsync(query);
            return await sqlLiteHandler.ExecuteSelectQueryAsync(querySelectAll);
        }

        public async Task<List<Employee>> DeleteEmployee(string name, int value)
        {
            string query =  $"DELETE FROM Employees " +
                            $"WHERE Employees.Name='{name}' AND Employees.Value = {value}";
            int rowsChanged = await sqlLiteHandler.ExecuteNonQueryAsync(query);
            return await sqlLiteHandler.ExecuteSelectQueryAsync(querySelectAll);
        }

        public async Task<List<Employee>> EditEmployee(string name, int value, string newName, int newValue)
        {
            string query =  $"UPDATE Employees " +
                            $"SET Name = '{newName}', Value = {value} " +
                            $"WHERE Employees.Name='{name}' AND Employees.Value = {value}";
            int rowsChanged = await sqlLiteHandler.ExecuteNonQueryAsync(query);
            return await sqlLiteHandler.ExecuteSelectQueryAsync(querySelectAll);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await sqlLiteHandler.ExecuteSelectQueryAsync(querySelectAll);
        }

        public async Task<List<Employee>> IncrementValueBasedOnName()
        {
            string query =  "UPDATE Employees SET Value = CASE " +
                            "WHEN UPPER(Employees.Name) LIKE 'E%' THEN Employees.Value + 1 " +
                            "WHEN UPPER(Employees.Name) LIKE 'G%' THEN Employees.Value + 10 " +
                            "ELSE Employees.Value + 100 " +
                            "END";
            int rowsChanged = await sqlLiteHandler.ExecuteNonQueryAsync(query);
            return await sqlLiteHandler.ExecuteSelectQueryAsync(querySelectAll);
        }

        public async Task<List<Summatory>> SumValuesBasedOnName()
        {
            string query =  "SELECT " +
                            "SUM(CASE WHEN UPPER(e.Name) LIKE 'A%' THEN e.Value ELSE 0 END) AS InitialA, " +
                            "SUM(CASE WHEN UPPER(e.Name) LIKE 'B%' THEN e.Value ELSE 0 END) AS InitialB, " +
                            "SUM(CASE WHEN UPPER(e.Name) LIKE 'C%' THEN e.Value ELSE 0 END) AS InitialC " +
                            "FROM Employees e";

            string alternativeQuery =   "SELECT" +
                                        "(CASE WHEN SUM(CASE WHEN Upper(e.Name) LIKE 'A%' THEN e.Value ELSE 0 END) >= 11171 THEN SUM(CASE WHEN Upper(e.Name) LIKE 'A%' THEN e.Value ELSE 0 END) ELSE Null END) AS SumatorioA," +
	                                    "(CASE WHEN SUM(CASE WHEN Upper(e.Name) LIKE 'B%' THEN e.Value ELSE 0 END) >= 11171 THEN SUM(CASE WHEN Upper(e.Name) LIKE 'B%' THEN e.Value ELSE 0 END) ELSE Null END) AS SumatorioB," +
	                                    "(CASE WHEN SUM(CASE WHEN Upper(e.Name) LIKE 'C%' THEN e.Value ELSE 0 END) >= 11171 THEN SUM(CASE WHEN Upper(e.Name) LIKE 'C%' THEN e.Value ELSE 0 END) ELSE Null END) AS SumatorioC "+
                                        "FROM Employees e";
            return await sqlLiteHandler.ExecuteSumQueryAsync(query);
        }
    }
}
