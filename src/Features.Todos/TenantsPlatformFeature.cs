// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.Todos;

public class TodoPlatformFeature : MyDemoPlatformPlatformFeature<TodosPlatformFeatureOptions>
{
    public TodoPlatformFeature(IConfigurationSection configurationSection)
        : base(configurationSection.Bind) { }

    public override void Activate(IServiceCollection services)
    {
        // load options
        TodosPlatformFeatureOptions TenantsPartFeatureOptions = new();
        FeatureOptions.Invoke(TenantsPartFeatureOptions);
    }
}


