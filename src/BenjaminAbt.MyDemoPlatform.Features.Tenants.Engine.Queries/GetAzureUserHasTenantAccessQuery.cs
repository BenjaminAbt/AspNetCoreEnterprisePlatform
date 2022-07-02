using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
public record class GetAzureUserHasTenantAccessQuery(
    PlatformTenantId TenantId, PlatformUserId PlatformUserId)
    : IQuery<UserTenantAccessResult?>;
