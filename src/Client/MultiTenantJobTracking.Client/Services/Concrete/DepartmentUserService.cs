using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class DepartmentUserService : IDepartmentUserService
    {
        private readonly HttpClient _httpClient;

        public DepartmentUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateUserDepartment(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            throw new NotImplementedException();
        }
    }
}
