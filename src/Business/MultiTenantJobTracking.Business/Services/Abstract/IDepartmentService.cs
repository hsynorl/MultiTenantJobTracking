using MultiTenantJobTracking.Common.Models.Depatment.Command;
using MultiTenantJobTracking.Common.Models.Depatment.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<List<DepartmentViewModel>> GetDepartments();

    }
}
