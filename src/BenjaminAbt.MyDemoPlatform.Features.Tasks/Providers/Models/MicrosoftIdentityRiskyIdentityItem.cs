using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
public record struct MicrosoftIdentityRiskyIdentityItem(
   DateTimeOffset On,
   string Identity,
   string RiskLevel);
