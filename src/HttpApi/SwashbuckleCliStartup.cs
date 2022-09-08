// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore.Binders;
using BenjaminAbt.MyDemoPlatform.Models.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BenjaminAbt.MyDemoPlatform.HttpApi;

public class SwashbuckleCliStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // For Swagger CLI, we only need the ASP.NET Core Pipeline
        //   and the registered models, binders and converters.

        services.AddMvc(mvcOptions =>
        {
            mvcOptions.ModelBinderProviders.Insert(0, new PlatformAuthenticationBinders());
            mvcOptions.ModelBinderProviders.Insert(0, new MyDemoPlatformModelsBinderProvider());
        }).AddJsonOptions(options =>
        {
            foreach (var converter in MyDemoPlatformModelJsonConverters.Converters())
            {
                options.JsonSerializerOptions.Converters.Add(converter);
            }
        });

        // Also, we need to register Swashbuckle
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MyDemoPlatform Platform API"
            });
        });
    }
}
