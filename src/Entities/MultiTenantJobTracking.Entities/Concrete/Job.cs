using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  Job : BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public JobStatus JobStatus { get; set; }
        public string Description { get; set; }
        public virtual ICollection< UserJob>  UserJobs { get; set; }
        public virtual ICollection< JobComment>  JobComments { get; set; }
        public virtual ICollection< JobLog>  JobLogs { get; set; }
    }


}
