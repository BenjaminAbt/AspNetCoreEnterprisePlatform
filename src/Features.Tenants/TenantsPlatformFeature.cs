// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Engine;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Sqlite;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;
public class TenantsPlatformFeature : MyDemoPlatformPlatformFeature<TenantsPlatformFeatureOptions>
{
    public TenantsPlatformFeature(IConfigurationSection configurationSection)
        : base(configurationSection.Bind) { }

    public override void Activate(IServiceCollection services)
    {
        // load options
        TenantsPlatformFeatureOptions TenantsPartFeatureOptions = new();
        FeatureOptions.Invoke(TenantsPartFeatureOptions);

        /**
         * SQL Server
         * 

        // validate options
        SqlServerDbContextConfigValidator.Validate(TenantsPartFeatureOptions.Database);

        // register options
        services.AddSingleton(Options.Create(TenantsPartFeatureOptions));

        // register database
        services.AddPlatformSqlServerContext<ITenantsDbContext, TenantsDatabaseSqlServerContext>(
            TenantsPartFeatureOptions.Database);
        **/

        services.AddDbContext<TenantsDatabaseSqliteContext>(o =>
        {
            o.UseSqlite("Data Source=myplatform.tenants.sqlite", options =>
            {
                options.MigrationsAssembly("BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations");
            });
        });
        services.AddDbContext<ITenantsDbContext, TenantsDatabaseSqliteContext>(o =>
        {

            o.UseSqlite("Data Source=myplatform.tenants.sqlite", options =>
            {
                options.MigrationsAssembly("BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Migrations");
            });
        });


        // register repositories
        services.AddScoped<TenantsRepository>();
        services.AddScoped<TenantUserAccountAssociationRepository>();
        services.AddScoped<UserAccountsRepository>();

        // register engine
        TenantsEngineRegistration.Register(services);
    }


}

public static class TenantsEngineRegistration
{
    public static void Register(IServiceCollection services)
    {

        // Queries
        services.AddEngineQuery<
            TenantUsersGetQuery,
            List<UserInfoModel>,
            TenantUsersGetQueryHandler>();

        // Commands
        services.AddEngineCommand<
            TenantAddCommand,
            PlatformTenantId,
            TenantAddCommandHandler>();

        services.AddEngineCommand<
            TenantUserAddCommand,
            PlatformUserId,
            TenantUserAddCommandHandler>();
    }
}

