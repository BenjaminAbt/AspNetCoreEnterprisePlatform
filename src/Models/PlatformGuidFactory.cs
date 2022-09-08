// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Diagnostics.CodeAnalysis;

namespace BenjaminAbt.MyDemoPlatform.Models;

public abstract class PlatformGuidFactory<T> where T : PlatformBaseGuid, new()
{
    public static T Create(Guid id) => new() { Value = id };
    public static T Create() => new() { Value = Guid.NewGuid() };

    public static bool TryParse(string? s, [NotNullWhen(true)] out T? azureTenantId)
    {
        if (Guid.TryParse(s, out Guid value))
        {
            azureTenantId = new T
            {
                Value = value
            };
            return true;
        }
        azureTenantId = null;
        return false;
    }
}
