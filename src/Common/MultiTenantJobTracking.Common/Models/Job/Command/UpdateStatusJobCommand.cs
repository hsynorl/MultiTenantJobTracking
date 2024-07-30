using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Common.Models.Job.Command
{
    public class UpdateStatusJobCommand
    {
        public Guid JobId { get; set; }
        public JobStatus JobStatus { get; set; }
        public Guid UserId { get; set; }
    }
}
