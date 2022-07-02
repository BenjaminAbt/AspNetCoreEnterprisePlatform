namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct MicrosoftIdentityRiskLevelStats(
    string RiskLevel,
    long Count);
