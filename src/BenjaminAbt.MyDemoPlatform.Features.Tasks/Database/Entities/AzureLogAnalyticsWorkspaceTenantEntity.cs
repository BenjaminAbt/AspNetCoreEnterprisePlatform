using System;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;

public class AzureLogAnalyticsWorkspaceTenantEntity : TenantBaseEntity
{
    public AzureLogAnalyticsWorkspaceTenantEntity() { }

    public AzureLogAnalyticsWorkspaceTenantEntity(
        Guid id, PlatformTenantId tenantId, AzureWorkspaceId workspaceId)
    {
        Id = id;
        TenantId = tenantId;
        WorkspaceId = workspaceId;
    }

    public Guid Id { get; set; }
    public AzureWorkspaceId WorkspaceId { get; set; } = null!;
}
