// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public class TenantAlreadyExistsException : TenantBaseException
{
    public TenantAlreadyExistsException(PlatformTenantId platformTenantId, string name)
        : base($"A tenant with platform id '{platformTenantId}' or name '{name}' already exists.")
    {
    }
}
