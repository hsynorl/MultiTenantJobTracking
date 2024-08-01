using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobCommentService
    {
        Task<bool> CreateJobComment(CreateJobCommand createJobCommand);
        Task<List<JobCommentViewModel>> GetJobCommentsByJobId(Guid jobId);
        Task<List<JobCommentViewModel>> GetJobCommentsByUserId(Guid UserId);

    }
}
