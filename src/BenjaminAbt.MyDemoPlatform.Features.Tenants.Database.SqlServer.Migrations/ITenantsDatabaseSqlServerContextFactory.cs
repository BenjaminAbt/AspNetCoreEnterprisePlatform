namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations;

public interface ITenantsDatabaseSqlServerContextFactory
{
    string MigrationAssembly { get; }
}