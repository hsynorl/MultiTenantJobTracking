using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class JobLogService : IJobLogService
    {
        private readonly HttpClient _httpClient;

        public JobLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogs()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByJobId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<GetJobLogsViewModel>>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery)
        {
            throw new NotImplementedException();
        }
    }





}
