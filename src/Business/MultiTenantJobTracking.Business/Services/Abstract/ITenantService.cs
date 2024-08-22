using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface ITenantService
    {
        Task<IResponseResult> CreateTenant(CreateTenantCommand createTenantCommand);
        Task<IDataResult<TenantViewModel>> GetTenantByTenantId(Guid TenantId);

    }


}
