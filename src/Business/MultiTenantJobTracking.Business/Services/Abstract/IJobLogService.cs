using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.JobLog.Command;
using MultiTenantJobTracking.Common.Models.JobLog.Query;
using MultiTenantJobTracking.Common.Models.JobLog.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobLogService
    {
        Task<bool> CreateJobLog(CreateJobLogCommand createJobLogCommand);
        Task<List<GetJobLogsViewModel>> GetJobLogsByUserId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery);
        Task<List<GetJobLogsViewModel>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery);

    }

}
