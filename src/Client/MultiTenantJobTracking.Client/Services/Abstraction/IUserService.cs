using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IUserService
    {
        Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand);   
        Task<IResponseResult> Logout();
        Task<IResponseResult> CreateUser(CreateUserCommand createUserCommand);
    }
}
