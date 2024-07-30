using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  Tenant : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public virtual ICollection<Department> Departments{ get; set; }
        public virtual ICollection< TenantUser>  TenantAdmins{ get; set; }
    }


}
