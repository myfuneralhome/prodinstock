# Introduction 

# Getting Started
## How add new migrations on the web api ?
``dotnet ef migrations add "XXX" --context ProductContext --startup-project .\src\BTech.Prodinstock.WebApi\ --project .\src\BTech.Prodinstock.Infrastructure\``

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Deploy
To update identity server database :
``dotnet ef database update --context ProductContext --startup-project .\BTech.Prodinstock.WebApi``
