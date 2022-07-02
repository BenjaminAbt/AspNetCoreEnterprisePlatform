using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataAzureSignInIdentityBruteForceStatsQueryHandler
    : IQueryHandler<GetAzureSignInIdentityBruteForceStatsQuery, ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats>?>
{
    private static readonly string[] _comicNames =
            {
            "Pippi Langstrumpf",
            "Benjamin Blümchen",
            "Emil und die Detektive",
            "Das doppelte Lottchen",
            "Biene Maja",
            "Der König der Löwen",
            "Wickie und die starken Männer",
            "Die Peanuts",
            "Harry Potter",
            "Die Abenteuer von Tom Sawyer und Huckleberry Finn"
        };

    public Task<ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats>?> Handle(GetAzureSignInIdentityBruteForceStatsQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        AzureSignInIdentityBruteForceStatsIdentityStats[] items
            = new AzureSignInIdentityBruteForceStatsIdentityStats[_comicNames.Length];

        for (int i = 0; i < _comicNames.Length; i++)
        {
            string name = _comicNames[i];
            AzureSignInIdentityBruteForceStatsIdentityStats item = new(
                name, now, now.AddDays(3), Random.Shared.Next(1, 999), Random.Shared.Next(1, 200));

            items[i] = item;
        }

        ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats> result = new(now, items);

        return Task.FromResult<ResultSeries<AzureSignInIdentityBruteForceStatsIdentityStats>?>(result);
    }
}
