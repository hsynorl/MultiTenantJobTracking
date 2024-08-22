using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public partial class UserJobService : IUserJobService
    {
        private readonly HttpClient _httpClient;

        public UserJobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateUserJob()
        {
            throw new NotImplementedException();
        }

    }
}
