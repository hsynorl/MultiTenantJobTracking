using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IJobCommentService
    {
        Task<IDataResult<List<JobCommentViewModel>>> GetJobComments();
    }

}
