// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
