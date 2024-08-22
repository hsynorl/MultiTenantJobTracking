using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
using System.Net.Http.Json;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand)
        {
            var response = await _httpClient.PostAsJsonAsync("Users/login", loginCommand);
            var loginViewModel = await response.Content.ReadFromJsonAsync<DataResult<LoginViewModel>>();
            return loginViewModel;
        }
        public async Task<IResponseResult> Logout()
        {
            return new ErrorResult();

        }
    }


}
