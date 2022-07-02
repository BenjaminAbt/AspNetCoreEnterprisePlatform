using System;
using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;

public class UserAccountEntity : BaseEntity
{
    public UserAccountEntity() { }
    public UserAccountEntity(PlatformUserId id, string name, DateTimeOffset createdOn)
    {
        Id = id;
        Name = name;
        CreatedOn = createdOn;
    }

    /// <summary>
    /// Internal Id
    /// </summary>
    public PlatformUserId Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTimeOffset CreatedOn { get; set; }

    public ICollection<TenantUserAccountAssociationEntity> TenantUserAccountAssociations { get; set; }
        = new List<TenantUserAccountAssociationEntity>(0);

}
