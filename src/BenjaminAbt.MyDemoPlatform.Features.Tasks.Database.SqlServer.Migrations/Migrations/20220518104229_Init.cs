using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Database.SqlServer.Migrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AzureLogAnalyticsWorkspaceTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureLogAnalyticsWorkspaceTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MicrosoftDefenderTenantClientCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicrosoftDefenderTenantClientCredentials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AzureLogAnalyticsWorkspaceTenants_TenantId",
                table: "AzureLogAnalyticsWorkspaceTenants",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MicrosoftDefenderTenantClientCredentials_TenantId",
                table: "MicrosoftDefenderTenantClientCredentials",
                column: "TenantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AzureLogAnalyticsWorkspaceTenants");

            migrationBuilder.DropTable(
                name: "MicrosoftDefenderTenantClientCredentials");
        }
    }
}
