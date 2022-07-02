using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureSignInIdentityBruteForceStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureSignInIdentityBruteForceStatsModelProjection()
    {
        CreateMap<AzureSignInIdentityBruteForceStatsIdentityStats, SecurityPortalAzureSignInIdentityBruteForceStatsModel>()
            .ForMember(p => p.IdentityName,
                opt => opt.MapFrom(e => e.IdentityName))

            .ForMember(p => p.From,
                opt => opt.MapFrom(e => e.From))

            .ForMember(p => p.To,
                opt => opt.MapFrom(e => e.To))

            .ForMember(p => p.TotalIpAddressCount,
                opt => opt.MapFrom(e => e.TotalIpAddressCount))

            .ForMember(p => p.TotalCountriesCount,
                opt => opt.MapFrom(e => e.TotalCountriesCount));
    }
}
