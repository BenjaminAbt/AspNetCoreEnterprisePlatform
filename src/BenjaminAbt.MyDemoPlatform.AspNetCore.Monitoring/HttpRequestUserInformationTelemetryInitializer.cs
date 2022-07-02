using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Monitoring;

public class HttpRequestUserInformationTelemetryInitializer : ITelemetryInitializer
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpRequestUserInformationTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is RequestTelemetry requestTelemetry)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            requestTelemetry.Context.GlobalProperties.Add("HttpRequestIdentityName", httpContext.User.Identity.Name);
        }
    }
}
