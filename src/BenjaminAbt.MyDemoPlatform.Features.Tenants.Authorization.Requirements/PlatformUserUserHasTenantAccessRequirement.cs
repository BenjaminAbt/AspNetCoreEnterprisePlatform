using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.AspNetCore.Authorization;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Requirements;

public record class PlatformUserUserHasTenantAccessRequirement(PlatformTenantId TenantId)
    : IAuthorizationRequirement;
