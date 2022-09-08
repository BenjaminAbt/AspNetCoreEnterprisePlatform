// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
