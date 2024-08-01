using MultiTenantJobTracking.Common.Models.Commands;
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
        Task<bool> CreateLicence(CreateLicenceCommand createLicenceCommand);
        Task<bool> RenewLicense(RenewLicenceCommand renewLicenceCommand);
    }
}
