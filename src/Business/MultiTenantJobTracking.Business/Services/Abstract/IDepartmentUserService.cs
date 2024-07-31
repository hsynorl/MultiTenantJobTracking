using MultiTenantJobTracking.Common.Models.Department.ViewModel;
using MultiTenantJobTracking.Common.Models.DepartmentUser.Command;
using MultiTenantJobTracking.Common.Models.DepartmentUser.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentUserService
    {
        Task<bool> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand);
        Task<DepartmentViewModel> GetUserDepartment(Guid UserId);

    }

}
