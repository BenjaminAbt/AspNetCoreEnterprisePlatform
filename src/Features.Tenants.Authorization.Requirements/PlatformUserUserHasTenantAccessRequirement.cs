// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.AspNetCore.Authorization;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Requirements;

public record class PlatformUserUserHasTenantAccessRequirement(PlatformTenantId TenantId)
    : IAuthorizationRequirement;
