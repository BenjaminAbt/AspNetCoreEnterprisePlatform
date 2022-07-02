using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Migrations;

public abstract class SqlServerMigrationContextFactory<TDbContext>
    : IDesignTimeDbContextFactory<TDbContext> where TDbContext : SqlServerBaseDbContext
{
    public abstract string MigrationAssembly { get; }

    public TDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer(
            b => b.MigrationsAssembly(MigrationAssembly));

        return (TDbContext)Activator.CreateInstance(typeof(TDbContext), optionsBuilder.Options)!;
    }
}

