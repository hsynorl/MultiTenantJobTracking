using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface ILicenceService
    {
        Task<IResponseResult> CreateLicence(CreateLicenceCommand createLicenceCommand);
        Task<IResponseResult> RenewLicense(RenewLicenceCommand renewLicenceCommand);
    }
}
