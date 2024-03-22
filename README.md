# Calculator Exericse Project

# Tasks to be completed: 
Visual Studio
1.	Using .NET Framework (4.6.1, not .NET Core), create a C# solution e.g. CalculatorTest.
2.	Create a C# class library e.g. CalculatorApi containing the interface above.

TDD / Mocking
3.	Create a class library called CalculatorTests and implement a suite of suitable unit tests for the above interface using test-driven design principles using a test framework of your choosing e.g. NUnit.
4.	Implement a C# class to realize the calculator interface and demonstrate the unit tests now pass.
5.	Create a console application that uses the calculator class and demonstrate it working.

IoC / Dependency Injection/ Moq
6.	Add a new diagnostics interface to CalculatorApi that exposes a simple method to log a string value. 
7.	(Moq) Mock the diagnostics interface and introduce it into your calculator implementation. Refactor your unit tests so that your test suite checks that the diagnostics interface is called.
8.	Implement the diagnostics interface so that it logs to the console. Use injection to call it in your calculator’s console application using an IoC container of your choosing e.g. Autofac. Demonstrate that the calculation diagnostics are output correctly in the console application.
9.	Implement a “null” diagnostics interface that doesn’t report anything. Replace the console-based diagnostics implementation with this one without modifying the functional calculator code i.e. via IoC container configuration. Demonstrate the calculator still works in the console app but no console diagnostics are logged.

Entity Framework / SQL Server
10.	Create a SQL Server database, database first, to store logging information, create an Entity Framework model to allow the console application to write the diagnostics information to the database.
11.	Implement a class that realizes the diagnostics interface to log to the corresponding database table using the EF model. Modify the console application via the IoC configuration so that it outputs the diagnostics to the database.
12.	Implement another diagnostics class that does not use EF and instead uses a stored procedure to write the diagnostics data to the database.

Web Services
13.	Create and host a simple web service that provides access to the calculator class via a RESTful API. Demonstrate using a web browser.
14.	Modify the console application to access the calculator web service to perform calculations instead of using the “internal” class implementation.

# How to use the Project.
Only need to use the CalculatorApp project in the solution to run all the functionality. 
Code is commented out for other requirements so I could contain everything in one solution. Removing the comments means I can quickly changed between the different features.
This is done due to the Dependency Injection and Interfaces to allow for robust code. 
Program will not work on the Database side due to local Database. WEBAPI also runs locally but can work with quick change of ports. 
