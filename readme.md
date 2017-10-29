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

# Using the App

- When started the application should start at the Home page (web site root URL).  It should display a welcome banner and 4 prealoaded cars
- Below the car listing there is an "Add Car" button which can be used to add new cars to the system

# Adding Cars

- All fields are mandatory, an error message will be displayed if a field is not entered.

- To add a car, you must select a Make and a Model.  There is no association between these dropdowns, any model can be associated with any make.  However, if the system already has a car with the selected Make and Model, another one cannot be added.  If this is attempted, the system will display a validation error.
- The description field allows up to 400 character
- The price field cannot exceed 100000

# Known Issues

- The selected image will be lost if there is a validation error on another field
- Varying image sizes and description text lengths can cause empty columns on the Listing Screen responsive layout
- The site is not WCAG compliant