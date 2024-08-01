using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Common.Models.ViewModels   
{
    public class UserJobViewModel
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public JobStatus JobStatus { get; set; }
        public string Description { get; set; }
    }

}
