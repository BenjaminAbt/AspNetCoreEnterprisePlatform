using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Logging;
public static partial class ControllerLoggerMessages
{
    [LoggerMessage
        (EventId = 1,
        EventName = nameof(ForbiddenTenantAccess),
        Level = LogLevel.Critical,
        Message = "Request access to {actionName} denied. Forbidden tenant access.")]
    public static partial void ForbiddenTenantAccess(ILogger log, [CallerMemberName] string actionName = "");
}
