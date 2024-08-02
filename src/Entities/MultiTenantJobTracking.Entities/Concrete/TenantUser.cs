using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  TenantUser : BaseEntity
    {
        
        public Guid TenantId { get; set; } 
        public virtual  Tenant  Tenant { get; set; }
        public virtual  User  User { get; set; }
    }


}
