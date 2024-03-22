using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi.DB.EntityFramework
{
    public class EFDBDiagnostics : IDiagnostics
    {
        private readonly EFDatabaseContext _dbContext;

        public EFDBDiagnostics(EFDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Log(string message)
        {
            var logEntry = new EFDiagnosticLog
            {
                Message = message,
                Timestamp = DateTime.Now
            };

            _dbContext.Logs.Add(logEntry);
            _dbContext.SaveChanges();
        }
    }
}
