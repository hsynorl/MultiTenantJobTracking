using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserJobService
    {
        Task<bool> CreateUserJob(CreateUserJobCommand createUserJobCommand);
        Task<List<JobViewModel>> GetUserJobsByUserId(GetUserJobsByUserIdQuery getUserJobsByUserIdQuery);
    }
}
