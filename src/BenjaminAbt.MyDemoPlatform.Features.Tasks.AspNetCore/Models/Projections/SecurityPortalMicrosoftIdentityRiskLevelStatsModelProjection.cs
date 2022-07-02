using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalMicrosoftIdentityRiskLevelStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalMicrosoftIdentityRiskLevelStatsModelProjection()
    {
        CreateMap<MicrosoftIdentityRiskLevelStats, SecurityPortalMicrosoftIdentityRiskLevelStatsModel>()

            .ForMember(p => p.RiskLevel,
                opt => opt.MapFrom(e => e.RiskLevel))

            .ForMember(p => p.Count,
                opt => opt.MapFrom(e => e.Count));
    }
}
