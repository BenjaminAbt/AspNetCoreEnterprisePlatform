using System;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;
public record struct TimeScoreSeries(DateTimeOffset On, double Score, TimeScorePoint[] Items);
