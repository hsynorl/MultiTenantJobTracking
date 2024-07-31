using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.DataAccess.Repositories.Concrete
{
    public class LicenceRepository : GenericRepository<Licence>, ILicenceRepository
    {
        public LicenceRepository(MultiTenantJobTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
