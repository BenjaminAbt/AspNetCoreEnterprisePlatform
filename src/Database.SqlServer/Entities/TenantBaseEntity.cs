// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;

public abstract class TenantBaseEntity : BaseEntity
{
    public PlatformTenantId TenantId { get; set; } = null!;
}
