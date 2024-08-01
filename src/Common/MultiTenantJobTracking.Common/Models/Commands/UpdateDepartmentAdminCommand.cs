namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class UpdateDepartmentAdminCommand
    {
        public Guid UpdateDepartmentId { get; set; }
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
