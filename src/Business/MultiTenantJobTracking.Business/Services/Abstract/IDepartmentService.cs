using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<List<DepartmentViewModel>> GetDepartments(GetDepartmentsQuery getDepartmentsQuery);

    }
}
