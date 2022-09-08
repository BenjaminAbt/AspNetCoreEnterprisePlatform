// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;

public readonly record struct UserOverviewResult(PlatformUserId UserId, UserOverviewTenantItem[] Tenants);

public readonly record struct UserOverviewTenantItem(PlatformTenantId TenantId, string TenantName);
