using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobLogService
    {
        Task<bool> CreateJobLog();
        Task<bool> GetAllJobLogs();
        Task<bool> GetJobLogsByUserId();
        Task<bool> GetJobLogsFilterJobStatus(JobStatus jobStatus);

    }

}
