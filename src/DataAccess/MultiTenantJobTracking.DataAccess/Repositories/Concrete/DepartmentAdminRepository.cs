using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.DataAccess.Repositories.Concrete
{
    public class DepartmentAdminRepository : GenericRepository<DepartmentAdmin>, IDepartmentAdminRepository
    {
        public DepartmentAdminRepository(MultiTenantJobTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
