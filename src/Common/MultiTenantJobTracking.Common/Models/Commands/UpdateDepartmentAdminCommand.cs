namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class UpdateDepartmentAdminCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
