using CalculatorApi;
using System.Globalization;
using Autofac;
using CalculatorApi.DB.EntityFramework;
using CalculatorApi.DB;
using System.Net.Http;

namespace CalculatorApp
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            string connectString = "Data Source=tcp:192.168.0.197;Database=CalculatorApp;User Id=Bob;Password=bob;Encrypt=True;TrustServerCertificate=True;";

            // Container Creation
            var containerBuilder = new ContainerBuilder();

            // Register Services

            // Console OUTPUT of Diagnostic Logging.
            // containerBuilder.RegisterType<Diagnostics>().As<IDiagnostics>().SingleInstance();


            // Implemented a null diagnostic services to show DI and how it won't break the program with a switch of functionality -
                                                                                        due to a reliance on interfaces and containers.
            containerBuilder.RegisterType<NullDiagnostics>().As<IDiagnostics>().SingleInstance();


            // Using a Database, this is a NON-Entity Framework Model.
            // containerBuilder.RegisterType<DBDiagnostics>().As<IDiagnostics>().WithParameter("connectionString", connectString).SingleInstance();

            //Using a Database with an Entity Framework Model.
            //containerBuilder.RegisterType<EFDBDiagnostics>().As<IDiagnostics>().SingleInstance();
            //containerBuilder.RegisterType<EFDatabaseContext>().WithParameter("connectionString", connectString).SingleInstance();

            // Using a Database with a Stored Procedure.
            containerBuilder.RegisterType<InsertLogStoredProcedure>().As<IDiagnostics>().WithParameter("connectionString", connectString).SingleInstance();
            containerBuilder.RegisterType<Calculator>().As<ISimpleCalculator>().SingleInstance();

            // Build Container
            var container = containerBuilder.Build();
            Console.WriteLine("Container has been built for Calculator App");

            // Resolve services
            var calc = container.Resolve<ISimpleCalculator>();
            
            Console.WriteLine("Console Calculator App.");
            Console.WriteLine("-----------------------");

            bool menu = false;
            while (!menu)
            {
                int numOne, numTwo, menuOption;

                Console.WriteLine("Out of the following list select an operation:\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
                if (!int.TryParse(Console.ReadLine(), out menuOption))
                {
                    Console.WriteLine("Invalid menu input. Please enter a valid option.\n");
                    continue;
                }

                Console.Write("Enter the first number: ");
                if (!int.TryParse(Console.ReadLine(), out numOne))
                {
                    Console.WriteLine("Invalid input for the first number. Please try again.\n");
                    continue;
                }

                Console.Write("Enter the second number: ");
                if (!int.TryParse(Console.ReadLine(), out numTwo))
                {
                    Console.WriteLine("Invalid input for the second number. Please try again.\n");
                    continue;
                }

                if (menuOption == 1)
                {
                    Console.WriteLine("Added answer: " + calc.Add(numOne, numTwo));
                    menu = true;
                }
                else if (menuOption == 2)
                {
                    Console.WriteLine("Subtracted answer: " + calc.Subtract(numOne, numTwo));
                    menu = true;
                } 
                else if (menuOption == 3) 
                {
                    Console.WriteLine("Multiplied answer: " + calc.Multiply(numOne, numTwo));
                    menu = true;
                } 
                else if (menuOption == 4)
                {
                    if (numOne == 0 || numTwo == 0) 
                    {
                        Console.WriteLine("Cannot divide by zero. Please enter another number.");
                        continue;
                    }
                    Console.WriteLine("Divided answer: " + calc.Divide(numOne, numTwo));
                    menu = true;
                }
                else
                {
                    Console.WriteLine("Value out of range of menu functions, try again!\n");
                    continue;
                }

            }

            Console.WriteLine("Program finished.");
            Console.ReadLine();

        }*/
   
        static async Task Main(string[] args)
        {
            string baseUrl = "https://localhost:7113/calculator/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine("Console Calculator App.");
                    Console.WriteLine("-----------------------");

                    bool menu = false;
                    while (!menu)
                    {
                        int numOne, numTwo, menuOption;

                        Console.WriteLine("Out of the following list select an operation:\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
                        Console.Write("Enter an operation number: ");
                        if (!int.TryParse(Console.ReadLine(), out menuOption))
                        {
                            Console.WriteLine("Invalid menu input. Please enter a valid option.\n");
                            continue;
                        }

                        Console.Write("Enter the first number: ");
                        if (!int.TryParse(Console.ReadLine(), out numOne))
                        {
                            Console.WriteLine("Invalid input for the first number. Please try again.\n");
                            continue;
                        }

                        Console.Write("Enter the second number: ");
                        if (!int.TryParse(Console.ReadLine(), out numTwo))
                        {
                            Console.WriteLine("Invalid input for the second number. Please try again.\n");
                            continue;
                        }

                        HttpResponseMessage response;

                        switch (menuOption)
                        {
                            case 1:
                                response = await client.GetAsync($"{baseUrl}add?numOne={numOne}&numTwo={numTwo}");
                                break;
                            case 2:
                                response = await client.GetAsync($"{baseUrl}subtract?numOne={numOne}&numTwo={numTwo}");
                                break;
                            case 3:
                                response = await client.GetAsync($"{baseUrl}multiply?numOne={numOne}&numTwo={numTwo}");
                                break;
                            case 4:
                                response = await client.GetAsync($"{baseUrl}divide?numOne={numOne}&numTwo={numTwo}");
                                break;
                            default:
                                Console.WriteLine("Invalid operation number.");
                                return;
                        }

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            int result = int.Parse(responseBody);
                            Console.WriteLine($"Result: {result}");
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode}");
                        }
                    }
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine($"An error occured: {ex.Message}");
                }
            }
        }
    }
}
