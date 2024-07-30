using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface ITenantService
    {
        Task<bool> CreateTenant();
        Task<bool> CheckLicenceExpireTime();
        Task<bool> UpdateLicence();

    }


}
