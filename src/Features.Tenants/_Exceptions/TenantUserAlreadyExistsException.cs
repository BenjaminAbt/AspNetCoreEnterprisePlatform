// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public class TenantUserAlreadyExistsException : TenantBaseException
{
    public TenantUserAlreadyExistsException(PlatformUserId platformUserId, string name)
        : base($"A tenant user with platform id '{platformUserId}' or name '{name}' already exists.")
    {
    }
}
