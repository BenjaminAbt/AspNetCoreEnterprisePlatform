using System.Collections.Generic;
using System.Reflection;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore;

public class TenantsFeaturePart : MyDemoPlatformPlatformFeatureMvcPart<TenantsPlatformFeature>
{
    public TenantsFeaturePart(IConfigurationSection configurationSection)
         : base(new TenantsPlatformFeature(configurationSection))
    { }

    public override IEnumerable<Assembly> ConfigureAutomapperAssemblies()
    {
        yield return typeof(TenantsFeaturePart).Assembly;
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IRequestUserIdentityTenantAuthAccessor, RequestUserIdentityTenantAuthAccessor>();
    }
}
