// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations;

public interface ITenantsDatabaseSqlServerContextFactory
{
    string MigrationAssembly { get; }
}