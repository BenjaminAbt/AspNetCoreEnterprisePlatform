using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Sqlite.Configuration;

public class UserAccountEntityConfig : IEntityTypeConfiguration<UserAccountEntity>
{
    public void Configure(EntityTypeBuilder<UserAccountEntity> b)
    {
        b.ToTable("UserAccounts");

        b.Property(e => e.Id)
            .UseConversionPlatformUserId();

        b.HasKey(e => e.Id);

        b.Property(e => e.CreatedOn)
            .IsRequired();
    }
}
