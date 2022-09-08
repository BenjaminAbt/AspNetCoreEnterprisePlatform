// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;

public interface IRequestUserIdentityTenantAuthAccessor
{
    Task<UserTenantAccessResult?> HasTenantAccess(PlatformTenantId platformTenantId);
}
