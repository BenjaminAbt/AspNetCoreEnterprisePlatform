﻿// <auto-generated />
using System;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations.Migrations
{
    [DbContext(typeof(SecurityPortalDatabaseSqlServerContext))]
    [Migration("20220518104229_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities.AzureLogAnalyticsWorkspaceTenantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkspaceId")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("AzureLogAnalyticsWorkspaceTenants", (string)null);
                });

            modelBuilder.Entity("BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.Entities.MicrosoftDefenderTenantClientCredentialsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("MicrosoftDefenderTenantClientCredentials", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
