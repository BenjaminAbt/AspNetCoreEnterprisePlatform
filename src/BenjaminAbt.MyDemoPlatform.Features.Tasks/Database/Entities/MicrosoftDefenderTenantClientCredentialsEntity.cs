using System;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;

public class MicrosoftDefenderTenantClientCredentialsEntity : TenantBaseEntity
{
    public MicrosoftDefenderTenantClientCredentialsEntity() { }

    public MicrosoftDefenderTenantClientCredentialsEntity(
        Guid id, PlatformTenantId tenantId, string clientId, string clientSecret, DateTimeOffset createdOn)
    {
        Id = id;
        TenantId = tenantId;
        ClientId = clientId;
        ClientSecret = clientSecret;
        CreatedOn = createdOn;
    }


    public Guid Id { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
}
