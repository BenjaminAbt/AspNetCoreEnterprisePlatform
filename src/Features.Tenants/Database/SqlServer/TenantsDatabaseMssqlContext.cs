// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer;

/// Warning: do not rename this class without edit the CI/CD Pipeline (Migrations!) too!

public class TenantsDatabaseSqlServerContext : SqlServerBaseDbContext, ITenantsDbContext
{
    public TenantsDatabaseSqlServerContext(DbContextOptions<TenantsDatabaseSqlServerContext> options)
        : base(options) { }

    public DbSet<TenantEntity> Tenants => Set<TenantEntity>();
    public DbSet<TenantUserAccountAssociationEntity> TenantUserAccountAssociations => Set<TenantUserAccountAssociationEntity>();

    public DbSet<UserAccountEntity> UserAccounts => Set<UserAccountEntity>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.ApplyConfiguration(new TenantEntityConfig());
        b.ApplyConfiguration(new TenantUserAccountAssociationEntityConfig());

        b.ApplyConfiguration(new UserAccountEntityConfig());
    }
}
