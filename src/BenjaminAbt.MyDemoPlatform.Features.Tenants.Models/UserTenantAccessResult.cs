using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;

public readonly record struct UserTenantAccessResult(
    PlatformTenantId TenantId, PlatformUserId PlatformUserId);
