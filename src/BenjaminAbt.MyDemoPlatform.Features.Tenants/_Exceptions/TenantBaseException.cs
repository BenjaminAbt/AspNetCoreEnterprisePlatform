using System;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants;

public abstract class TenantBaseException : Exception
{
    public TenantBaseException(string message) : base(message)
    {
    }

    public TenantBaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
