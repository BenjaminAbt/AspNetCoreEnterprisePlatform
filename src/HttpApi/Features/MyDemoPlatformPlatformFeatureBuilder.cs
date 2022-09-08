// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Features;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Features;

public class MyDemoPlatformPlatformFeatureBuilder
{
    public List<MyDemoPlatformPlatformFeature> Features { get; } = new();

    public void Register<TFeature>(IServiceCollection services,
     TFeature feature)
     where TFeature : MyDemoPlatformPlatformFeature
    {
        // activate feature services
        feature.Activate(services);

        // add feature to list
        Features.Add(feature);
    }
}
