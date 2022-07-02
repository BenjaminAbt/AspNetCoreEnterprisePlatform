using System;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Logging;

public static partial class SecurityPortalLogging
{
    public static void PlatformTenantWorkspaceNotFound(ILogger logger, PlatformTenantId tenantId)
        => PlatformTenantWorkspaceNotFound(logger, tenantId.Value);

    [LoggerMessage(
       EventId = 1,
       EventName = nameof(PlatformTenantWorkspaceNotFound),
       Level = LogLevel.Error,
       Message = "No workspace for platform tenant '{tenantId}' found.")]
    public static partial void PlatformTenantWorkspaceNotFound(ILogger logger, Guid tenantId);

}
