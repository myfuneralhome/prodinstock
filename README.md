# What is it ?
Web API to manage products and categories in Asp.NET Core 6.

# How to run it ?
Run the docker compose file :
``docker compose up``

Cors settings could be parametize as below. You could add as many host as you want. Just increment the last suffix (0, 1, 2, etc..) :
``CORS__AllowedOrigins__0: "http://localhost:1111" ``

# Technical aspect
## How add new migrations on the web api ?
``dotnet ef migrations add "XXX" --context ProductContext --startup-project .\src\BTech.Prodinstock.WebApi\ --project .\src\BTech.Prodinstock.Infrastructure\``

## Deploy
To apply database according to the migrations :
``dotnet ef database update --context ProductContext --startup-project .\src\BTech.Prodinstock.WebApi``
