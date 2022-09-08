// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;

namespace BenjaminAbt.MyDemoPlatform.Authentication;

public static partial class ClaimsPrincipalExtensions
{

    /// <summary>
    /// Returns the tenant identifier or null
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/azure/active-directory/develop/id-tokens</remarks>
    /// <returns>tenant identifier or null</returns>
    public static Guid? GetUserIdentityId(this ClaimsPrincipal claimsPrincipal)
    {
        // https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/claims
        Claim? userIdentifierClaim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type is "oid" or "http://schemas.microsoft.com/identity/claims/objectidentifier");

        string userIdentifierValue = userIdentifierClaim?.Value;
        if (Guid.TryParse(userIdentifierValue, out Guid userIdentifier))
        {
            return userIdentifier;
        }

        return null;
    }

    /// <summary>
    /// <see cref="GetUserIdentifier(ClaimsPrincipal)"/>
    /// </summary>
    public static bool TryGetUserIdentityId(this ClaimsPrincipal claimsPrincipal, [NotNullWhen(true)] out Guid? platformUserId)
    {
        Guid? userIdentifier = claimsPrincipal.GetUserIdentityId();
        if (userIdentifier is not null)
        {
            platformUserId = userIdentifier;
            return true;
        }

        platformUserId = null;
        return false;
    }
}
