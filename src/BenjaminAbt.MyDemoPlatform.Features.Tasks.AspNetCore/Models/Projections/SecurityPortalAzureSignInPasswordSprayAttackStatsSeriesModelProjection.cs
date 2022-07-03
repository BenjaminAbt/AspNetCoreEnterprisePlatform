using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureSignInPasswordSprayAttackStatsSeriesModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureSignInPasswordSprayAttackStatsSeriesModelProjection()
    {
        CreateMap<ResultSeries<AzureSignInPasswordSprayAttackStats>, SecurityPortalAzureSignInPasswordSprayAttackStatsSeriesModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Items,
                opt => opt.MapFrom(e => e.Items));
    }
}