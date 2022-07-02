using System.Collections.Generic;
using System.Reflection;
using BenjaminAbt.MyDemoPlatform.Features;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Features;

public class MyDemoPlatformPlatformPartBuilder
{
    private readonly MyDemoPlatformPlatformFeatureBuilder _featureBuilder = new();

    public List<MyDemoPlatformPlatformFeatureMvcPart> Parts { get; } = new();

    public void Register<TFeature>(IServiceCollection services,
        MyDemoPlatformPlatformFeatureMvcPart<TFeature> featurePart)
        where TFeature : MyDemoPlatformPlatformFeature
    {

        _featureBuilder.Register(services, featurePart.Feature);

        // activate feature part
        featurePart.ConfigureServices(services);

        // add feature to list
        Parts.Add(featurePart);
    }
    public IEnumerable<Assembly> ConfigureAutomapperAssemblies()
    {
        foreach (MyDemoPlatformPlatformFeatureMvcPart featurePart in Parts)
        {
            foreach (var assembly in featurePart.ConfigureAutomapperAssemblies())
            {
                yield return assembly;
            }
        }
    }

    public void ConfigurePlatformAuthorization(
        IServiceCollection services, AuthorizationOptions options)
    {
        foreach (MyDemoPlatformPlatformFeatureMvcPart featurePart in Parts)
        {
            featurePart.ConfigureAuthorization(services, options);
        }
    }

    public void ConfigureAspNetCoreMvc(MvcOptions mvcOptions)
    {
        foreach (MyDemoPlatformPlatformFeatureMvcPart featurePart in Parts)
        {
            featurePart.ConfigureAspNetMvc(mvcOptions);
        }
    }
    public void ConfigureAspNetCoreMvcJsonOptions(JsonOptions jsonOptions)
    {
        foreach (MyDemoPlatformPlatformFeatureMvcPart featurePart in Parts)
        {
            featurePart.ConfigureAspNetMvcJsonOptions(jsonOptions);
        }
    }
}
