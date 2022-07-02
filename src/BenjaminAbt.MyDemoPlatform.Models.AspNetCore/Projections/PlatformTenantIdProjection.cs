using System;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.Projections;

public class PlatformTenantIdProjection : PlatformBaseGuidProjection
{
    public PlatformTenantIdProjection()
    {
        CreateMap<PlatformTenantId, Guid>()
            .ConvertUsing(x => x.Value);
    }
}
