using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

public static class LogAnalyticsHelpers
{
    public static class Time
    {
        public static string CalculateGrain(DateTimeOffset from, DateTimeOffset to)
        {
            return "30m";
        }
    }
}
