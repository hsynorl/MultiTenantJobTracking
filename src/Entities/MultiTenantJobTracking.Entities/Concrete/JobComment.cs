using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  JobComment : BaseEntity
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }//User rolü user
        public string Comment { get; set; }

        public virtual  Job  Job { get; set; }
        public virtual  User  User { get; set; }
    }

}
