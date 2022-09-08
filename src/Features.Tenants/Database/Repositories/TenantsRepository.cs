// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Queries;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;

public class TenantsRepository : BaseRepository<TenantEntity>
{
    private readonly ITenantsDbContext _dbContext;

    public TenantsRepository(ITenantsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
        => _dbContext.Tenants.CountAsync(cancellationToken);

    public IQueryable<TenantEntity> QueryTenants(DbTrackingOptions to)
        => _dbContext.Tenants.With(to);
    public IQueryable<TenantEntity> QueryTenant(PlatformTenantId id, DbTrackingOptions to)
        => QueryTenants(to).Where(TenantEntityQuery.WithId(id));

    public IQueryable<TenantUserAccountAssociationEntity> QueryTenantUserAssociations(DbTrackingOptions to)
    => _dbContext.TenantUserAccountAssociations.With(to);
    public IQueryable<TenantUserAccountAssociationEntity> QueryTenantUserAssociation(PlatformTenantId tenantId, PlatformUserId userId, DbTrackingOptions to)
        => QueryTenantUserAssociations(to).Where(
            a => a.TenantId == tenantId && a.UserAccountId == userId);

    public Task<TenantEntity?> GetTenant(PlatformTenantId id, DbTrackingOptions to, CancellationToken cancellationToken = default)
        => QueryTenant(id, to).SingleOrDefaultAsync(cancellationToken);

    public Task<TenantUserAccountAssociationEntity?> GetUserAssociation(PlatformTenantId platformTenantId, PlatformUserId platformUserId, DbTrackingOptions to, CancellationToken cancellationToken = default)
        => QueryTenantUserAssociation(platformTenantId, platformUserId, to)
                .SingleOrDefaultAsync(cancellationToken);
}
