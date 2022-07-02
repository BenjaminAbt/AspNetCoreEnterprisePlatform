using System;
using System.Diagnostics.CodeAnalysis;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Authentication;

public interface IRequestUserIdentityAccessor
{
    bool TryGetUserIdentityId([NotNullWhen(true)] out Guid? userIdentityId);

    Guid GetUserIdentityIdOrThrowUnauthorized();
}
