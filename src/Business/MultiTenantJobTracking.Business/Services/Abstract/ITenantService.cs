using MultiTenantJobTracking.Common.Models.Tenant.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface ITenantService
    {
        Task<bool> CreateTenant(CreateTenantCommand createTenantCommand);
        Task<bool> CheckLicenceExpireTime(Guid TenantId);
        Task<bool> UpdateLicence(UpdateTenantLicenceCommand updateTenantLicenceCommand);

    }


}
