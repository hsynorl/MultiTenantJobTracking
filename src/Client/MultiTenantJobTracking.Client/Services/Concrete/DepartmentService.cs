using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            throw new NotImplementedException();
        }
    }
}
