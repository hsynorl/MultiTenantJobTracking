using MultiTenantJobTracking.Common.Models.UserJob.Command;
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
    }
}
