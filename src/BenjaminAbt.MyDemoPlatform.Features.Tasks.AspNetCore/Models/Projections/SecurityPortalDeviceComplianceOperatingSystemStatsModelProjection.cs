using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class SecurityPortalDeviceComplianceOperatingSystemStatsModelProjection : AutoMapper.Profile
{
    public SecurityPortalDeviceComplianceOperatingSystemStatsModelProjection()
    {
        CreateMap<DeviceComplicanceOperatingSystemStateStats, SecurityPortalDeviceComplianceOperatingSystemStatsModel>()
            .ForMember(p => p.OperatingSystemName,
                opt => opt.MapFrom(e => e.OperatingSystemName))

            .ForMember(p => p.TotalCompliantCount,
                opt => opt.MapFrom(e => e.TotalCompliantCount))

            .ForMember(p => p.TotalNotCompliantCount,
                opt => opt.MapFrom(e => e.TotalNotCompliantCount))

            .ForMember(p => p.TotalNotEvaluatedCount,
                opt => opt.MapFrom(e => e.TotalNotEvaluatedCount));
    }
}
