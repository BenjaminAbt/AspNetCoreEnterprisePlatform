using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureLogAnalyticsWorkspaceStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureLogAnalyticsWorkspaceStatsModelProjection()
    {
        CreateMap<AzureLogAnalyticsWorkspaceStats, SecurityPortalAzureLogAnalyticsWorkspaceStatsModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Events,
                opt => opt.MapFrom(e => e.Events))

            .ForMember(p => p.SecurityAlerts,
                opt => opt.MapFrom(e => e.SecurityAlerts))

            .ForMember(p => p.SecurityIncidents,
                opt => opt.MapFrom(e => e.SecurityIncidents))

            .ForMember(p => p.SecurityIncidentsTier1Closed,
                opt => opt.MapFrom(e => e.SecurityIncidentsTier1Closed))

            .ForMember(p => p.SecurityIncidentsTier2Closed,
                opt => opt.MapFrom(e => e.SecurityIncidentsTier2Closed))

            .ForMember(p => p.SecurityIncidentsTier3Open,
                opt => opt.MapFrom(e => e.SecurityIncidentsTier3Open));
    }
}
