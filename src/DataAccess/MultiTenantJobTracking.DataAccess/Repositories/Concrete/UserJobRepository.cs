using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.DataAccess.Repositories.Concrete
{
    public class UserJobRepository : GenericRepository<UserJob>, IUserJobRepository
    {
        public UserJobRepository(MultiTenantJobTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
