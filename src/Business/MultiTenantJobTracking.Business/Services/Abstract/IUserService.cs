namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser();
        Task<bool> DeleteUser();
        Task<bool> UpdateUser();
        Task<bool> Login();
        Task<bool> ResetPassword();
        
    }


}
