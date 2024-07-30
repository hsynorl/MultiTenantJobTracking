namespace MultiTenantJobTracking.Common.Models.DepartmentAdmin.Command
{
    public class DeleteDepartmentAdminCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
