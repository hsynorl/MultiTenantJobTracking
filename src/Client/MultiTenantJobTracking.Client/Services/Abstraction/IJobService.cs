using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IJobService
    {
        Task<IResponseResult> CreateJob(CreateJobCommand createJobCommand);
        Task<IResponseResult> UpdateJob(UpdateJobCommand updateJobCommand);
    }

}
