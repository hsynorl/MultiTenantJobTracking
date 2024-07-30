namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobCommentService
    {
        Task<bool> CreateJobComment();
        Task<bool> GetJobCommentsByJobId(Guid jobId);
        Task<bool> GetJobCommentsByUserId(Guid UserId);

    }
}
