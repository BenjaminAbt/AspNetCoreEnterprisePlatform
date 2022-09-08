// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public class TenantNotFoundException : TenantBaseException
{
    public TenantNotFoundException(PlatformTenantId platformTenantId)
        : base($"A tenant with platform id '{platformTenantId}' was not found.")
    {
        PlatformTenantId = platformTenantId;
    }

    public PlatformTenantId PlatformTenantId { get; }
}
