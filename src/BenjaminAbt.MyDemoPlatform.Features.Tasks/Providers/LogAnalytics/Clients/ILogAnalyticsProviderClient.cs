using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Models;
using Azure;
using Azure.Monitor.Query.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.LogAnalytics.Clients;

public interface ILogAnalyticsProviderClient
{
    Task<Response<LogsQueryResult>> ExecuteQuery(string query, AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to);
    public Task<Response<IReadOnlyList<T>>> ExecuteQuery<T>(string query, AzureWorkspaceId azureLogAnalyticsWorkspaceId, DateTimeOffset from, DateTimeOffset to);
}
