

using BenjaminAbt.MyDemoPlatform.Features.Todos;
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


