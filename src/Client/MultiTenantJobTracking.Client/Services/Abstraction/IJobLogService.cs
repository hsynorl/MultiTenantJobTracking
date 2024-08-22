using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IJobLogService
    {
        Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogs();
    }

}
