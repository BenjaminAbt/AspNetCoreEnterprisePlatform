
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.SqlServer.Configuration;
public class TenantEntityConfig : IEntityTypeConfiguration<TenantEntity>
{
    public void Configure(EntityTypeBuilder<TenantEntity> b)
    {
        b.ToTable("Tenants");

        b.Property(e => e.Id)
            .UseConversionPlatformTenantId();

        b.HasKey(e => e.Id);

        b.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
