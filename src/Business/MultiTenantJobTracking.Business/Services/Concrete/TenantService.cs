using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class TenantService:ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public Task<bool> CheckLicenceExpireTime()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateTenant()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLicence()
        {
            throw new NotImplementedException();
        }
    }


}
