using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IUserJobService
    {
        Task<IResponseResult> CreateUserJob();
    }
}
