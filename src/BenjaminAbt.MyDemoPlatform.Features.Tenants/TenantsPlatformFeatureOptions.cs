using BenjaminAbt.MyDemoPlatform.Features.Abstractions;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public class TenantsPlatformFeatureOptions : IMyDemoPlatformPlatformFeatureOptions
{
    public TenantsDatabaseConfig? Database { get; set; }
}
