using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class LicenceService : ILicenceService
    {
        private readonly ILicenceRepository licenceRepository;

        public LicenceService(ILicenceRepository licenceRepository)
        {
            this.licenceRepository = licenceRepository;
        }

        public async Task<bool> CheckLicenceExpireTime(Guid UserId)
        {
            var result = await licenceRepository.GetSingleAsync(p => p.Id == UserId);
            if (result == null)
            {
                throw new Exception("Not Found");
            }
            if (result.ExpireDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
