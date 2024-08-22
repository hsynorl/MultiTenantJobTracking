using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentUserService
    {
        Task<IResponseResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand);
        Task<IDataResult<DepartmentViewModel>> GetUserDepartment(Guid UserId);
        Task<IDataResult<List<UserViewModel>>> GetUsersByDepartmentId(Guid DepartmentId);
        Task<IResponseResult> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand);

       
    }

}
