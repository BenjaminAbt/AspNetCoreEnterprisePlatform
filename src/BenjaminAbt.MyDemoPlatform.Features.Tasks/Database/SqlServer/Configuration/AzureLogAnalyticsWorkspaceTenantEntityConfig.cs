using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Configuration;

public class AzureLogAnalyticsWorkspaceTenantEntityConfig
    : IEntityTypeConfiguration<AzureLogAnalyticsWorkspaceTenantEntity>
{
    public void Configure(EntityTypeBuilder<AzureLogAnalyticsWorkspaceTenantEntity> b)
    {
        b.ToTable("AzureLogAnalyticsWorkspaceTenants");

        b.HasKey(e => e.Id);

        b.Property(e => e.TenantId)
            .UseConversionPlatformTenantId();

        b.HasIndex(e => e.TenantId)
            .IsUnique();

        b.Property(e => e.WorkspaceId)
            .UseConversionAzureWorkspaceId();

        b.Property(e => e.WorkspaceId)
            .HasMaxLength(100)
            .IsRequired();
    }
}
