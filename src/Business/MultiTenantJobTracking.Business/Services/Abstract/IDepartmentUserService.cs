using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentUserService
    {
        Task<bool> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand);
        Task<DepartmentViewModel> GetUserDepartment(Guid UserId);
        Task<List<UserViewModel>> GetUsersByDepartmentId(Guid DepartmentId);

    }

}
