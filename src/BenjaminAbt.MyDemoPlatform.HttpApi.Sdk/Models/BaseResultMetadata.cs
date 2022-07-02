using System;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public abstract class BaseResultMetadata
{
    public BaseResultMetadata(DateTimeOffset on)
    {
        On = on;
    }

    public DateTimeOffset On { get; }
}
