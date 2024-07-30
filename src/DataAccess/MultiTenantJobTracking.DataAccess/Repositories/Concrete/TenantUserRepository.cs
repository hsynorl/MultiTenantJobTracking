using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.DataAccess.Repositories.Concrete
{
    public class TenantUserRepository : GenericRepository<TenantUser>, ITenantUserRepository
    {
        public TenantUserRepository(MultiTenantJobTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
