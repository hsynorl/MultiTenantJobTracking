namespace MultiTenantJobTracking.Common.Models.DepartmentAdmin.Command
{
    public class UpdateDepartmentAdminCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
