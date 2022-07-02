using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataMicrosoftIdentityUsersRiskStateStatsResultQueryHandler : IQueryHandler<GetMicrosoftIdentityRiskLevelStatsSeriesQuery, ResultSeries<MicrosoftIdentityRiskLevelStats>?>
{
    public Task<ResultSeries<MicrosoftIdentityRiskLevelStats>?> Handle(GetMicrosoftIdentityRiskLevelStatsSeriesQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        string[] riskLevels = { "Low", "Medium", "High" };

        int demoDataCount = Random.Shared.Next(1, 5);
        MicrosoftIdentityRiskLevelStats[] items = new MicrosoftIdentityRiskLevelStats[demoDataCount];
        for (int i = 0; i < demoDataCount; i++)
        {
            int randomRiskLevelIndex = Random.Shared.Next(riskLevels.Length - 1);

            MicrosoftIdentityRiskLevelStats item = new(
                riskLevels[randomRiskLevelIndex],
                Random.Shared.Next(0, 100)
            );

            items[i] = item;
        }

        ResultSeries<MicrosoftIdentityRiskLevelStats> result = new(now,
           items);

        return Task.FromResult<ResultSeries<MicrosoftIdentityRiskLevelStats>?>(result);
    }
}
