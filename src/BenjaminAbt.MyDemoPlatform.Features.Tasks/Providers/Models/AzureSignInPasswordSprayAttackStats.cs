using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct AzureSignInPasswordSprayAttackStats(
    string CountryCode,
    string IPAddress,
    DateTimeOffset From,
    DateTimeOffset To,
    string[] Users);

