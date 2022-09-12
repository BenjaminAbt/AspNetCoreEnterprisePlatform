// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;

public class TenantAddCommandHandler : ICommandHandler<TenantAddCommand, PlatformTenantId>
{
    private readonly ITenantsDbContext _dbContext;
    private readonly TenantsRepository _tenantsRepository;


    public TenantAddCommandHandler(
        ITenantsDbContext dbContext,
        TenantsRepository tenantsRepository
        )
    {
        _dbContext = dbContext;
        _tenantsRepository = tenantsRepository;
    }

    public async Task<PlatformTenantId> Handle(TenantAddCommand request, CancellationToken cancellationToken)
    {
        PlatformTenantId platformTenantId = PlatformGuidFactory<PlatformTenantId>.Create();
        string tenantName = request.Name;

        // create tenant
        TenantEntity tenantEntity = new(platformTenantId, tenantName);

        // add tenant to context
        await _tenantsRepository.Add(tenantEntity).ConfigureAwait(false);

        // save changes
        DbSaveChangesResult saveChangesResult = await _dbContext
             .SaveChangesAsync(cancellationToken)
             .ConfigureAwait(false);

        return platformTenantId;
    }
}
