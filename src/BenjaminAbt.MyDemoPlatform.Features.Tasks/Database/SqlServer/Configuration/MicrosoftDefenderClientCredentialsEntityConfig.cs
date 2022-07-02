using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Configuration;

public class MicrosoftDefenderTenantClientCredentialsEntityConfig
    : IEntityTypeConfiguration<MicrosoftDefenderTenantClientCredentialsEntity>
{
    public void Configure(EntityTypeBuilder<MicrosoftDefenderTenantClientCredentialsEntity> b)
    {
        b.ToTable("MicrosoftDefenderTenantClientCredentials");

        b.HasKey(e => e.Id);

        b.Property(e => e.TenantId)
            .UseConversionPlatformTenantId();

        b.HasIndex(e => e.TenantId)
            .IsUnique();

        b.Property(e => e.ClientId)
            .HasMaxLength(100)
            .IsRequired();

        b.Property(e => e.ClientSecret)
            .HasMaxLength(500)
            .IsRequired();
    }
}
