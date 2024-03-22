using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi.DB.EntityFramework
{
    public class EFDiagnosticLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class EFDatabaseContext : DbContext
    {
        public DbSet<EFDiagnosticLog> Logs { get; set; }

        private readonly string _connectionString;

        public EFDatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }

}
