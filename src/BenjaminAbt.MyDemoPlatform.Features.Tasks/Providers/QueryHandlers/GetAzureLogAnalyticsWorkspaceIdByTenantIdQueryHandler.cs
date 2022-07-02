using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.QueryHandlers;

public class GetAzureLogAnalyticsWorkspaceIdByTenantIdQueryHandler
    : IQueryHandler<GetAzureLogAnalyticsWorkspaceIdByTenantIdQuery, AzureWorkspaceId?>
{
    private readonly AzureLogAnalyticsWorkspaceTenantRepository _azureLogAnalyticsWorkspaceTenantRepository;

    public GetAzureLogAnalyticsWorkspaceIdByTenantIdQueryHandler(
        AzureLogAnalyticsWorkspaceTenantRepository azureLogAnalyticsWorkspaceTenantRepository)
    {
        _azureLogAnalyticsWorkspaceTenantRepository = azureLogAnalyticsWorkspaceTenantRepository;
    }

    public Task<AzureWorkspaceId?> Handle(GetAzureLogAnalyticsWorkspaceIdByTenantIdQuery request, CancellationToken cancellationToken)
        => _azureLogAnalyticsWorkspaceTenantRepository.GetWorkspaceIdByTenant(request.TenantId);
}
