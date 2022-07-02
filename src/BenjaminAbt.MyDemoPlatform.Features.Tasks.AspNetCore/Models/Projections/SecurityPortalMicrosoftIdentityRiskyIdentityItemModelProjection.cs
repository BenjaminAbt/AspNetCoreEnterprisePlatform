using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalMicrosoftIdentityRiskyIdentityItemModelProjection : AutoMapper.Profile
{
    public SecurityPortalMicrosoftIdentityRiskyIdentityItemModelProjection()
    {
        CreateMap<MicrosoftIdentityRiskyIdentityItem, SecurityPortalMicrosoftIdentityRiskyIdentityItemModel>()

            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Identity,
                opt => opt.MapFrom(e => e.Identity))

            .ForMember(p => p.RiskLevel,
                opt => opt.MapFrom(e => e.RiskLevel));
    }
}
