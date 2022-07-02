using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Common;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.RandomSampleData;

public class GetDemoDataMicrosoftOfficeComplianceCurrentScoreQueryHandler : IQueryHandler<GetMicrosoftOfficeComplianceCurrentScoreQuery, TimeScorePoint?>
{
    public Task<TimeScorePoint?> Handle(GetMicrosoftOfficeComplianceCurrentScoreQuery request, CancellationToken cancellationToken)
    {
        TimeScorePoint result = new(DateTimeOffset.UtcNow, Random.Shared.GenerateDouble(0d, 100d));
        return Task.FromResult<TimeScorePoint?>(result);
    }
}
