using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Queries;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Repositories;

public class AzureLogAnalyticsWorkspaceTenantRepository : BaseRepository<AzureLogAnalyticsWorkspaceTenantEntity>
{
    private readonly ISecurityPortalDbContext _dbContext;

    public AzureLogAnalyticsWorkspaceTenantRepository(ISecurityPortalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<AzureLogAnalyticsWorkspaceTenantEntity> QueryAzureLogAnalyticsWorkspaceTenants(DbTrackingOptions to)
        => _dbContext.AzureLogAnalyticsWorkspaceTenants.With(to);
    public IQueryable<AzureLogAnalyticsWorkspaceTenantEntity> QueryAzureLogAnalyticsWorkspaceTenantsByTenantId(PlatformTenantId tenantId, DbTrackingOptions to)
        => QueryAzureLogAnalyticsWorkspaceTenants(to)
        .Where(AzureLogAnalyticsWorkspaceTenantQuery.WithTenantId(tenantId));

    public async Task<AzureWorkspaceId?> GetWorkspaceIdByTenant(PlatformTenantId tenantId, CancellationToken cancellationToken = default)
    {
        AzureWorkspaceId workspaceId = await QueryAzureLogAnalyticsWorkspaceTenantsByTenantId(tenantId, DbTrackingOptions.Disabled)
            .Select(e => e.WorkspaceId)
            .SingleOrDefaultAsync(cancellationToken);

        if (workspaceId == default)
        {
            return null;
        }

        return workspaceId;
    }
}

