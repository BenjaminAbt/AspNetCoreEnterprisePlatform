namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct DeviceComplicanceOperatingSystemStateStats(
    string OperatingSystemName,
    long TotalCompliantCount,
    long TotalNotCompliantCount,
    long TotalNotEvaluatedCount);
