using MultiTenantJobTracking.Common.Models.DepartmentUser.Command;
using MultiTenantJobTracking.Common.Models.DepartmentUser.ViewModel;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentUserService
    {
        Task<bool> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand);
        Task<bool> DeleteDepartmentUser(Guid UserId);
        Task<DepartmentUserViewModel> GetDepartmentUsers(Guid UserId);

    }

}
