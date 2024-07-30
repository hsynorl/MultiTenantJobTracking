using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Common.Models.Job.Command
{
    public class UpdateJobCommand
    {
        public Guid JobId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public JobStatus JobStatus { get; set; }
        public string Description { get; set; }
    }
}
