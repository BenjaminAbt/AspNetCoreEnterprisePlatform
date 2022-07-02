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

public class GetAzureLogAnalyticsPotentialMaliciousEventsTrafficThreatsQueryHandler : IQueryHandler<GetPotentialMaliciousEventsTrafficThreatsQuery, ResultSeries<PotentialMaliciousEventsTrafficThreat>?>
{
    private readonly ILogger<GetAzureLogAnalyticsPotentialMaliciousEventsTrafficThreatsQueryHandler> _logger;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly AzureLogAnalyticsDataProvider _logAnalyticsRepository;

    public GetAzureLogAnalyticsPotentialMaliciousEventsTrafficThreatsQueryHandler(
        ILogger<GetAzureLogAnalyticsPotentialMaliciousEventsTrafficThreatsQueryHandler> logger,
        IEventDispatcher eventDispatcher,
        AzureLogAnalyticsDataProvider logAnalyticsRepository)
    {
        _logger = logger;
        _eventDispatcher = eventDispatcher;
        _logAnalyticsRepository = logAnalyticsRepository;
    }

    public async Task<ResultSeries<PotentialMaliciousEventsTrafficThreat>?> Handle(GetPotentialMaliciousEventsTrafficThreatsQuery request, CancellationToken cancellationToken)
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
        ResultSeries<PotentialMaliciousEventsTrafficThreat> stats
            = await _logAnalyticsRepository.GetPotentialMaliciousEventsTrafficThreats(workspaceId, from, to);

        return stats;
    }
}
