using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;

public record class GetAzureLogAnalyticsWorkspaceIdByTenantIdQuery(PlatformTenantId TenantId) : IQuery<AzureWorkspaceId?>;
