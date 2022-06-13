using InterviewTest.Helper.Interfaces;
using InterviewTest.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTest.Helper
{
    public class SqlLiteHandler : ISqlLiteHandler
    {
        SqliteConnectionStringBuilder connectionStringBuilder;

        public SqlLiteHandler()
        {
            connectionStringBuilder = new SqliteConnectionStringBuilder() { DataSource = "./SqliteDB.db" };
        }

        public async Task<int> ExecuteNonQueryAsync(string query)
        {
            int result = -1;

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var queryCmd = connection.CreateCommand();
                queryCmd.CommandText = query;

                result = await queryCmd.ExecuteNonQueryAsync();
            }

            return result;
        }

        public async Task<List<Employee>> ExecuteSelectQueryAsync(string query)
        {
            List<Employee> employees = new List<Employee>();
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var queryCmd = connection.CreateCommand();
                queryCmd.CommandText = query;

                var reader = await queryCmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Name = reader.GetString(0),
                        Value = reader.GetInt32(1)
                    });
                }
            }

            return employees;
        }

        public async Task<List<Summatory>> ExecuteSumQueryAsync(string query)
        {
            List<Summatory> summatory = new List<Summatory>();
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var queryCmd = connection.CreateCommand();
                queryCmd.CommandText = query;

                var reader = await queryCmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    summatory.Add(new Summatory
                    {
                        SumA = (!reader.IsDBNull(0)) ? reader.GetInt32(0) : 0,
                        SumB = (!reader.IsDBNull(1)) ? reader.GetInt32(1) : 0,
                        SumC = (!reader.IsDBNull(2)) ? reader.GetInt32(2) : 0
                });
                }
            }

            return summatory;
        }
    }
}
