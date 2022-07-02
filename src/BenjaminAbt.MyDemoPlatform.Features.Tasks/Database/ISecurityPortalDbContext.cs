using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database;

public interface ISecurityPortalDbContext : ISqlServerDbContext
{
    DbSet<AzureLogAnalyticsWorkspaceTenantEntity> AzureLogAnalyticsWorkspaceTenants { get; set; }
    DbSet<MicrosoftDefenderTenantClientCredentialsEntity> MicrosoftDefenderTenantClientCredentials { get; set; }
}
