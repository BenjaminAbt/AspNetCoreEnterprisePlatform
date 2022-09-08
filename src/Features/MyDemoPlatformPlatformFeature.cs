// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using BenjaminAbt.MyDemoPlatform.Features.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features;

public abstract class MyDemoPlatformPlatformFeature
{
    /// <summary>
    /// Activates the feature and registers their dependencies
    /// </summary>
    public abstract void Activate(IServiceCollection services);
}

public abstract class MyDemoPlatformPlatformFeature<TFeatureOptions> : MyDemoPlatformPlatformFeature
   where TFeatureOptions : class, IMyDemoPlatformPlatformFeatureOptions
{
    public MyDemoPlatformPlatformFeature(IConfigurationSection configurationSection)
        : this(configurationSection.Bind) { }

    public MyDemoPlatformPlatformFeature(Action<TFeatureOptions> options) { FeatureOptions = options; }

    public Action<TFeatureOptions> FeatureOptions { get; }
}
