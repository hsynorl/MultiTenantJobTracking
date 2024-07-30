namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentAdminService
    {
        Task<bool> CreateDepartmentAdmin();
        Task<bool> UpdateDepartmentAdmin();
        Task<bool> DeleteDepartmentAdmin();
        Task<bool> GetDepartmentAdminsByDepartmentId();
    }

}
