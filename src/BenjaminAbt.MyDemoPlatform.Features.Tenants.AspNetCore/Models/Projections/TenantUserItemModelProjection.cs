using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore.Models.Projections;

public class TenantUserItemModelProjection : AutoMapper.Profile
{
    public TenantUserItemModelProjection()
    {
        CreateMap<UserInfoModel, TenantUserItemModel>()
            .ForMember(p => p.Id,
                opt => opt.MapFrom(e => e.Id))

            .ForMember(p => p.Name,
                opt => opt.MapFrom(e => e.Name));
    }
}
