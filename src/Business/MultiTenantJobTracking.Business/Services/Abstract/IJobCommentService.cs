using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobCommentService
    {
        Task<IResponseResult> CreateJobComment(CreateJobCommentCommand createJobCommand);
        Task<IDataResult<List<JobCommentViewModel>>> GetJobCommentsByJobId(Guid jobId);

    }
}
