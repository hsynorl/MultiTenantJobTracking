using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobService
    {
        Task<bool> CreateJob(CreateJobCommand createJobCommand);
        Task<bool> UpdateJob(UpdateJobCommand updateJobCommand);
        Task<bool> DeleteJob(DeleteJobCommand deleteJobCommand);
        Task<bool> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand);
        Task<JobViewModel> GetJobsByUserId(Guid userId);
    }

}
