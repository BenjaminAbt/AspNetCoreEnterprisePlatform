using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct PotentialMaliciousEventsTrafficThreat(
    DateTimeOffset On,
    string Confidence,
    string TrafficDirection,
    string CountryName,
    string IndicatorThreatType,
    string MaliciousIP,
    string Name);
