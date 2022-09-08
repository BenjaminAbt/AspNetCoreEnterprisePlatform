// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
