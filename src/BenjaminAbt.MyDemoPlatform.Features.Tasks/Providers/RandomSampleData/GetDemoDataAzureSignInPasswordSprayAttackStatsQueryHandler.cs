using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataAzureSignInPasswordSprayAttackStatsQueryHandler
    : IQueryHandler<GetAzureSignInPasswordSprayAttackStatsQuery, ResultSeries<AzureSignInPasswordSprayAttackStats>?>
{
    public Task<ResultSeries<AzureSignInPasswordSprayAttackStats>?> Handle(GetAzureSignInPasswordSprayAttackStatsQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        AzureSignInPasswordSprayAttackStats[] stats = new[]
        {
            new AzureSignInPasswordSprayAttackStats("RU", "188.162.43.198", now, now.AddDays(-3),
            new[]{"Batman", "Robin", "Donald Duck", "Dagobert" }),
            new AzureSignInPasswordSprayAttackStats("DE", "192.16.137.2", now, now.AddDays(-6),
             new[]{"Peter Pan", "Superman", "Wonderwoman"}),
            new AzureSignInPasswordSprayAttackStats("RU", "188.162.43.168", now, now.AddDays(-4),
             new[]{"Kitkat", "Snickers"}),
            new AzureSignInPasswordSprayAttackStats("US", "184.90.16.128", now, now.AddDays(-3),
             new[]{"Alvin", "Chipmunks" }),
        };

        ResultSeries<AzureSignInPasswordSprayAttackStats> result = new(now, stats);
        return Task.FromResult<ResultSeries<AzureSignInPasswordSprayAttackStats>?>(result);
    }
}
