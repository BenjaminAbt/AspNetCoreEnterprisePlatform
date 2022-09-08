// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Features.Abstractions;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public class TenantsPlatformFeatureOptions : IMyDemoPlatformPlatformFeatureOptions
{
    public TenantsDatabaseConfig? Database { get; set; }
}

