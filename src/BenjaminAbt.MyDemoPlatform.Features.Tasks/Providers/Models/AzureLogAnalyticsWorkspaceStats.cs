using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct AzureLogAnalyticsWorkspaceStats(
    DateTimeOffset On,
    long Events,
    long SecurityAlerts,
    long SecurityIncidents,
    long SecurityIncidentsTier1Closed,
    long SecurityIncidentsTier2Closed,
    long SecurityIncidentsTier3Open);
