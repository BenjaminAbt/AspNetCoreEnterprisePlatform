using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Common;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataAzureExposureOvertimeScoreQueryHandler
    : IQueryHandler<GetAzureExposureOvertimeScoreQuery, TimeScoreSeries?>
{
    public Task<TimeScoreSeries?> Handle(GetAzureExposureOvertimeScoreQuery request, CancellationToken cancellationToken)
    {
        int range = 30;

        DateTimeOffset now = DateTimeOffset.UtcNow;

        double scoreSum = 0;
        var items = new TimeScorePoint[range];
        for (int i = 0; i < range; i++)
        {
            double score = Random.Shared.GenerateDouble(10d, 50d);
            DateTimeOffset on = now.AddDays(-1 * i);

            items[i] = new TimeScorePoint(on, score);
            scoreSum = scoreSum + score;
        }

        double avg = scoreSum / range;

        TimeScoreSeries result = new(now, avg, items);
        return Task.FromResult<TimeScoreSeries?>(result);
    }
}
