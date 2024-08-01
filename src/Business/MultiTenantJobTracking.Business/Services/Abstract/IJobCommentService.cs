using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobCommentService
    {
        Task<bool> CreateJobComment(CreateJobCommentCommand createJobCommand);
        Task<List<JobCommentViewModel>> GetJobCommentsByJobId(Guid jobId);
        Task<List<JobCommentViewModel>> GetJobCommentsByUserId(Guid UserId);

    }
}
