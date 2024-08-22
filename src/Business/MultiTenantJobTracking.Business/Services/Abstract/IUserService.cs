using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IResponseResult> CreateUser(CreateUserCommand createUserCommand);
        Task<IResponseResult> CreateTenantAdminUser(CreateTenantAdminUserCommand createTenantAdminUserCommand);
        Task<IResponseResult> CreateDepartmentAdminUser(CreateDepartmentAdminUserCommand createDepartmentAdminUserCommand);
        Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand);
        
    }


}
