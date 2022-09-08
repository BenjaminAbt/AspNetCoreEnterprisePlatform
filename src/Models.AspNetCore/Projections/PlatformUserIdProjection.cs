// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
