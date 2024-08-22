using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobService
    {
        Task<IResponseResult> CreateJob(CreateJobCommand createJobCommand);
        Task<IResponseResult> UpdateJob(UpdateJobCommand updateJobCommand);
        Task<IResponseResult> DeleteJob(DeleteJobCommand deleteJobCommand);
        Task<IResponseResult> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand);
        Task<IDataResult<List<JobViewModel>>> GetJobsByUserId(Guid userId);
    }

}
