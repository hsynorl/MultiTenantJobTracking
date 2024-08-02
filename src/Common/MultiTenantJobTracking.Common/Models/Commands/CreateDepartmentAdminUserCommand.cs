namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateDepartmentAdminUserCommand:CreateUserCommand
    {
        public Guid DepartmentId { get; set; }
    }
}
