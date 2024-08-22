using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobLogService
    {
        Task<bool> CreateJobLog(CreateJobLogCommand createJobLogCommand);
        Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByJobId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery);
        Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery);

    }

}
