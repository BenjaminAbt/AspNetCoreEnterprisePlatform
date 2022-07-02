# BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations

This project is used to handle the Security Portal Database Migrations with EF Core

https://docs.microsoft.com/de-de/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli


A seperate assembly is used to have separate isolation.

## Install Tooling
> dotnet tool install dotnet-ef

or

> dotnet tool update dotnet-ef


## Add Migration

> Execute in main folder
```shell
dotnet ef migrations add Init --project src/BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations --startup-project src/BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations
```

## Export Script

```shell
dotnet ef migrations script --output securityportal.schema.sql --idempotent --project src/BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations/BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations.csproj --context SecurityPortalDatabaseSqlServerContext
```
