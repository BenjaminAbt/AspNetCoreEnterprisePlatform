// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Authorization.Logging;

public static partial class PlatformAuthorizationLog
{
    [LoggerMessage(
       EventId = 1,
       EventName = nameof(AuthorizationSucceeded),
       Level = LogLevel.Trace,
       Message = "Authorization '{requirementName}' for user '{userIdentityId}' was successful.")]
    public static partial void AuthorizationSucceeded(ILogger logger, Guid userIdentityId, string requirementName);

    [LoggerMessage(
       EventId = 2,
       EventName = nameof(AuthorizationFailed),
       Level = LogLevel.Critical,
       Message = "Authorization '{requirementName}' for user '{userIdentityId}' failed.")]
    public static partial void AuthorizationFailed(ILogger logger, Guid userIdentityId, string requirementName);


}
