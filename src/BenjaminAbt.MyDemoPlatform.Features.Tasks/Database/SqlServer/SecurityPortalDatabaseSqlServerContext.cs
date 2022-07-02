using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer;

/// Warning: do not rename this class without edit the CI/CD Pipeline (Migrations!) too!

public class SecurityPortalDatabaseSqlServerContext : SqlServerBaseDbContext, ISecurityPortalDbContext
{
    public SecurityPortalDatabaseSqlServerContext(DbContextOptions<SecurityPortalDatabaseSqlServerContext> options)
        : base(options) { }


    public DbSet<AzureLogAnalyticsWorkspaceTenantEntity> AzureLogAnalyticsWorkspaceTenants { get; set; } = null!;
    public DbSet<MicrosoftDefenderTenantClientCredentialsEntity> MicrosoftDefenderTenantClientCredentials { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.ApplyConfiguration(new AzureLogAnalyticsWorkspaceTenantEntityConfig());
        b.ApplyConfiguration(new MicrosoftDefenderTenantClientCredentialsEntityConfig());
    }
}
