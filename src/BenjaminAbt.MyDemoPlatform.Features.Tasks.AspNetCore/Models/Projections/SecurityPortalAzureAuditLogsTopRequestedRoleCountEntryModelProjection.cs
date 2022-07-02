using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalAzureAuditLogsTopRequestedRoleCountEntryModelProjection : AutoMapper.Profile
{
    public SecurityPortalAzureAuditLogsTopRequestedRoleCountEntryModelProjection()
    {
        CreateMap<AzureAuditLogsTopRequestedRoleCountEntry, SecurityPortalAzureAuditLogsTopRequestedRoleCountEntryModel>()
            .ForMember(p => p.Roles,
                opt => opt.MapFrom(e => e.Roles))

            .ForMember(p => p.Count,
                opt => opt.MapFrom(e => e.RoleCount));
    }
}
