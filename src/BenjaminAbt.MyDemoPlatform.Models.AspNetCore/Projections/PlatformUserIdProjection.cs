using System;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.Projections;

public class PlatformUserIdProjection : PlatformBaseGuidProjection
{
    public PlatformUserIdProjection()
    {
        CreateMap<PlatformUserId, Guid>()
            .ConvertUsing(x => x.Value);
    }
}
