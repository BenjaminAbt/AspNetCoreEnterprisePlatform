using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;

public abstract class TenantBaseEntity : BaseEntity
{
    public PlatformTenantId TenantId { get; set; } = null!;
}
