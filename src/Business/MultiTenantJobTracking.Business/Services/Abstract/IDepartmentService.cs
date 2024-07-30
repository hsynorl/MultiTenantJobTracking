namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment();
        Task<bool> GetDepartments();

    }
}
