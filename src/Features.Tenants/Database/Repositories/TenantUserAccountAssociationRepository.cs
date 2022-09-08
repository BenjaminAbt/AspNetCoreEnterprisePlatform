// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;

public class TenantUserAccountAssociationRepository : BaseRepository<TenantUserAccountAssociationEntity>
{
    public TenantUserAccountAssociationRepository(ITenantsDbContext dbContext) : base(dbContext)
    {
    }
}
