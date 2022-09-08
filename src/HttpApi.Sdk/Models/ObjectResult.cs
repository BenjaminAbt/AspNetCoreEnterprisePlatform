// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class ObjectResult<T> : BaseResult
{
    public ObjectResult(T? data, ObjectResultMetadata metadata)
    {
        Data = data;
        Metadata = metadata;
    }

    public T? Data { get; set; }
    public ObjectResultMetadata Metadata { get; set; }
}
