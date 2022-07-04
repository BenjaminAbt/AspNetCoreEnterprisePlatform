using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using System.Reflection;

namespace BenjaminAbt.MyDemoPlatform.Features.Todos.AspNetCore;

public class TodoPart : MyDemoPlatformPlatformFeatureMvcPart<TodoPlatformFeature>
{
    public TodoPart(IConfigurationSection configurationSection)
         : base(new TodoPlatformFeature(configurationSection))
    { }

    public override IEnumerable<Assembly> ConfigureAutomapperAssemblies()
    {
        yield return typeof(TodoPlatformFeature).Assembly;
    }

    public override void ConfigureServices(IServiceCollection services)
    {
     
    }
}
