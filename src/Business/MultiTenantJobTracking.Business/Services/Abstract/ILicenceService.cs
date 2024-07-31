using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface ILicenceService
    {
        Task<bool> CheckLicenceExpireTime(Guid UserId);

    }
}
