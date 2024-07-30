using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  UserJob : BaseEntity
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }//User rolü user

        public virtual  Job  Job{ get; set; }
        public virtual  User  User{ get; set; }
    }


}
