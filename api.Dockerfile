FROM mcr.microsoft.com/dotnet/sdk:6.0 AS BuildAndPublish
WORKDIR /src
COPY src .
RUN dotnet publish "Prodinstock.WebApi/Prodinstock.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS Final
WORKDIR /app
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=BuildAndPublish /app/publish .

ENTRYPOINT ["dotnet", "Prodinstock.WebApi.dll"]
