using System;
using System.Linq.Expressions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Queries;

public static class AzureLogAnalyticsWorkspaceTenantQuery
{
    public static Expression<Func<AzureLogAnalyticsWorkspaceTenantEntity, bool>> WithTenantId(PlatformTenantId tenantId)
        => e => e.TenantId == tenantId;
}
