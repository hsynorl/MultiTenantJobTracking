using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class DepartmentAdmin : BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public virtual  User  User { get; set; }
        public virtual Department Department { get; set; }


    }


}
