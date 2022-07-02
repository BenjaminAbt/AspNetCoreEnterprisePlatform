using System.Collections.Generic;
using System.Text.Json.Serialization;
using BenjaminAbt.MyDemoPlatform.Models.AspNetCore.Converters;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore;

public static class MyDemoPlatformModelJsonConverters
{
    public static IEnumerable<JsonConverter> Converters()
    {
        yield return new PlatformBaseGuidConverter<PlatformTenantId>();
        yield return new PlatformBaseGuidConverter<PlatformUserId>();

        yield return new PlatformBaseGuidCollectionConverter<PlatformTenantId>();
        yield return new PlatformBaseGuidCollectionConverter<PlatformUserId>();
    }
}
