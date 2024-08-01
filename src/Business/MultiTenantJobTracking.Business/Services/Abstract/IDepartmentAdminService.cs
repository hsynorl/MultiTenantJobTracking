using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentAdminService
    {
        Task<bool> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand);
        Task<bool> UpdateDepartmentAdmin(UpdateDepartmentAdminCommand updateDepartmentAdminCommand);
        Task<bool> DeleteDepartmentAdmin(DeleteDepartmentAdminCommand deleteDepartmentAdminCommand);
        Task<List<DepartmentAdminViewModel>> GetDepartmentAdminsByDepartmentId(GetDepartmentAdminsByDepartmentIdQuery getDepartmentAdminsByDepartmentIdQuery);
    }

}
