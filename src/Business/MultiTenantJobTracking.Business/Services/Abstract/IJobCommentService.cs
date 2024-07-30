using MultiTenantJobTracking.Common.Models.Job.Command;
using MultiTenantJobTracking.Common.Models.JobComment.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobCommentService
    {
        Task<bool> CreateJobComment(CreateJobCommand createJobCommand);
        Task<List<JobCommentViewModel>> GetJobCommentsByJobId(Guid jobId);
        Task<List<JobCommentViewModel>> GetJobCommentsByUserId(Guid UserId);

    }
}
