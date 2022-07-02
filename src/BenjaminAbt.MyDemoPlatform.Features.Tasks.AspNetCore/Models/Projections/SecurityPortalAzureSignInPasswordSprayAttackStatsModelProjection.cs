using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureSignInPasswordSprayAttackStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureSignInPasswordSprayAttackStatsModelProjection()
    {
        CreateMap<AzureSignInPasswordSprayAttackStats, SecurityPortalAzureSignInPasswordSprayAttackStatsModel>()
            .ForMember(p => p.CountryCode,
                opt => opt.MapFrom(e => e.CountryCode))

            .ForMember(p => p.IPAddress,
                opt => opt.MapFrom(e => e.IPAddress))

            .ForMember(p => p.From,
                opt => opt.MapFrom(e => e.From))

            .ForMember(p => p.To,
                opt => opt.MapFrom(e => e.To))

            .ForMember(p => p.Users,
                opt => opt.MapFrom(e => e.Users));
    }
}
