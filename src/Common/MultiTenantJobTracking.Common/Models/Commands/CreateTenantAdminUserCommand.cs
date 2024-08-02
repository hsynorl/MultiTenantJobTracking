namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateTenantAdminUserCommand:CreateUserCommand {
        public Guid TenantId { get; set; }
    }
}
