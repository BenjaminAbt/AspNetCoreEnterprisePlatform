using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.Models;
using Azure;
using Azure.Monitor.Query.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

public class AzureLogAnalyticsDataProvider
{
    private readonly ILogAnalyticsProviderClient _logAnalyticsProviderClient;

    public AzureLogAnalyticsDataProvider(ILogAnalyticsProviderClient client)
    {
        _logAnalyticsProviderClient = client;
    }

    public async Task<long> GetTotalEventsTimeseriesStats
     (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetTotalEventsTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }
    public async Task<long> GetSecurityAlertTimeseriesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetSecurityAlertTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }

    public async Task<long> GetSecurityIncidentsTimeseriesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetSecurityIncidentsTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }

    public async Task<long> GetSecurityIncidentsTier1ClosedTimeseriesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetSecurityIncidentsTier1ClosedTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }

    public async Task<long> GetSecurityIncidentsTier2ClosedTimeseriesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetSecurityIncidentsTier2ClosedTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }

    public async Task<long> GetSecurityIncidentsTier3OpenStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> result = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetSecurityIncidentsTier3OpenTimeseriesQuery(from, to),
               azureLogAnalyticsWorkspaceId, from, to);

        return ParseTimeSeriesTrendResponse(result);
    }

    public async Task<ResultSeries<DeviceComplicanceOperatingSystemStateStats>> GetDeviceCompliantStateStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetDeviceCompliantStateStatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<DeviceComplicanceOperatingSystemStateStats> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string osName = row.GetString("OS");
            long? compliantCount = row.GetInt64("Compliant");
            long? notCompliantCount = row.GetInt64("NotCompliant");
            long? notEvaluatedCount = row.GetInt64("NotEvaluated");

            if (!string.IsNullOrEmpty(osName) &&
                compliantCount.HasValue &&
                notCompliantCount.HasValue &&
                notEvaluatedCount.HasValue)
            {
                items.Add(new(osName,
                    compliantCount.Value,
                    notCompliantCount.Value,
                    notEvaluatedCount.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<MicrosoftIdentityRiskLevelStats>> GetIdentityRiskStateStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetIdentityRiskStateStatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<MicrosoftIdentityRiskLevelStats> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string riskLevel = row.GetString("RiskLevel");
            long? count = row.GetInt64("Count");

            if (!string.IsNullOrEmpty(riskLevel) && count.HasValue)
            {
                items.Add(new(riskLevel, count.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<MicrosoftIdentityRiskyIdentityItem>> GetIdentityLatestRiskyIdenties
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetIdentityLatestRiskyIdentiesQuery(5),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<MicrosoftIdentityRiskyIdentityItem> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            DateTimeOffset? mostRecentValue = row.GetDateTimeOffset("MostRecent");
            string identityValue = row.GetString("Identity");
            string riskLevelValue = row.GetString("RiskLevel");

            if (mostRecentValue.HasValue &&
                !string.IsNullOrEmpty(identityValue) &&
                !string.IsNullOrEmpty(riskLevelValue))
            {
                items.Add(new(mostRecentValue.Value, identityValue, riskLevelValue));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<AzureSignInPasswordSprayAttackStats>> GetAzureSignInPasswordSprayAttackStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetAzureSignInPasswordSprayAttacksQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<AzureSignInPasswordSprayAttackStats> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string locationValue = row.GetString("Location");
            string ipAddressValue = row.GetString("IPAddress");
            DateTimeOffset? startDateValue = row.GetDateTimeOffset("Start");
            DateTimeOffset? endDateValue = row.GetDateTimeOffset("End");
            string[] usersValue = row.GetStringFromJsonArray("Users");

            if (!string.IsNullOrEmpty(locationValue) &&
                !string.IsNullOrEmpty(ipAddressValue) &&
              startDateValue.HasValue &&
              endDateValue.HasValue)
            {
                items.Add(new(locationValue, ipAddressValue,
                startDateValue.Value, endDateValue.Value, usersValue));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<AzureSignInLocationStats>> GetAzureSignInLocationStatsSeries
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetAzureSignInLocationStatsSeriesQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<AzureSignInLocationStats> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string cityValue = row.GetString("City");
            string countryCodeValue = row.GetString("Country");
            double? latitudeValue = row.GetDouble("Latitude");
            double? longitudeValue = row.GetDouble("Longitude");
            long? succeededCountValue = row.GetInt64("SucceededCount");
            long? failedCountValue = row.GetInt64("FailedCount");
            long? totalCountValue = row.GetInt64("TotalCount");

            if (!string.IsNullOrEmpty(cityValue) &&
                !string.IsNullOrEmpty(countryCodeValue) &&
                latitudeValue.HasValue &&
                longitudeValue.HasValue &&
                succeededCountValue.HasValue &&
                failedCountValue.HasValue &&
                totalCountValue.HasValue)
            {
                items.Add(new(cityValue, countryCodeValue,
                      latitudeValue.Value,
                      longitudeValue.Value,
                      succeededCountValue.Value,
                      failedCountValue.Value,
                      totalCountValue.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items.ToArray());
    }

    public async Task<ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats>> GetAzureSignInIdentityBruteForceAttackStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetAzureSignInIdentityBruteForceAttacksQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<AzureSignInIdentityBruteForceStatsIdentityStats> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string identityValue = row.GetString("Identity");
            DateTimeOffset? startDateValue = row.GetDateTimeOffset("Start");
            DateTimeOffset? endDateValue = row.GetDateTimeOffset("End");
            long? ipCountValue = row.GetInt64("IPs");
            long? countryCountValue = row.GetInt64("Countries");

            if (!string.IsNullOrEmpty(identityValue) &&
                startDateValue.HasValue &&
                endDateValue.HasValue &&
                ipCountValue.HasValue &&
                countryCountValue.HasValue
                )
            {
                items.Add(new(
                     identityValue,
                     startDateValue.Value,
                     endDateValue.Value,
                     ipCountValue.Value,
                     countryCountValue.Value
                     ));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>> GetPotentialMaliciousEventsTrafficStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetPotentialMaliciousEventsTrafficStatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<PotentialMaliciousEventsTrafficLocationsEntry> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string trafficDirectionValue = row.GetString("TrafficDirection");
            double? latValue = row.GetDouble("Latitude");
            double? lonValue = row.GetDouble("Longitude");
            string countryNameValue = row.GetString("Country");
            long? countValue = row.GetInt64("count_");

            if (!string.IsNullOrEmpty(trafficDirectionValue) &&
                latValue.HasValue &&
                lonValue.HasValue &&
                !string.IsNullOrEmpty(countryNameValue) &&
                countValue.HasValue)
            {
                items.Add(new(trafficDirectionValue,
                    latValue.Value, lonValue.Value,
                    countryNameValue, countValue.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<PotentialMaliciousEventsTrafficThreat>> GetPotentialMaliciousEventsTrafficThreats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetPotentialMaliciousEventsTrafficThreatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<PotentialMaliciousEventsTrafficThreat> items = new();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            DateTimeOffset? onValue = row.GetDateTimeOffset("TimeGenerated");
            string confidenceValue = row.GetString("Confidence");
            string trafficDirectionValue = row.GetString("TrafficDirection");
            string countryNameValue = row.GetString("Country");
            string indicatorThreatTypeValue = row.GetString("IndicatorThreatType");
            string maliciousIPValue = row.GetString("MaliciousIP");
            string nameValue = row.GetString("Name");

            if (onValue.HasValue &&
                  !string.IsNullOrEmpty(confidenceValue) &&
                !string.IsNullOrEmpty(trafficDirectionValue) &&
                !string.IsNullOrEmpty(countryNameValue) &&
                !string.IsNullOrEmpty(indicatorThreatTypeValue) &&
                !string.IsNullOrEmpty(maliciousIPValue) &&
                !string.IsNullOrEmpty(nameValue))
            {

                items.Add(new(onValue.Value,
                    confidenceValue,
                    trafficDirectionValue,
                    countryNameValue,
                    indicatorThreatTypeValue,
                    maliciousIPValue,
                    nameValue));
            }

        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<AzureAuditLogsTopRequestedRoleCountEntry>> GetAuditLogsTopRequestedRolesCountStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetAuditLogsTopRequestedRolesCountQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<AzureAuditLogsTopRequestedRoleCountEntry> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string rolesValue = row.GetString("Roles");
            long? countValue = row.GetInt64("RolesCount");

            if (!string.IsNullOrEmpty(rolesValue) && countValue.HasValue)
            {
                items.Add(new(rolesValue, countValue.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<CloudUsageStorageUserUploadedBytesStatsEntry>> GetCloudUsageStorageUserUploadedBytesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetCloudUsageStorageUserUploadedBytesStatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<CloudUsageStorageUserUploadedBytesStatsEntry> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string userAppValue = row.GetString("UserApp");
            long? uploadedValue = row.GetInt64("Uploaded");

            if (!string.IsNullOrEmpty(userAppValue) && uploadedValue.HasValue)
            {
                items.Add(new(userAppValue, uploadedValue.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    public async Task<ResultSeries<CloudUsageStorageUserDownloadedBytesStatsEntry>> GetCloudUsageStorageUserDownloadedBytesStats
        (AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        Response<LogsQueryResult> response = await _logAnalyticsProviderClient.ExecuteQuery(
               LogAnalyticsQueries.GetCloudUsageStorageUserDownloadedBytesStatsQuery(),
               azureLogAnalyticsWorkspaceId, from, to);

        LogsTable table = GetTable(response);

        List<CloudUsageStorageUserDownloadedBytesStatsEntry> items = new(table.Rows.Count);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            LogsTableRow row = table.Rows[i];

            string userAppValue = row.GetString("UserApp");
            long? downloadedValue = row.GetInt64("Downloaded");

            if (!string.IsNullOrEmpty(userAppValue) && downloadedValue.HasValue)
            {
                items.Add(new(userAppValue, downloadedValue.Value));
            }
        }

        return new(DateTimeOffset.UtcNow, items);
    }

    private static LogsTable GetTable(Response<LogsQueryResult> response) => response.Value.Table;

    private static long ParseTimeSeriesTrendResponse(Response<LogsQueryResult> response)
    {
        LogsTable table = GetTable(response);

        // result must have just one row
        if (table.Rows.Count != 1)
        {
            // something wrong
            return 0;
        }

        LogsTableRow row = table.Rows[0];

        long? totalEntryCount = row.GetInt64("count_");

        return totalEntryCount.GetValueOrDefault(defaultValue: 0);

        // keep that series parse for now

        //string? trendValueArray = row.GetString("Trend");
        //string? timeseriesValueArray = row.GetString("TimeGenerated");

        //// transform value fields
        //if (totalEntryCount.HasValue && trendValueArray is not null && timeseriesValueArray is not null)
        //{
        //    // de serialize string fields
        //    int[] trends = JsonSerializer.Deserialize<int[]>(trendValueArray);


        //    //DateTimeOffset[] timestamps = JsonSerializer.Deserialize<DateTimeOffset[]>(timeseriesValueArray);

        //    //// transform fields
        //    //if (trends.Length == timestamps.Length)
        //    //{
        //    //    TimeCountPoint[] stats = new TimeCountPoint[trends.Length];

        //    //    for (int i = 0; i < trends.Length; i++)
        //    //    {
        //    //        // read field
        //    //        int eventTrendCount = trends[i];
        //    //        DateTimeOffset eventTimestamp = timestamps[i];

        //    //        stats[i] = new AzureLogAnalyticsWorkspaceEventTimestampCount(eventTimestamp, eventTrendCount);
        //    //    }

        //    //    return new TimeCountPoint(totalEntryCount.Value, stats);
        //    //}
        //}

        //return null;
    }

}
public static class LogRowExtensions
{
    public static string[] GetStringFromJsonArray(this LogsTableRow row, string columnName)
    {
        string? stringArrayValue = row.GetString(columnName);
        if (stringArrayValue is null) return new string[0];

        string[]? stringArray = JsonSerializer.Deserialize<string[]>(stringArrayValue);
        if (stringArray is null) return new string[0];

        return stringArray;
    }
}
