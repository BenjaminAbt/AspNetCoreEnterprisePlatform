// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore;

public class RequestUserIdentityHttpContextAccessor : IRequestUserIdentityAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RequestUserIdentityHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpContext? CurrentHttpContext => _httpContextAccessor.HttpContext;


    public bool TryGetUserIdentityId([NotNullWhen(true)] out Guid? userIdentityId)
    {
        if (CurrentHttpContext is not null)
        {
            if (CurrentHttpContext.User.TryGetUserIdentityId(out userIdentityId) && userIdentityId.HasValue)
            {
                return true;
            }
        }

        userIdentityId = null;
        return false;
    }

    public Guid GetUserIdentityIdOrThrowUnauthorized()
    {
        if (TryGetUserIdentityId(out Guid? userIdentifier) && userIdentifier.HasValue)
        {
            return userIdentifier.Value;
        }

        throw new UnauthorizedAccessException();
    }
}
