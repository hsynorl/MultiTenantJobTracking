using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
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

        public async Task<LoginViewModel> Login(LoginCommand loginCommand)
        {
            var response = await _httpClient.PostAsJsonAsync("Users/login", loginCommand);

            if (response.IsSuccessStatusCode)
            {
                var loginViewModel = await response.Content.ReadFromJsonAsync<LoginViewModel>();

                if (loginViewModel != null && !String.IsNullOrEmpty(loginViewModel.Token))
                {
                    return loginViewModel;
                }
            }
            return null;
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
