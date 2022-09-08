// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;

namespace BenjaminAbt.MyDemoPlatform.Common;

public static class GuidExtension
{
    public static Guid GetValue(this Guid? source) => source!.Value;
    public static Guid GetValueOrThrow(this Guid? source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Value;
    }
}
