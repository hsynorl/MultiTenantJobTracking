using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class Department : BaseEntity
    {
        public Guid TenantId{ get; set; }
        public string  Name{ get; set; }
        public virtual  Tenant  Tenant { get; set; }
        public virtual ICollection<DepartmentAdmin> DepartmentAdmins { get; set; }

    }


}
