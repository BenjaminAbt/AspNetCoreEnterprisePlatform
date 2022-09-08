// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Migrations;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations;

/// <summary>
/// This class is used to generate the database context during migration time!
/// </summary>
public class TenantsDatabaseSqlServerContextFactory
    : SqlServerMigrationContextFactory<TenantsDatabaseSqlServerContext>, ITenantsDatabaseSqlServerContextFactory
{
    // the current assembly is the migration assembly!
    public override string MigrationAssembly =>
        typeof(TenantsDatabaseSqlServerContextFactory).Assembly.FullName
            ?? throw new Exception("The migration assembly could not be determined!");
}


