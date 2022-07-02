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
