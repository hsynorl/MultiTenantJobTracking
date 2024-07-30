using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.DataAccess.Repositories.Concrete
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MultiTenantJobTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
