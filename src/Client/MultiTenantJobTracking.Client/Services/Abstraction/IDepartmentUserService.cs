using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IDepartmentUserService
    {
        Task<IResponseResult> CreateUserDepartment(CreateDepartmentUserCommand createDepartmentUserCommand);
    }

}
