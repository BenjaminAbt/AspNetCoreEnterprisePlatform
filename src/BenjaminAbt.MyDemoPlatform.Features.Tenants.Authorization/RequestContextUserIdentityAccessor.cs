using BenjaminAbt.MyDemoPlatform.Authentication;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization;

public class RequestUserIdentityTenantAuthAccessor : IRequestUserIdentityTenantAuthAccessor
{
    private readonly IRequestUserIdentityAccessor _requestUserIdentityAccessor;
    private readonly IEventDispatcher _eventDispatcher;

    public RequestUserIdentityTenantAuthAccessor(
        IRequestUserIdentityAccessor requestUserIdentityAccessor,
        IEventDispatcher eventDispatcher)
    {
        _requestUserIdentityAccessor = requestUserIdentityAccessor;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<UserTenantAccessResult?> HasTenantAccess(PlatformTenantId platformTenantId)
    {
        if (!_requestUserIdentityAccessor.TryGetUserIdentityId(out Guid? userIdentityId) || !userIdentityId.HasValue)
        {
            return null;
        }

        PlatformUserId platformUserId = new(userIdentityId.Value);

        UserTenantAccessResult? userTenantAccessResult =
            await _eventDispatcher.Get(new GetAzureUserHasTenantAccessQuery(
                platformTenantId, platformUserId));

        return userTenantAccessResult;
    }
}
