using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataPotentialMaliciousTrafficStatsQueryHandler : IQueryHandler<GetPotentialMaliciousTrafficStatsQuery, ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>?>
{
    public Task<ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>?> Handle(GetPotentialMaliciousTrafficStatsQuery request, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        PotentialMaliciousEventsTrafficLocationsEntry[] locations = new PotentialMaliciousEventsTrafficLocationsEntry[]
        {
            new ("INBOUND_OR_UNKNOWN", 50.44d, 7.83d, "Germany", 12),
            new ("INBOUND_OR_UNKNOWN", 18.43d, -64.62d, "British Virgin Island", 6),
            new ("INBOUND_OR_UNKNOWN", 48.14d, 11.57d, "Germany", 4),
            new ("INBOUND_OR_UNKNOWN", 33.61d, -111.89d, "United States", 4),
            new ("INBOUND_OR_UNKNOWN", 50.95d, 6.95d, "Germany", 9),
            new ("INBOUND_OR_UNKNOWN", 48.86d, 2.34d, "France", 7),
            new ("INBOUND_OR_UNKNOWN", 39.04d, -77.47d, "United States", 3)
        };

        ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry> result = new(now,
           locations);

        return Task.FromResult<ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>?>(result);
    }
}
