// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Configuration;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public static class SqlServerDbContextConfigValidator
{
    public static void Validate<T>(T? databaseConfig) where T : SqlServerDbContextConfig
    {
        MissingConfigurationException.ThrowIfNull(databaseConfig, "Database");
        MissingConfigurationException.ThrowIfNullOrEmpty(databaseConfig.ServerHostname, "Database ServerHostname");
        MissingConfigurationException.ThrowIfNullOrEmpty(databaseConfig.DatabaseName, "Database DatabaseName");
        MissingConfigurationException.ThrowIfNullOrEmpty(databaseConfig.ConnectionStringTemplate, "Database ConnectionStringTemplate");
    }
}
