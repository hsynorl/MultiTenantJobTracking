using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface ITenantService
    {
        Task<IResponseResult> CreateTenant(CreateTenantCommand createTenantCommand);
    }
}
