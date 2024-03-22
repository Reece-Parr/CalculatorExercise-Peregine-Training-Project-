using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi.DB
{
    public class InsertLogStoredProcedure : IDiagnostics
    {
        private readonly string _connectionString;

        public InsertLogStoredProcedure(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Log(string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("InsertLog", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@message", message);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
