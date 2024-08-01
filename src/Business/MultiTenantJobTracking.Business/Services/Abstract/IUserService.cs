using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserCommand createUserCommand);
        Task<LoginViewModel> Login(LoginCommand loginCommand);
        
    }


}
