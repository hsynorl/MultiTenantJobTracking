using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface ITenantUserService
    {
        public Task<IResponseResult> CreateTenantUser(CreateTenantUserCommand createTenantCommand);
    }
}
