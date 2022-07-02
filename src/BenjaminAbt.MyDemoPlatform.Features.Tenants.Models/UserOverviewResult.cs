using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;

public readonly record struct UserOverviewResult(PlatformUserId UserId, UserOverviewTenantItem[] Tenants);

public readonly record struct UserOverviewTenantItem(PlatformTenantId TenantId, string TenantName);
