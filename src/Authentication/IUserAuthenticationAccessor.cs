// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Diagnostics.CodeAnalysis;

namespace BenjaminAbt.MyDemoPlatform.Authentication;

public interface IRequestUserIdentityAccessor
{
    bool TryGetUserIdentityId([NotNullWhen(true)] out Guid? userIdentityId);

    Guid GetUserIdentityIdOrThrowUnauthorized();
}
