using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Models;
using Azure;
using Azure.Identity;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using Microsoft.Extensions.Options;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

public class LogAnalyticsProviderClient : ILogAnalyticsProviderClient
{
    private readonly LogsQueryClient _client;

    public LogAnalyticsProviderClient(IOptions<LogAnalyticsProviderClientOptions> optionsAccessor)
    {
        LogAnalyticsProviderClientOptions options = optionsAccessor.Value;

        _client = new LogsQueryClient(new ClientSecretCredential(options.Credentials.TenantId,
            options.Credentials.ClientId, options.Credentials.ClientSecret));
    }

    public Task<Response<LogsQueryResult>> ExecuteQuery(string query, AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        return _client.QueryWorkspaceAsync(azureLogAnalyticsWorkspaceId.ToString("D"), query, new QueryTimeRange(from, to));
    }

    public Task<Response<IReadOnlyList<T>>> ExecuteQuery<T>(string query, AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to)
    {
        return _client.QueryWorkspaceAsync<T>(azureLogAnalyticsWorkspaceId.ToString("D"), query, new QueryTimeRange(from, to));
    }

}
