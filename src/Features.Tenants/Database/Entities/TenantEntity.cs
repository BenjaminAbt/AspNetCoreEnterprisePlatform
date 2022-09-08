// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;

public class TenantEntity : BaseEntity
{
    public TenantEntity(PlatformTenantId id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Internal Id
    /// </summary>
    public PlatformTenantId Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public ICollection<TenantUserAccountAssociationEntity> TenantUserAccountAssociations { get; set; }
        = new List<TenantUserAccountAssociationEntity>(0);
}

