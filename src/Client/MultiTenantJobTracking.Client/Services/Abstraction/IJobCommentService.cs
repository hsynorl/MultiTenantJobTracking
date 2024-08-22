using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IJobCommentService
    {

        Task<IResponseResult> CreateJobComment(CreateJobCommentCommand createJobCommand);
        Task<IDataResult<List<JobCommentViewModel>>> GetJobCommentsByJobId(Guid jobId);
    }

}
