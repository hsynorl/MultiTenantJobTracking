using MultiTenantJobTracking.Entities.Abstract;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  Tenant : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Department> Departments{ get; set; }
        public virtual ICollection< TenantUser>  TenantAdmins{ get; set; }
        public virtual Licence Licence { get; set; }

    }


}
