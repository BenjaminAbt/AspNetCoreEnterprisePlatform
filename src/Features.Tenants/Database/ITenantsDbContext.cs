// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database;

public interface ITenantsDbContext : ISqlServerDbContext
{
    // Sets

    DbSet<TenantEntity> Tenants { get; }
    DbSet<TenantUserAccountAssociationEntity> TenantUserAccountAssociations { get; }

    DbSet<UserAccountEntity> UserAccounts { get; }
}
