using MultiTenantJobTracking.Client.Services.Abstraction;
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
    }





}
