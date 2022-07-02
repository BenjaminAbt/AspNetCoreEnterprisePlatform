namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct PotentialMaliciousEventsTrafficLocationsEntry(
    string TrafficDirection,
    double? Latitude,
    double? Longitude,
    string CountryName,
    long Count
    );
