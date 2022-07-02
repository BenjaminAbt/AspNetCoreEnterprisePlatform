using System;
namespace BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore;

public sealed class RequestContextUserIdentity
{
    public RequestContextUserIdentity(Guid platformUserId)
    {
        PlatformUserId = platformUserId;
    }

    public Guid PlatformUserId { get; }
}
