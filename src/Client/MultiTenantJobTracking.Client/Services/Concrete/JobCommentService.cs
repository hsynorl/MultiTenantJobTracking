using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class JobCommentService : IJobCommentService
    {
        private readonly HttpClient _httpClient;

        public JobCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IDataResult<List<JobCommentViewModel>>> GetJobComments()
        {
            throw new NotImplementedException();
        }
    }





}
