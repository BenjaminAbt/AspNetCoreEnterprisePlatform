using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureAuditLogsTopRequestedRoleCountStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureAuditLogsTopRequestedRoleCountStatsModelProjection()
    {
        CreateMap<ResultSeries<AzureAuditLogsTopRequestedRoleCountEntry>, SecurityPortalAzureAuditLogsTopRequestedRoleCountStatsModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Items,
                opt => opt.MapFrom(e => e.Items));
    }
}
