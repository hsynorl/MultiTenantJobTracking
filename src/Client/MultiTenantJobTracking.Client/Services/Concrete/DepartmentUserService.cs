using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
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

        public Task<IResponseResult> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseResult> CreateUserDepartment(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmentViewModel>> GetUserDepartment(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<UserViewModel>>> GetUsersByDepartmentId(Guid DepartmentId)
        {
            throw new NotImplementedException();
        }
    }
}
