using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Models.Projections;

public class TimeScoreSeriesModelProjection : AutoMapper.Profile
{
    public TimeScoreSeriesModelProjection()
    {
        CreateMap<TimeScoreSeries, TimeScoreSeriesModel>()
            .ForMember(p => p.On,
                opt => opt.MapFrom(e => e.On))

            .ForMember(p => p.Score,
                opt => opt.MapFrom(e => e.Score))

            .ForMember(p => p.Items,
                opt => opt.MapFrom(e => e.Items));
    }
}
