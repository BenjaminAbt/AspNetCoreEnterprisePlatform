# Tenants Database Migration

This project is used to handle the Tenants Database Migrations with EF Core

https://docs.microsoft.com/de-de/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli


A seperate assembly is used to have separate isolation.

## Install Tooling
> dotnet tool install dotnet-ef

or

> dotnet tool update dotnet-ef


## Add Migration

> Execute in main folder
```shell
dotnet ef migrations add Init --project src/BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations --startup-project src/BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations
```

## Export Script

```shell
dotnet ef migrations script --output tenants.schema.sql --idempotent --project src/BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations/BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations.csproj --context TenantsDatabaseSqlServerContext
```
