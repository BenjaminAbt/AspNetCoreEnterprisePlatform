using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Models.EntityFramework;

public static class PlatformPropertyBuilderExtensions
{
    public static PropertyBuilder<PlatformTenantId> UseConversionPlatformTenantId(
        this PropertyBuilder<PlatformTenantId> propertyBuilder)
       => propertyBuilder.HasConversion(v => v.Value, v => new PlatformTenantId(v));
    public static PropertyBuilder<PlatformTenantId?> UseConversionPlatformTenantIdNullable(
        this PropertyBuilder<PlatformTenantId?> propertyBuilder)
    => propertyBuilder.HasConversion(v => v == null ? default : v.Value, v => v == default ? null : new(v));

    public static PropertyBuilder<PlatformUserId> UseConversionPlatformUserId(
        this PropertyBuilder<PlatformUserId> propertyBuilder)
       => propertyBuilder.HasConversion(v => v.Value, v => new PlatformUserId(v));

    public static PropertyBuilder<PlatformUserId?> UseConversionPlatformUserIdNullable(
        this PropertyBuilder<PlatformUserId?> propertyBuilder)
    => propertyBuilder.HasConversion(v => v == null ? default : v.Value, v => v == default ? null : new(v));
}
