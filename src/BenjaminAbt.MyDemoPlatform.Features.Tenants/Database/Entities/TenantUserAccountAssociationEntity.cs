using System;
using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;

public class TenantUserAccountAssociationEntity : BaseEntity
{
    public TenantUserAccountAssociationEntity() { }

    public TenantUserAccountAssociationEntity(Guid id, TenantEntity tenant, UserAccountEntity userAccount, DateTimeOffset createdOn)
    {
        Id = id;
        Tenant = tenant;
        UserAccount = userAccount;
        CreatedOn = createdOn;
    }

    public Guid Id { get; set; }

    /// <summary>
    /// Internal User Id
    /// </summary>
    public PlatformUserId UserAccountId { get; set; } = null!;

    public UserAccountEntity UserAccount { get; set; } = null!;

    /// <summary>
    /// Internal Tenant Id
    /// </summary>
    public PlatformTenantId TenantId { get; set; } = null!;

    public TenantEntity Tenant { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }
}
