using System;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Migrations;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations;

/// <summary>
/// This class is used to generate the database context during migration time!
/// </summary>
public class SecurityPortalDatabaseSqlServerContextFactory
    : SqlServerMigrationContextFactory<SecurityPortalDatabaseSqlServerContext>
{
    // the current assembly is the migration assembly!
    public override string MigrationAssembly =>
        typeof(SecurityPortalDatabaseSqlServerContextFactory).Assembly.FullName
            ?? throw new Exception("The migration assembly could not be determined!");
}


