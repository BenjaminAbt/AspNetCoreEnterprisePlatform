using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureSignInLocationStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureSignInLocationStatsModelProjection()
    {
        CreateMap<AzureSignInLocationStats, SecurityPortalAzureSignInLocationStatsModel>()
            .ForMember(p => p.CityName,
                opt => opt.MapFrom(e => e.CityName))
            .ForMember(p => p.CountryCode,
                opt => opt.MapFrom(e => e.CountryCode))

            .ForMember(p => p.Latitude,
                opt => opt.MapFrom(e => e.Latitude))
            .ForMember(p => p.Longitude,
                opt => opt.MapFrom(e => e.Longitude))

            .ForMember(p => p.SucceededCount,
                opt => opt.MapFrom(e => e.SucceededCount))

            .ForMember(p => p.FailedCount,
                opt => opt.MapFrom(e => e.FailedCount))

            .ForMember(p => p.TotalCount,
                opt => opt.MapFrom(e => e.TotalCount));
    }
}
