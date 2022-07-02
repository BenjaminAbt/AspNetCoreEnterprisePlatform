using BenjaminAbt.MyDemoPlatform.Features.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal;

public class SecurityPortalPlatformFeatureOptions : IMyDemoPlatformPlatformFeatureOptions
{
    public SecurityPortalDatabaseConfig? Database { get; set; }
    public LogAnalyticsProviderClientOptions LogAnalyticsClient { get; set; } = null!;
}
