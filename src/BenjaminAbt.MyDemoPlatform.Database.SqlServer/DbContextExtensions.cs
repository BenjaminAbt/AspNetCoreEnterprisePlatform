using System;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Logging;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public static class DbContextExtensions
{
    public static void AddPlatformSqlServerContext<TInterface, TDbContext>(
        this IServiceCollection services, SqlServerDbContextConfig config)
        where TInterface : ISqlServerDbContext
        where TDbContext : SqlServerBaseDbContext, TInterface
    {
        Type dbContextType = typeof(TDbContext);

        services.AddDbContext<TInterface, TDbContext>((provider, o) =>
        {
            ILogger logger = provider.GetRequiredService<ILogger<TDbContext>>();

            string template = config.ConnectionStringTemplate;
            string connectionString = string.Format(template, config.ServerHostname, config.DatabaseName);

            SqlServerLogging.LogConnectionString(logger, dbContextType.FullName, connectionString);
            o.UseSqlServer(connectionString); // no migration parameter here!

            if (config.LoggingEnabled)
            {
                o.UseLoggerFactory(provider.GetRequiredService<ILoggerFactory>());
                SqlServerLogging.LoggerFactoryRegistered(logger, dbContextType.FullName);
            }
            else
            {
                SqlServerLogging.LoggerFactoryNotRegistered(logger, dbContextType.FullName);
            }

            o.UseExceptionProcessor();
        });
    }
}
