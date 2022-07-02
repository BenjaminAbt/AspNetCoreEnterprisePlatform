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
