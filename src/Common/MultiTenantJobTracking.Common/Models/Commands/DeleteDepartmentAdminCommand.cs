namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class DeleteDepartmentAdminCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
