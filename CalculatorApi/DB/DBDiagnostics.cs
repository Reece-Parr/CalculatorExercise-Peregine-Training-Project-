using Microsoft.Data.SqlClient;

namespace CalculatorApi.DB
{
    public class DBDiagnostics : IDiagnostics
    {
        private readonly string _connectionString;

        public DBDiagnostics(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Log(string message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Logs (message, timestamp) VALUES (@Message, @Timestamp)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@message", message);
                        command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging to database: {ex}");
            }
        }
    }
}
