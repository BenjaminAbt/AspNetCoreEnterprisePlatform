using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.QueryHandlers;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;
using BenjaminAbt.MyDemoPlatform.Models;
using BenjaminAbt.MyDemoPlatform.Providers.MicrosoftSecurityCenterProvider.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal;

public class SecurityPortalPlatformFeature : MyDemoPlatformPlatformFeature<SecurityPortalPlatformFeatureOptions>
{
    public SecurityPortalPlatformFeature(IConfigurationSection configurationSection)
        : base(configurationSection.Bind) { }

    public override void Activate(IServiceCollection services)
    {
        // load options
        SecurityPortalPlatformFeatureOptions SecurityPortalPartFeatureOptions = new();
        FeatureOptions.Invoke(SecurityPortalPartFeatureOptions);
        LogAnalyticsProviderClientOptions logProviderOptions = SecurityPortalPartFeatureOptions.LogAnalyticsClient;

        // validate options
        SqlServerDbContextConfigValidator.Validate(SecurityPortalPartFeatureOptions.Database);

        // register options
        services.AddSingleton(Options.Create(SecurityPortalPartFeatureOptions));
        services.AddSingleton(Options.Create(logProviderOptions));

        // register database
        services.AddPlatformSqlServerContext<ISecurityPortalDbContext, SecurityPortalDatabaseSqlServerContext>(
                      SecurityPortalPartFeatureOptions.Database);


        // register repositories
        services.AddScoped<AzureLogAnalyticsWorkspaceTenantRepository>();

        // engine
        services.AddEngineQuery<
            GetAzureExposureCurrentScoreQuery,
            TimeScorePoint?,
            GetDemoDataAzureExposureCurrentScoreQueryHandler>();
        services.AddEngineQuery<
            GetAzureExposureOvertimeScoreQuery,
            TimeScoreSeries?,
            GetDemoDataAzureExposureOvertimeScoreQueryHandler>();

        services.AddEngineQuery<
            GetAzureSecurityCurrentScoreQuery,
            TimeScorePoint?,
            GetDemoDataAzureSecurityCurrentScoreQueryHandler>();
        services.AddEngineQuery<
            GetAzureSecurityOvertimeScoreQuery,
            TimeScoreSeries?,
            GetDemoDataAzureSecurityOvertimeScoreQueryHandler>();

        services.AddEngineQuery<
            GetMicrosoftOfficeComplianceCurrentScoreQuery,
            TimeScorePoint?,
            GetDemoDataMicrosoftOfficeComplianceCurrentScoreQueryHandler>();

        services.AddEngineQuery<
            GetAzureLogAnalyticsWorkspaceStatsQuery,
            AzureLogAnalyticsWorkspaceStats?,
            GetAzureLogAnalyticsWorkspaceStatsQueryHandler>();

        services.AddEngineQuery<
            GetAzureSignInIdentityBruteForceStatsQuery,
            ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats>?,
            GetAzureLogAnalyticsAzureSignInBruteForceAttackStatsQueryHandler>();
        services.AddEngineQuery<
            GetAzureSignInLocationStatsQuery,
            ResultSeries<AzureSignInLocationStats>?,
            GetAzureLogAnalyticsAzureSignInLocationStatsQueryHandler>();
        services.AddEngineQuery<
            GetAzureSignInPasswordSprayAttackStatsQuery,
            ResultSeries<AzureSignInPasswordSprayAttackStats>?,
            GetAzureLogAnalyticsAzureSignInPasswordSprayAttackStatsQueryHandler>();

        services.AddEngineQuery<
            GetMicrosoftIdentityRiskLevelStatsSeriesQuery,
            ResultSeries<MicrosoftIdentityRiskLevelStats>?,
            GetAzureLogAnalyticsMicrosoftIdentityUsersRiskStateStatsQueryHandler>();
        services.AddEngineQuery<
            GetMicrosoftIdentityRiskyIdentitiesQuery,
            ResultSeries<MicrosoftIdentityRiskyIdentityItem>?,
            GetAzureLogAnalyticsMicrosoftIdentityRiskyIdentitiesQueryHandler>();

        services.AddEngineQuery<
            GetDeviceComplicanceOperatingSystemStateStatsResultQuery,
            ResultSeries<DeviceComplicanceOperatingSystemStateStats>?,
            GetAzureLogAnalyticsDeviceComplicanceOperatingSystemStateStatsResultQueryHandler>();

        services.AddEngineQuery<
            GetPotentialMaliciousTrafficStatsQuery,
            ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>?,
            GetAzureLogAnalyticsPotentialMaliciousTrafficStatsQueryHandler>();
        services.AddEngineQuery<
            GetPotentialMaliciousEventsTrafficThreatsQuery,
            ResultSeries<PotentialMaliciousEventsTrafficThreat>?,
            GetAzureLogAnalyticsPotentialMaliciousEventsTrafficThreatsQueryHandler>();

        services.AddEngineQuery<
            GetAzureAuditLogsTopRequestedRolesStatsQuery,
            ResultSeries<AzureAuditLogsTopRequestedRoleCountEntry>?,
            GetAzureLogAnalyticsAuditLogsTopRequestedRolesStatsQueryHandler>();

        services.AddEngineQuery<
            GetCloudUsageStorageUserUploadedBytesStatsQuery,
            ResultSeries<CloudUsageStorageUserUploadedBytesStatsEntry>?,
            GetAzureLogAnalyticsCloudUsageStorageUserUploadedBytesStatsQueryHandler>();
        services.AddEngineQuery<
            GetCloudUsageStorageUserDownloadedBytesStatsQuery,
            ResultSeries<CloudUsageStorageUserDownloadedBytesStatsEntry>?,
            GetAzureLogAnalyticsCloudUsageStorageUserDownloadedBytesStatsQueryHandler>();

        services.AddEngineQuery<
            GetAzureLogAnalyticsWorkspaceIdByTenantIdQuery,
            AzureWorkspaceId?,
            GetAzureLogAnalyticsWorkspaceIdByTenantIdQueryHandler>();

        // register services
        services.AddMicrosoftSecurityCenterApiClient();

        // register providers
        services.AddSingleton<ILogAnalyticsProviderClient, LogAnalyticsProviderClient>();
        services.AddScoped<AzureLogAnalyticsDataProvider>();
    }
}



public static partial class SecurityPortalFeatureLogs
{
    [LoggerMessage(
        EventId = 1,
        EventName = nameof(LogConnectionString),
        Level = LogLevel.Trace,
        Message = "Connection String for {contextName}: {connectionString}")]
    public static partial void LogConnectionString(ILogger logger, string contextName, string connectionString);
}
