using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;

public abstract class MyDemoPlatformPlatformFeatureMvcPart
{
    // Actions
    public virtual void ConfigureServices(IServiceCollection services) { }

    public virtual void ConfigureAuthorization(
        IServiceCollection services, AuthorizationOptions options)
    { }

    public virtual IEnumerable<Assembly> ConfigureAutomapperAssemblies()
    {
        return Enumerable.Empty<Assembly>();
    }

    public virtual void ConfigureAspNetMvc(
        MvcOptions mvcOptions)
    { }
    public virtual void ConfigureAspNetMvcJsonOptions(
        JsonOptions jsonOptions)
    { }
}

public abstract class MyDemoPlatformPlatformFeatureMvcPart<T>
    : MyDemoPlatformPlatformFeatureMvcPart where T : MyDemoPlatformPlatformFeature
{
    public MyDemoPlatformPlatformFeatureMvcPart(T feature)
    {
        Feature = feature;
    }

    public T Feature { get; }
}
