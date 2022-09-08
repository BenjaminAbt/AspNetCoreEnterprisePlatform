// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
public record class GetAzureUserHasTenantAccessQuery(
    PlatformTenantId TenantId, PlatformUserId PlatformUserId)
    : IQuery<UserTenantAccessResult?>;
