using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalCloudUsageStorageUserDownloadedBytesStatsEntryModelProjection : AutoMapper.Profile
{
    public SecurityPortalCloudUsageStorageUserDownloadedBytesStatsEntryModelProjection()
    {
        CreateMap<CloudUsageStorageUserDownloadedBytesStatsEntry, SecurityPortalCloudUsageStorageUserDownloadedBytesStatsEntryModel>()
            .ForMember(p => p.Name,
                opt => opt.MapFrom(e => e.Name))

            .ForMember(p => p.Bytes,
                opt => opt.MapFrom(e => e.Bytes));
    }
}
