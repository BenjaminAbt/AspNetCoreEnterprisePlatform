using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore;

public class SecurityPortalPart : MyDemoPlatformPlatformFeatureMvcPart<SecurityPortalPlatformFeature>
{
    public SecurityPortalPart(IConfigurationSection configurationSection)
         : base(new SecurityPortalPlatformFeature(configurationSection))
    {
        AutoMapperAssemblies = new[] { typeof(SecurityPortalPart).Assembly };
    }

    public override void AddServices(IServiceCollection services) { }

    public override void ConfigureAuthorization(IServiceCollection services, AuthorizationOptions options)
    {

    }
}
