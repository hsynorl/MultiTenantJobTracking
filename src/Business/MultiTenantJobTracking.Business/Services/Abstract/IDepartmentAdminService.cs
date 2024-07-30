using MultiTenantJobTracking.Common.Models.DepartmentAdmin.Command;
using MultiTenantJobTracking.Common.Models.DepartmentAdmin.Query;
using MultiTenantJobTracking.Common.Models.DepartmentAdmin.ViewModel;

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
