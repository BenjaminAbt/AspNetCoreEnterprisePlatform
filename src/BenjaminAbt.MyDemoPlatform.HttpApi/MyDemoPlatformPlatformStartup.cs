using BenjaminAbt.MyDemoPlatform.AspNetCore;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Sqlite;
using BenjaminAbt.MyDemoPlatform.HttpApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BenjaminAbt.MyDemoPlatform.HttpApi;

public class MyDemoPlatformPlatformStartup
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MyDemoPlatformPlatformStartup(
        IWebHostEnvironment webHostEnvironment,
        IConfiguration configuration)
    {
        _webHostEnvironment = webHostEnvironment;
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Abtis Platform
        MyDemoPlatformPlatformPartBuilder partBuilder = services.AddMyDemoPlatformPlatform(Configuration);

        // Cors
        services.AddCors(options =>
        {
            // We run the API and the frontend on different domains and furthermore want to eventually make the API available to additional frontends, which is why we currently allow Cors in full.
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MyDemoPlatform Platform API"
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        // SQLITE DEMO ONLY
        using (var startupScope = app.ApplicationServices.CreateScope())
        {
            var db = startupScope.ServiceProvider.GetRequiredService<TenantsDatabaseSqliteContext>();
            db.Database.EnsureCreated();
        }


        // development web pages
        if (_webHostEnvironment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // custom exception handler
            app.UseGlobalExceptionHandler();

            // enforce https
            app.UseHsts();
        }

        //  redirect to https
        app.UseHttpsRedirection();

        // Enable Routing
        app.UseRouting();

        // Cors
        app.UseCors("AllowAll");

        /** DISABLED AUTH FOR DEMO

        // enable authentication and authorization
        app.UseAuthentication();

        // enable authorization
        app.UseAuthorization();

        **/

        // Routing Middleware
        app.UseEndpoints(endpoints =>
        {
            // use route controllers
            endpoints.MapControllers();
        });
    }
}
