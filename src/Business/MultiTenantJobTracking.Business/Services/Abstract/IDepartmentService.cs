using MultiTenantJobTracking.Common.Models.Department.Command;
using MultiTenantJobTracking.Common.Models.Department.Query;
using MultiTenantJobTracking.Common.Models.Department.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<List<DepartmentViewModel>> GetDepartments(GetDepartmentsQuery getDepartmentsQuery);

    }
}
