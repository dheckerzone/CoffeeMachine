# CoffeeMachine

### How to run
- Download or Clone Solution
- Open command prompt in admin mode
- Go to Coffee Machine folder where you can see the packages.json
- run "npm install" without quotes
- run "ng serve --proxy-config proxy.config.json
-----
- Open solution in Visual Studio
- Build the solution to restore nuget packages
- Open another command prompt in Admin mode on the solution folder
- run "dotnet watch run" without quotes
  (this is to run the solution in the port we indicated in the UI)
- open localhost:4200 in your browser

_Note: By default db used was localdb, if you want to use a different DB, you can change the connection in the CoffeeMachineDbContext.cs file under EF Project_
