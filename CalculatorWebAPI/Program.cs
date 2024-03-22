using CalculatorApi;
using CalculatorApi.DB;

namespace CalculatorWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectString = "Data Source=tcp:192.168.0.197;Database=CalculatorApp;User Id=Bob;Password=bob;Encrypt=True;TrustServerCertificate=True;";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ISimpleCalculator, Calculator>();
            builder.Services.AddSingleton<IDiagnostics>(provider => new DBDiagnostics(connectString));

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
