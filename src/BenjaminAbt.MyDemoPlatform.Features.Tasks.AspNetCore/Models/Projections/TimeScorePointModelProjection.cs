using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class TimeScorePointModelProjection : AutoMapper.Profile
{
    public TimeScorePointModelProjection()
    {
        CreateMap<TimeScorePoint, TimeScorePointModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Score,
                opt => opt.MapFrom(e => e.Score));
    }
}

