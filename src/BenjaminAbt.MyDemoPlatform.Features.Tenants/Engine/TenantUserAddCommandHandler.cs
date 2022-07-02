using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;
using BenjaminAbt.MyDemoPlatform.Models;
using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;

public class TenantUserAddCommandHandler : ICommandHandler<TenantUserAddCommand, PlatformUserId>
{
    private readonly ITenantsDbContext _dbContext;
    private readonly TenantsRepository _tenantsRepository;
    private readonly UserAccountsRepository _userAccountsRepository;
    private readonly TenantUserAccountAssociationRepository _tenantUserAccountAssociationRepository;


    public TenantUserAddCommandHandler(
        ITenantsDbContext dbContext,
        TenantsRepository tenantsRepository,
        UserAccountsRepository userAccountsRepository,
        TenantUserAccountAssociationRepository tenantUserAccountAssociationRepository
        )
    {
        _dbContext = dbContext;
        _tenantsRepository = tenantsRepository;
        _userAccountsRepository = userAccountsRepository;
        _tenantUserAccountAssociationRepository = tenantUserAccountAssociationRepository;
    }

    public async Task<PlatformUserId> Handle(TenantUserAddCommand request, CancellationToken cancellationToken)
    {
        PlatformTenantId platformTenantId = request.PlatformTenantId;
        PlatformUserId platformUserId = PlatformGuidFactory<PlatformUserId>.Create();
        string userName = request.Name;
        DateTimeOffset now = DateTimeOffset.UtcNow;

        // find tenant
        TenantEntity? tenantEntity = await _tenantsRepository.GetTenant(platformTenantId, DbTrackingOptions.Enabled);
        if (tenantEntity is null) throw new TenantNotFoundException(platformTenantId);


        // check if user exists
        UserAccountEntity? userEntity = await _userAccountsRepository.GetUser(platformUserId, DbTrackingOptions.Enabled).ConfigureAwait(false);

        // create user if not exists
        if (userEntity is null)
        {
            // create user
            userEntity = new(PlatformGuidFactory<PlatformUserId>.Create(), userName, now);

            // add user to context
            _userAccountsRepository.Add(userEntity);

            // create association from user to tenant
            TenantUserAccountAssociationEntity userTenantAssociation =
                new(Guid.NewGuid(), tenantEntity, userEntity, now);

            _tenantUserAccountAssociationRepository.Add(userTenantAssociation);
        }
        // check if user is already in tenant
        else
        {
            TenantUserAccountAssociationEntity? userTenantAssociation = await _tenantsRepository.GetUserAssociation(
                platformTenantId, userEntity.Id,
                DbTrackingOptions.Enabled).ConfigureAwait(false);

            if (userTenantAssociation is null)
            {
                // create association to tenant
                userTenantAssociation = new(Guid.NewGuid(), tenantEntity, userEntity, now);

                // add to context
                _tenantUserAccountAssociationRepository.Attach(userTenantAssociation);
            }
        }

        // save changes
        DbSaveChangesResult saveChangesResult = await _dbContext
             .SaveChangesAsync(cancellationToken)
             .ConfigureAwait(false);

        return platformUserId;
    }
}
