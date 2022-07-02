using System;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;

public record class GetPotentialMaliciousTrafficStatsQuery(
    PlatformTenantId TenantId, DateTimeOffset From, DateTimeOffset To) : IQuery<ResultSeries<PotentialMaliciousEventsTrafficLocationsEntry>?>;
