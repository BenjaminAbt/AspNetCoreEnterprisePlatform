// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Collections.Generic;
using System.Reflection;
using BenjaminAbt.MyDemoPlatform.AspNetCore.Monitoring;
using BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore;
using BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore.Binders;
using BenjaminAbt.MyDemoPlatform.Engine;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore;
using BenjaminAbt.MyDemoPlatform.Features.Todos.AspNetCore;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk;
using BenjaminAbt.MyDemoPlatform.Models.AspNetCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Features;

/// <summary>
/// This class takes care of loading all features and parts. This can then be added to the ASP.NET Config registry with a single line.
/// </summary>
public static class MyDemoPlatformPlatformRegistration
{
    /// <summary>
    /// Registers all necessary dependencies that are required for the operation of MyDemoPlatform.
    /// Furthermore all features and their parts are registered and activated.
    /// </summary>
    /// <returns></returns>
    public static MyDemoPlatformPlatformPartBuilder AddMyDemoPlatformPlatform(
        this IServiceCollection services, IConfiguration configuration)
    {
        // infrastructure
        services.AddOptions();
        services.AddHttpContextAccessor();


        // monitoring
        services.AddPlatformMonitoring();

        // engine
        services.AddEngine();

        // create part builder
        MyDemoPlatformPlatformPartBuilder partBuilder = new();

        try
        {
            // register parts
            partBuilder.Register(services, new TenantsFeaturePart(configuration.GetSection("TenantsFeature")));
            partBuilder.Register(services, new TodoPart(configuration.GetSection("TodoFeature")));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        // enable auto mapper
        {
            IEnumerable<Assembly> autoMapperAssemblies = partBuilder.ConfigureAutomapperAssemblies();
            services.AddAutoMapper(autoMapperAssemblies);
        }

        // register mvc
        IMvcBuilder mvcBuilder = services.AddMvc(mvcOptions =>
        {
            mvcOptions.ModelBinderProviders.Insert(0, new PlatformAuthenticationBinders());
            mvcOptions.ModelBinderProviders.Insert(0, new MyDemoPlatformModelsBinderProvider());

            partBuilder.ConfigureAspNetCoreMvc(mvcOptions);

        }).AddJsonOptions(options =>
        {
            foreach (var converter in MyDemoPlatformModelJsonConverters.Converters())
            {
                options.JsonSerializerOptions.Converters.Add(converter);
            }

            partBuilder.ConfigureAspNetCoreMvcJsonOptions(options);
        });

        // enable fluent assertion
        Assembly[] fluentValidationAssemblies = new[] { typeof(MyDemoPlatformApiSdk).Assembly };
        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblies(fluentValidationAssemblies);

        // register builder
        services.AddSingleton(partBuilder);

        // authentication
        services.AddPlatformAspNetCoreAuthentication();

        /** DISABLED AUTH FOR DEMO
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddMicrosoftIdentityWebApi(configuration);
            // authorization
            services.AddAuthorization(options =>
            {
                partBuilder.ConfigurePlatformAuthorization(services, options);
            });

        **/

        return partBuilder;
    }
}
