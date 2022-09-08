// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
