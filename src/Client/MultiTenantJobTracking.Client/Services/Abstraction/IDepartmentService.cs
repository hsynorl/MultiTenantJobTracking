using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IDepartmentService
    {
        Task<IResponseResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
    }
}
