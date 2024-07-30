using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  Job : BaseEntity
    {
        public string Description { get; set; }
        public virtual ICollection< UserJob>  UserJobs { get; set; }
        public virtual ICollection< JobComment>  JobComments { get; set; }
        public virtual ICollection< JobLog>  JobLogs { get; set; }
    }


}
