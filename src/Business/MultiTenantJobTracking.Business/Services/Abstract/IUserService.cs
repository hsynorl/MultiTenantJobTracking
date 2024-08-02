using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserCommand createUserCommand);
        Task<bool> CreateTenantAdminUser(CreateTenantAdminUserCommand createTenantAdminUserCommand);
        Task<bool> CreateDepartmentAdminUser(CreateDepartmentAdminUserCommand createDepartmentAdminUserCommand);
        Task<LoginViewModel> Login(LoginCommand loginCommand);
        Task<List<UserViewModel>> GetUsersWithoutDepartments(Guid TenantId);

        
    }


}
