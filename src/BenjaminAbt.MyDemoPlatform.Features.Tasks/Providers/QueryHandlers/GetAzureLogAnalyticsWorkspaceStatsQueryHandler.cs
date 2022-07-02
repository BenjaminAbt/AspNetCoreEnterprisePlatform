using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Logging;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.QueryHandlers;

public class GetAzureLogAnalyticsWorkspaceStatsQueryHandler : IQueryHandler<GetAzureLogAnalyticsWorkspaceStatsQuery, AzureLogAnalyticsWorkspaceStats?>
{
    private readonly ILogger<GetAzureLogAnalyticsWorkspaceStatsQueryHandler> _logger;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly AzureLogAnalyticsDataProvider _logAnalyticsRepository;

    public GetAzureLogAnalyticsWorkspaceStatsQueryHandler(
        ILogger<GetAzureLogAnalyticsWorkspaceStatsQueryHandler> logger,
        IEventDispatcher eventDispatcher,
        AzureLogAnalyticsDataProvider logAnalyticsRepository)
    {
        _logger = logger;
        _eventDispatcher = eventDispatcher;
        _logAnalyticsRepository = logAnalyticsRepository;
    }

    public async Task<AzureLogAnalyticsWorkspaceStats?> Handle(GetAzureLogAnalyticsWorkspaceStatsQuery request, CancellationToken cancellationToken)
    {
        // prepare
        DateTimeOffset from = request.From;
        DateTimeOffset to = request.To;
        PlatformTenantId tenantId = request.TenantId;

        // get workspace id
        AzureWorkspaceId? workspaceId = await _eventDispatcher.Get(
            new GetAzureLogAnalyticsWorkspaceIdByTenantIdQuery(tenantId), cancellationToken);

        if (workspaceId is null)
        {
            SecurityPortalLogging.PlatformTenantWorkspaceNotFound(_logger, tenantId);
            return null;
        }

        // execute

        Task<long> totalEventsStatsTask
            = _logAnalyticsRepository.GetTotalEventsTimeseriesStats(workspaceId, from, to);

        Task<long> securityAlertStatsTask
            = _logAnalyticsRepository.GetSecurityAlertTimeseriesStats(workspaceId, from, to);

        Task<long> securityIncidentStatsTask
            = _logAnalyticsRepository.GetSecurityIncidentsTimeseriesStats(workspaceId, from, to);

        Task<long> securityIncidentTier1ClosedStatsTask
            = _logAnalyticsRepository.GetSecurityIncidentsTier1ClosedTimeseriesStats(workspaceId, from, to);

        Task<long> securityIncidentTier2ClosedStatsTask
            = _logAnalyticsRepository.GetSecurityIncidentsTier2ClosedTimeseriesStats(workspaceId, from, to);

        Task<long> securityIncidentTier3OpenStatsTask
            = _logAnalyticsRepository.GetSecurityIncidentsTier3OpenStats(workspaceId, from, to);

        // this executes the tasks parallel!
        await Task.WhenAll(
            totalEventsStatsTask,
            securityAlertStatsTask,
            securityIncidentStatsTask,
            securityIncidentTier1ClosedStatsTask,
            securityIncidentTier2ClosedStatsTask,
            securityIncidentTier3OpenStatsTask);

        long totalEventsStats = await totalEventsStatsTask;
        long securityAlertStats = await securityAlertStatsTask;
        long securityIncidentStats = await securityIncidentStatsTask;
        long securityIncidentTier1ClosedStats = await securityIncidentTier1ClosedStatsTask;
        long securityIncidentTier2ClosedStats = await securityIncidentTier2ClosedStatsTask;
        long securityIncidentTier3OpenStats = await securityIncidentTier3OpenStatsTask;

        // calc
        return new(DateTimeOffset.UtcNow, totalEventsStats, securityAlertStats, securityIncidentStats,
            securityIncidentTier1ClosedStats, securityIncidentTier2ClosedStats, securityIncidentTier3OpenStats);
    }
}
