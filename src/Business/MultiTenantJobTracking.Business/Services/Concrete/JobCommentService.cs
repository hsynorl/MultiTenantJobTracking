using MultiTenantJobTracking.Business.Services.Abstract;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class JobCommentService : IJobCommentService
    {
        public Task<bool> CreateJobComment()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetJobCommentsByJobId(Guid jobId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetJobCommentsByUserId(Guid UserId)
        {
            throw new NotImplementedException();
        }
    }

}
