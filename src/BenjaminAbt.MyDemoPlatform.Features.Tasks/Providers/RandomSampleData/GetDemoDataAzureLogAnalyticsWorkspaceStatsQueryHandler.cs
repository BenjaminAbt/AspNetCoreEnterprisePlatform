using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataAzureLogAnalyticsWorkspaceStatsQueryHandler
    : IQueryHandler<GetAzureLogAnalyticsWorkspaceStatsQuery, AzureLogAnalyticsWorkspaceStats?>
{
    public Task<AzureLogAnalyticsWorkspaceStats?> Handle(GetAzureLogAnalyticsWorkspaceStatsQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        long eventStats = Random.Shared.Next(10_000);
        long securityAlertStats = Random.Shared.Next(250);
        long securityIncidentStats = Random.Shared.Next(100);
        long securityIncidentStatsTier1Closed = Random.Shared.Next(75);
        long securityIncidentStatsTier2Closed = Random.Shared.Next(50);
        long securityIncidentStatsTier3Open = Random.Shared.Next(50);

        AzureLogAnalyticsWorkspaceStats result = new(now, eventStats,
            securityAlertStats,
            securityIncidentStats,
            securityIncidentStatsTier1Closed,
            securityIncidentStatsTier2Closed,
            securityIncidentStatsTier3Open);

        return Task.FromResult<AzureLogAnalyticsWorkspaceStats?>(result);
    }
}
