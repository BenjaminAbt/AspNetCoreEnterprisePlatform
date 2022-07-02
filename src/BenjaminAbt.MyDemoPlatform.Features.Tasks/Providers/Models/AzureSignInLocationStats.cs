namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct AzureSignInLocationStats(
    string CityName,
    string CountryCode,
    double Latitude,
    double Longitude,
    long SucceededCount,
    long FailedCount,
    long TotalCount);

