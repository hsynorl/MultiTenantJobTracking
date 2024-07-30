namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentUserService
    {
        Task<bool> CreateDepartmentUser();
        Task<bool> DeleteDepartmentUser();
        Task<bool> UpdateDepartmentUser();
        Task<bool> GetDepartmentUsers(Guid DepartmentId);

    }

}
