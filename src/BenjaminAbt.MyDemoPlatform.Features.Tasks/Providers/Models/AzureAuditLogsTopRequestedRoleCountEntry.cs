namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Providers.Models;

public record struct AzureAuditLogsTopRequestedRoleCountEntry(
    string Roles,
    long RoleCount);
