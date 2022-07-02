using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalPotentialMaliciousEventsTrafficThreatModelProjection : AutoMapper.Profile
{
    public SecurityPortalPotentialMaliciousEventsTrafficThreatModelProjection()
    {
        CreateMap<PotentialMaliciousEventsTrafficThreat, SecurityPortalPotentialMaliciousEventsTrafficThreatModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Confidence,
                opt => opt.MapFrom(e => e.Confidence))

            .ForMember(p => p.TrafficDirection,
                opt => opt.MapFrom(e => e.TrafficDirection))

            .ForMember(p => p.CountryName,
                opt => opt.MapFrom(e => e.CountryName))

            .ForMember(p => p.IndicatorThreatType,
                opt => opt.MapFrom(e => e.IndicatorThreatType))

            .ForMember(p => p.MaliciousIP,
                opt => opt.MapFrom(e => e.MaliciousIP))

            .ForMember(p => p.Name,
                opt => opt.MapFrom(e => e.Name));
    }
}
