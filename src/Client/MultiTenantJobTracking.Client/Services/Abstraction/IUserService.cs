using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IUserService
    {
        Task<LoginViewModel> Login(LoginCommand loginCommand);   
        Task<bool> Logout();   
    }
}
