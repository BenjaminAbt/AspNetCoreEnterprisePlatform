// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Logging;

public static partial class SqlServerLogging
{
    [LoggerMessage(
        EventId = 1,
        EventName = nameof(LogConnectionString),
        Level = LogLevel.Trace,
        Message = "Connection String for {contextName}: {connectionString}")]
    public static partial void LogConnectionString(ILogger logger, string contextName, string connectionString);

    [LoggerMessage(
        EventId = 2,
        EventName = nameof(LoggerFactoryRegistered),
        Level = LogLevel.Trace,
        Message = "Logging Facctory for {contextName} registered.")]
    public static partial void LoggerFactoryRegistered(ILogger logger, string contextName);

    [LoggerMessage(
        EventId = 3,
        EventName = nameof(LoggerFactoryNotRegistered),
        Level = LogLevel.Trace,
        Message = "Logging Facctory for {contextName} not registered.")]
    public static partial void LoggerFactoryNotRegistered(ILogger logger, string contextName);
}
