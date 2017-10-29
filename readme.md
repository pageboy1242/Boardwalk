# Stampede Motor Company Practicum


# Technology stack
- SQL Server localDB
- ASP.NET MVC 5/ C# 
- Bootstrap
- MS Test
- Unity.MVC5 - for IoC
- Moq

- Selenium Web Driver

# Running the app

- The app was built in Visual Studio 2017 and can be run in Visual Studio by opening the StampedeMotor.sln solution file and running the web project
- There is a test project that will also be loaded.  All tests can be run using the Studio test runner.  Some of the tests are integration tests and will affect the database, the tests are responsible for cleaning up after themselves, but if they fail for some reason, manual data cleanup may be required.

- The 'Makes' and 'Models' in the system do not have a UI and so must be managed manually, the DB ships with some default data however and can be used for testing.

