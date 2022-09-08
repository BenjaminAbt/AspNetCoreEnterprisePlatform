// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Process;

public static class Bootstrapper
{
    public static int Create<TStartup>(string appName, string[] args)
        where TStartup : class
    {
        try
        {
            using IHost host = CreateHostBuilder<TStartup>(appName, args).Build();
            host.Run();

            return 0;
        }
        catch (Exception ex)
        {
            // Log.Logger will likely be internal type "Serilog.Core.Pipeline.SilentLogger"
            // This will log into Azure Streaming, when app fails on startup
            if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();
            }

            Log.Fatal(ex, "Host terminated unexpectedly");

            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder<TStartup>(string appName, string[] args)
        where TStartup : class =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.WithProperty("ApplicationName", appName)
                    .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment)
                    .Enrich.FromLogContext();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<TStartup>()
                    .CaptureStartupErrors(true);
            });
}
