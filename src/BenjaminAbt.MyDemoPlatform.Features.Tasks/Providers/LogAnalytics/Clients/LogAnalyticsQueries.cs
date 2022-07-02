using System;
using BenjaminAbt.MyDemoPlatform.Common;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

public static class LogAnalyticsQueries
{

    public static string GetCloudUsageStorageUserUploadedBytesStatsQuery()
    {
        string query = @"
McasShadowItReporting
| where AppCategory == ""Cloud storage""
| summarize Uploaded = sum(UploadedBytes) by User = EnrichedUserName, AppName
| extend UserApp = strcat(split(User, '@')[0], ' - ', AppName)
| project UserApp, Uploaded";
        return query;
    }

    public static string GetCloudUsageStorageUserDownloadedBytesStatsQuery()
    {
        string query = @"
McasShadowItReporting
| where AppCategory == ""Cloud storage""
| summarize Downloaded = sum(DownloadedBytes) by User = EnrichedUserName, AppName
| extend UserApp = strcat(split(User, '@')[0], ' - ', AppName)
| project UserApp, Downloaded";
        return query;
    }

    public static string GetPotentialMaliciousEventsTrafficStatsQuery()
    {
        string query = @"
union isfuzzy=true
    (W3CIISLog
    | extend TrafficDirection = ""INBOUND_OR_UNKNOWN"", Country=RemoteIPCountry, Latitude=RemoteIPLatitude, Longitude=RemoteIPLongitude),
    (DnsEvents
    | extend TrafficDirection = ""INBOUND_OR_UNKNOWN"", Country = RemoteIPCountry, Latitude = RemoteIPLatitude, Longitude = RemoteIPLongitude),
    (WindowsFirewall
    | extend TrafficDirection = iff(CommunicationDirection != ""SEND"", ""INBOUND_OR_UNKNOWN"", ""OUTBOUND""), Country = MaliciousIPCountry, Latitude = MaliciousIPLatitude, Longitude = MaliciousIPLongitude),
    (CommonSecurityLog
    | extend TrafficDirection = iff(CommunicationDirection!in (""OUTBOUND"", ""1""), ""INBOUND_OR_UNKNOWN"", ""OUTBOUND""), Country = MaliciousIPCountry, Latitude = MaliciousIPLatitude, Longitude = MaliciousIPLongitude, Confidence = ThreatDescription, Description = ThreatDescription)
| where isnotempty(MaliciousIP) and isnotempty(Country) and isnotempty(Latitude) and isnotempty(Longitude)
| summarize count() by TrafficDirection, Latitude, Longitude, Country
";

        return query;

    }

    public static string GetPotentialMaliciousEventsTrafficThreatsQuery()
    {
        string query = @"
union isfuzzy=true
    (DnsEvents
    | extend TrafficDirection = ""INBOUND_OR_UNKNOWN"", Country= RemoteIPCountry, Latitude = RemoteIPLatitude, Longitude = RemoteIPLongitude),
    (WindowsFirewall
    | extend TrafficDirection = iff(CommunicationDirection != ""SEND"", ""INBOUND_OR_UNKNOWN"", ""OUTBOUND""), Country = MaliciousIPCountry, Latitude = MaliciousIPLatitude, Longitude = MaliciousIPLongitude),
    (CommonSecurityLog
    | extend TrafficDirection = iff(CommunicationDirection!in (""OUTBOUND"", ""1""), ""INBOUND_OR_UNKNOWN"", ""OUTBOUND""), Country = MaliciousIPCountry, Latitude = MaliciousIPLatitude, Longitude = MaliciousIPLongitude, Confidence = ThreatDescription, Description = ThreatDescription)
| where isnotempty(MaliciousIP) and isnotempty(Country) and isnotempty(Latitude) and isnotempty(Longitude)
| top 5 by TimeGenerated
| project TimeGenerated, Confidence, TrafficDirection, Country, IndicatorThreatType, MaliciousIP, Name
";

        return query;

    }


    public static string GetAzureSignInIdentityBruteForceAttacksQuery()
    {
        string query = @"SigninLogs
                            | where ResultType == '50126' or ResultType == '50053'
                            | project Identity, Location, IPAddress, TimeGenerated
                            | summarize Start = min(TimeGenerated), End = max(TimeGenerated), IPs = dcount(IPAddress), Countries = dcount(Location) by Identity
                            | where IPs > 1 and Countries > 1
                            | extend Countries, Start, End
                            | project Identity, Start, End, IPs, Countries";
        return query;

    }

    public static string GetAuditLogsTopRequestedRolesCountQuery()
    {
        string query = @"
AuditLogs
| where OperationName contains ""Add member to role completed(PIM activation)""
| summarize RoleCount = count() by Roles = tostring(TargetResources.[0].displayName)
| top 5 by RoleCount";
        return query;
    }

    public static string GetAzureSignInPasswordSprayAttacksQuery()
    {
        string query = $@"SigninLogs
                            | where ResultType == '50053' or ResultType == '50126'
                            | project Identity, Location, IPAddress, TimeGenerated
                            | summarize Start = min(TimeGenerated), End = max(TimeGenerated), Users = make_set(Identity) by Location, IPAddress
                            | extend UserCount = array_length(Users)
                            | where array_length(Users) > 1
                            | project Location, IPAddress, Start, End, UserCount, Users";
        return query;
    }

    public static string GetAzureSignInLocationStatsSeriesQuery()
    {
        string query = $@"
SigninLogs
| extend City  = tostring(LocationDetails.city)
| extend Country = tostring(LocationDetails.countryOrRegion)
| extend Latitude  = round(todouble(parse_json(tostring(LocationDetails.geoCoordinates)).latitude), 3)
| extend Longitude = round(todouble(parse_json(tostring(LocationDetails.geoCoordinates)).longitude), 3)
| extend Succeeded = case(ResultType == '0', bool(true), bool(false))
| where isnotempty(Latitude) and isnotempty(Longitude)
| summarize
    TotalCount = count(),
    SucceededCount = countif(Succeeded == true),
    FailedCount = countif(Succeeded == false)
    by
    City,
    Country,
    Longitude,
    Latitude
| top 100 by TotalCount";
        return query;
    }

    public static string GetIdentityRiskStateStatsQuery()
    {
        string query = $@"let data = SigninLogs
                        | where RiskState == ```remediated``` or RiskState == ```atRisk```
                        | summarize RiskyBisky = make_set(RiskState), MostRecent = arg_max(TimeGenerated,*) by CorrelationId, Identity
                        | where RiskyBisky !contains ""remediated""
                        | summarize arg_max(MostRecent, *) by Identity
                        | project MostRecent, Identity, RiskyBisky, RiskLevelAggregated;
                                let Low = data
                                | summarize Count = countif(RiskLevelAggregated == ""low"") by RiskLevelAggregated
                        | extend RiskLevel = ""Low"";
                                let Medium = data
                                | summarize Count = countif(RiskLevelAggregated == ""medium"") by RiskLevelAggregated
                        | extend RiskLevel = ""Medium"";
                                let High = data
                                | summarize Count = countif(RiskLevelAggregated == ""high"") by RiskLevelAggregated
                        | extend RiskLevel = ""High"";
                                Low
                                | union Medium, High
                                | project RiskLevel, Count";

        return query;
    }

    public static string GetIdentityLatestRiskyIdentiesQuery(int top)
    {
        string query = $@"
SigninLogs
| where RiskState == ```remediated``` or RiskState == ```atRisk```
| summarize RiskyBisky = make_set(RiskState), MostRecent = arg_max(TimeGenerated,*) by CorrelationId, Identity
| where RiskyBisky !contains ""remediated""
| summarize arg_max(MostRecent, *) by Identity
| project MostRecent, Identity, RiskLevel = RiskLevelAggregated
| top {top} by MostRecent";
        return query;
    }

    public static string GetDeviceCompliantStateStatsQuery()
    {
        string query = $@"IntuneDeviceComplianceOrg
                            | where DeviceName != """"
                            | summarize arg_max(todatetime(TimeGenerated),*) by DeviceName
                            | summarize Compliant = countif(ComplianceState == ""Compliant""), NotCompliant = countif(ComplianceState == ""Not compliant""), NotEvaluated = countif(ComplianceState == ""Not evaluated"") by OS";
        return query;

    }
    public static string GetTotalEventsTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"search *
                            | summarize count_ = count() by TenantId
                            | join kind=inner (search *
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }

    public static string GetAzureSignInLocationStatsQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"search *
                            | summarize count_ = count() by TenantId
                            | join kind=inner (search *
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }

    public static string GetSecurityAlertTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"let newAlerts = SecurityAlert
                         | where Status == ""New""
                         | summarize arg_max(TimeGenerated, *) by SystemAlertId;
                                 newAlerts
                                 | summarize count() by TenantId
                         | join kind = inner(newAlerts
                             | make-series Trend = count() default = 0 on TimeGenerated
                                from datetime({from.ToISO8601()})
                                to datetime({to.ToISO8601()})
                                step {grain}
                                by TenantId)
                             on TenantId";

        return query;
    }

    public static string GetSecurityIncidentsTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"let newIncidents = SecurityIncident
                            | where Status == ""New""
                            | summarize arg_max(TimeGenerated, *) by IncidentName;
                                    newIncidents
                                    | summarize count() by TenantId
                            | join kind = inner(newIncidents
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }

    public static string GetSecurityIncidentsTier1ClosedTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"let newIncidents =  SecurityIncident
                            | where Status == ""New""
                            | summarize arg_max(TimeGenerated,*) by IncidentName;
                            let data = SecurityIncident
                            | join kind=leftsemi newIncidents on IncidentName
                            | summarize arg_max(TimeGenerated,*) by IncidentName
                            | where Status == ""Closed""
                            | where Labels contains ""Playbook"";
                            data
                            | summarize count() by TenantId
                            | join kind=inner (data
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }

    public static string GetSecurityIncidentsTier2ClosedTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"let newIncidents = SecurityIncident
                            | where Status == ""New""
                            | summarize arg_max(TimeGenerated,*) by IncidentName;
                            let data = SecurityIncident
                            | join kind=leftsemi newIncidents on IncidentName
                            | summarize arg_max(TimeGenerated,*) by IncidentName
                            | where Status == ""Closed""
                            | where Labels !contains ""Playbook"";
                            data
                            | summarize count() by TenantId
                            | join kind=inner (data
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }

    public static string GetSecurityIncidentsTier3OpenTimeseriesQuery(DateTimeOffset from, DateTimeOffset to)
    {
        string grain = LogAnalyticsHelpers.Time.CalculateGrain(from, to);
        string query = $@"let newIncidents = SecurityIncident
                            | where Status == ""New""
                            | summarize arg_max(TimeGenerated,*) by IncidentName;
                            let data = SecurityIncident
                            | join kind=leftsemi newIncidents on IncidentName
                            | summarize arg_max(TimeGenerated,*) by IncidentName
                            | where Status == ""Active"";
                            data
                            | summarize count() by TenantId
                            | join kind=inner (data
                                | make-series Trend = count() default = 0 on TimeGenerated
                                    from datetime({from.ToISO8601()})
                                    to datetime({to.ToISO8601()})
                                    step {grain}
                                    by TenantId)
                                on TenantId";

        return query;
    }
}
