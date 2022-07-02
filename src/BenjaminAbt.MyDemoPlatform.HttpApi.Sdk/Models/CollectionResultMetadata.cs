using System;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class CollectionResultMetadata : BaseResultMetadata
{
    public CollectionResultMetadata(DateTimeOffset on, int count, int total) : base(on)
    {
        Count = count;
        Total = total;
    }

    public int Count { get; }
    public int Total { get; }
}
