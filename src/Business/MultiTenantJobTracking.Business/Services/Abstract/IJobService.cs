using MultiTenantJobTracking.Common.Models.Job.Command;
using MultiTenantJobTracking.Common.Models.Job.Query;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobService
    {
        Task<bool> CreateJob(CreateJobCommand createJobCommand);
        Task<bool> UpdateJob(UpdateJobCommand updateJobCommand);
        Task<bool> DeleteJob(DeleteJobCommand deleteJobCommand);
        Task<bool> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand);

    }

}
