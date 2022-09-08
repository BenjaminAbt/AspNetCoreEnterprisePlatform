// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.AspNetCore.Process;
using Microsoft.Extensions.Hosting;

namespace BenjaminAbt.MyDemoPlatform.HttpApi;


// This class is used to generate the OpenAPI documents.
// The CLI scans for "SwaggerHostFactory.CreateHost" which has to return IHost

// Because the CLI set ups the Startup class (and its dependency injection)
//   we give the CLI a seperate one. Otherwise no appsetting values are passed
//   and the CLI startup crashes because our validation throws exceptions.

public static class SwaggerHostFactory
{
    public static IHost CreateHost()
    {
        return Bootstrapper
        .CreateHostBuilder<SwashbuckleCliStartup>(nameof(MyDemoPlatformPlatformHttpApi), new string[0])
        .Build();
    }
}
