using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
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

        public Task<IResponseResult> CreateJobComment(CreateJobCommentCommand createJobCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<JobCommentViewModel>>> GetJobCommentsByJobId(Guid jobId)
        {
            throw new NotImplementedException();
        }
    }





}
