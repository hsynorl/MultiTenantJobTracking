using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class JobLog : BaseEntity
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate{ get; set; }
        public JobStatus JobStatus{ get; set; }
        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }

}
