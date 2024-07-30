using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> CreateUser()
        {
            var result = await userRepository.AddAsync(new()
            {
                FirstName="Test",
                LastName="Test",
                IsActive=true,
                Password="Test",
                PhoneNumber="Test",
                EmailAddress= "Test",
                UserType=Common.Enums.UserType.GeneralAdmin,
            });
            return result > 0;
        }

        public Task<bool> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
