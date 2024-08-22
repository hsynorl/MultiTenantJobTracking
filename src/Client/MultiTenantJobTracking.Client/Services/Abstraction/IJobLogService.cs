using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IJobLogService
    {
        Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByJobId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery);
        Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery);
    }

}
