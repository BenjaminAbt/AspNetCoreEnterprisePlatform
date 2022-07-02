using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Sqlite.Configuration;

public class TenantUserAccountAssociationEntityConfig : IEntityTypeConfiguration<TenantUserAccountAssociationEntity>
{
    public void Configure(EntityTypeBuilder<TenantUserAccountAssociationEntity> b)
    {
        b.ToTable("TenantUserAccountAssociations");

        b.HasKey(e => e.Id);

        b.Property(e => e.TenantId)
            .UseConversionPlatformTenantId();

        b.Property(e => e.UserAccountId)
            .UseConversionPlatformUserId();

        b.HasIndex(e => new { e.TenantId, e.UserAccountId })
           .IsUnique();

        b.HasOne(e => e.Tenant)
           .WithMany(e => e.TenantUserAccountAssociations)
           .HasForeignKey(e => e.TenantId);

        b.HasOne(e => e.UserAccount)
           .WithMany(e => e.TenantUserAccountAssociations)
           .HasForeignKey(e => e.UserAccountId);

        b.Property(e => e.CreatedOn)
           .IsRequired();
    }
}
