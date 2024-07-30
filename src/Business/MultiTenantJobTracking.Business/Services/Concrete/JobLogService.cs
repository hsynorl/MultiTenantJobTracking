using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class JobLogService : IJobLogService
    {
        public Task<bool> CreateJobLog()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetAllJobLogs()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetJobLogsByUserId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetJobLogsFilterJobStatus(JobStatus jobStatus)
        {
            throw new NotImplementedException();
        }
    }



}
