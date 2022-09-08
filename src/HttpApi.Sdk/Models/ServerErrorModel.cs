// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
