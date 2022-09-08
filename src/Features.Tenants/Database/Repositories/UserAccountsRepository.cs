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

public class UserAccountsRepository : BaseRepository<UserAccountEntity>
{
    private readonly ITenantsDbContext _userDbContext;

    public UserAccountsRepository(ITenantsDbContext userDbContext) : base(userDbContext)
    {
        _userDbContext = userDbContext;
    }

    // Queries

    public IQueryable<UserAccountEntity> QueryUsers(DbTrackingOptions to)
        => _userDbContext.UserAccounts.With(to);

    public IQueryable<UserAccountEntity> QueryUser(PlatformUserId platformUserId, DbTrackingOptions to)
        => QueryUsers(to).Where(UserAccountQuery.WithId(platformUserId));
    public IQueryable<UserAccountEntity> QueryUsers(PlatformTenantId tenantId, DbTrackingOptions to)
        => QueryUsers(to).Where(UserAccountQuery.OfTenant(tenantId));

    public Task<UserAccountEntity?> GetUser(PlatformUserId platformUserId, DbTrackingOptions to, CancellationToken cancellationToken = default)
        => QueryUser(platformUserId, to)
            .SingleOrDefaultAsync<UserAccountEntity?>(cancellationToken);

}

