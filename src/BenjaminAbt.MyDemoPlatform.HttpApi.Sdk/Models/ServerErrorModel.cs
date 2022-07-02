namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class ServerErrorModel : ServerErrorBaseModel
{
    public ServerErrorModel() { }

    public ServerErrorModel(string message, string? traceId)
    {
        Message = message;
        TraceId = traceId;
    }

    public string Message { get; set; } = null!;
    public string? TraceId { get; set; }
}
