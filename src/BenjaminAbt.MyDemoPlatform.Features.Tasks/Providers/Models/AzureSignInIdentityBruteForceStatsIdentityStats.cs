using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct AzureSignInIdentityBruteForceStatsIdentityStats(
    string IdentityName,
    DateTimeOffset? From,
    DateTimeOffset? To,
    long TotalIpAddressCount,
    long TotalCountriesCount);
