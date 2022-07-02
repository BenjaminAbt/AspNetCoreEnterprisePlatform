using System;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class TenantUserItemModel
{
    public TenantUserItemModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}
