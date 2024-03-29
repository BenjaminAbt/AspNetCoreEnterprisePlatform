﻿// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class CollectionResult<T> : BaseResult
{
    public CollectionResult(List<T> data, CollectionResultMetadata metadata)
    {
        Data = data;
        Metadata = metadata;
    }

    public List<T> Data { get; set; }
    public CollectionResultMetadata Metadata { get; set; }
}
