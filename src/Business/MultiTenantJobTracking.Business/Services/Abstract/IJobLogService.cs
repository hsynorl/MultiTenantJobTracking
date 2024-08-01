using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobLogService
    {
        Task<bool> CreateJobLog(CreateJobLogCommand createJobLogCommand);
        Task<List<GetJobLogsViewModel>> GetJobLogsByJobId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery);
        Task<List<GetJobLogsViewModel>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery);

    }

}
