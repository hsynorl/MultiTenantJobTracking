using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class TenantUserService : ITenantUserService
    {
        private readonly HttpClient _httpClient;

        public TenantUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateTenantUser(CreateTenantUserCommand createTenantCommand)
        {
            throw new NotImplementedException();
        }
    }


}
