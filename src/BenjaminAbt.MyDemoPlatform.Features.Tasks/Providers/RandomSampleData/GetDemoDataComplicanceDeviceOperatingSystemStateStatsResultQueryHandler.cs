using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataComplicanceDeviceOperatingSystemStateStatsResultQueryHandler
    : IQueryHandler<GetDeviceComplicanceOperatingSystemStateStatsResultQuery, ResultSeries<DeviceComplicanceOperatingSystemStateStats>?>
{

    public Task<ResultSeries<DeviceComplicanceOperatingSystemStateStats>?> Handle(GetDeviceComplicanceOperatingSystemStateStatsResultQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        DeviceComplicanceOperatingSystemStateStats[] items
            = {
            new DeviceComplicanceOperatingSystemStateStats
            {
                OperatingSystemName = "iOS",
                TotalCompliantCount = Random.Shared.Next(20,100),
                TotalNotCompliantCount = Random.Shared.Next(20,100),
                TotalNotEvaluatedCount = Random.Shared.Next(20,100)
            }, new DeviceComplicanceOperatingSystemStateStats
            {
                OperatingSystemName = "Windows",
                TotalCompliantCount = Random.Shared.Next(20,100),
                TotalNotCompliantCount = Random.Shared.Next(20,100),
                TotalNotEvaluatedCount = Random.Shared.Next(20,100)
            }, new DeviceComplicanceOperatingSystemStateStats
            {
                OperatingSystemName = "Android",
                TotalCompliantCount = Random.Shared.Next(20,100),
                TotalNotCompliantCount = Random.Shared.Next(20,100),
                TotalNotEvaluatedCount = Random.Shared.Next(20,100)
            }
        };


        ResultSeries<DeviceComplicanceOperatingSystemStateStats> result = new(now, items);

        return Task.FromResult<ResultSeries<DeviceComplicanceOperatingSystemStateStats>?>(result);
    }
}
