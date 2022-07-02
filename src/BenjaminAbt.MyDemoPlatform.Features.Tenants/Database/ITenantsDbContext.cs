using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database;

public interface ITenantsDbContext : ISqlServerDbContext
{
    // Sets

    DbSet<TenantEntity> Tenants { get; set; }
    DbSet<TenantUserAccountAssociationEntity> TenantUserAccountAssociations { get; set; }

    DbSet<UserAccountEntity> UserAccounts { get; set; }
}
