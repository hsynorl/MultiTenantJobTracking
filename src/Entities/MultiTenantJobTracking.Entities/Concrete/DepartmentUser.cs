using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class DepartmentUser : BaseEntity
    { 
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual   User  User { get; set; }

    }


}
