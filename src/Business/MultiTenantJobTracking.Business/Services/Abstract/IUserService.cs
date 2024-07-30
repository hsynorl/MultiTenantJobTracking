using MultiTenantJobTracking.Common.Models.User.Command;
using MultiTenantJobTracking.Common.Models.User.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserCommand createUserCommand);
        Task<LoginViewModel> Login(LoginCommand loginCommand);
        
    }


}
