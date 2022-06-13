using InterviewTest.Model;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Helper.Interfaces
{
    public interface ISqlLiteHandler
    {
        Task<int> ExecuteNonQueryAsync(string query);
        Task<List<Employee>> ExecuteSelectQueryAsync(string query);
        Task<List<Summatory>> ExecuteSumQueryAsync(string query);
    }
}