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

public class GetAzureLogAnalyticsMicrosoftIdentityRiskyIdentitiesQueryHandler : IQueryHandler<GetMicrosoftIdentityRiskyIdentitiesQuery, ResultSeries<MicrosoftIdentityRiskyIdentityItem>?>
{
    private readonly ILogger<GetAzureLogAnalyticsMicrosoftIdentityRiskyIdentitiesQueryHandler> _logger;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly AzureLogAnalyticsDataProvider _logAnalyticsRepository;

    public GetAzureLogAnalyticsMicrosoftIdentityRiskyIdentitiesQueryHandler(
        ILogger<GetAzureLogAnalyticsMicrosoftIdentityRiskyIdentitiesQueryHandler> logger,
        IEventDispatcher eventDispatcher,
        AzureLogAnalyticsDataProvider logAnalyticsRepository)
    {
        _logger = logger;
        _eventDispatcher = eventDispatcher;
        _logAnalyticsRepository = logAnalyticsRepository;
    }

    public async Task<ResultSeries<MicrosoftIdentityRiskyIdentityItem>?> Handle(GetMicrosoftIdentityRiskyIdentitiesQuery request, CancellationToken cancellationToken)
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
        ResultSeries<MicrosoftIdentityRiskyIdentityItem> stats
            = await _logAnalyticsRepository.GetIdentityLatestRiskyIdenties(workspaceId, from, to);

        return stats;
    }
}
