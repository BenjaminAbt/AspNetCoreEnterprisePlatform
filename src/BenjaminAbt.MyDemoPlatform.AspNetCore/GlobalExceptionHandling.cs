using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore;
public static class GlobalExceptionHandling
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(err => err.UseCustomErrors());
        return app;
    }

    public static IApplicationBuilder UseCustomErrors(this IApplicationBuilder app)
    {
        app.Use(WriteResponse);
        return app;
    }

    private static async Task WriteResponse(HttpContext httpContext, Func<Task> next)
    {
        string? traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;

        ServerErrorModel errorModel = new ServerErrorModel("Internal Server Error", traceId);

        System.IO.Stream stream = httpContext.Response.Body;
        await JsonSerializer.SerializeAsync(stream, errorModel);
    }
}
