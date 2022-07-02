using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalPotentialMaliciousEventsTrafficLocationsEntryModelProjection : AutoMapper.Profile
{
    public SecurityPortalPotentialMaliciousEventsTrafficLocationsEntryModelProjection()
    {
        CreateMap<PotentialMaliciousEventsTrafficLocationsEntry, SecurityPortalPotentialMaliciousEventsTrafficLocationsEntryModel>()
            .ForMember(p => p.TrafficDirection,
                opt => opt.MapFrom(e => e.TrafficDirection))

            .ForMember(p => p.Latitude,
                opt => opt.MapFrom(e => e.Latitude))

            .ForMember(p => p.Longitude,
                opt => opt.MapFrom(e => e.Longitude))

            .ForMember(p => p.CountryName,
                opt => opt.MapFrom(e => e.CountryName))

            .ForMember(p => p.Count,
                opt => opt.MapFrom(e => e.Count));
    }
}

