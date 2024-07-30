using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class DepartmentAdmin : BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public Guid UserId { get; set; } //user depertman admin
        public virtual  User  User { get; set; }
        public virtual Department Department { get; set; }


    }


}
