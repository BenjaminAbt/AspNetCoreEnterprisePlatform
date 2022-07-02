using System;
using System.Collections.Generic;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct ResultSeries<TItem>(DateTimeOffset On, IEnumerable<TItem> Items);
