using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Monitoring;

public static class PlatformMonitoringRegistration
{
    public static IServiceCollection AddPlatformMonitoring(this IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry();
        services.AddSingleton<ITelemetryInitializer, HttpRequestUserInformationTelemetryInitializer>();

        return services;
    }
}
