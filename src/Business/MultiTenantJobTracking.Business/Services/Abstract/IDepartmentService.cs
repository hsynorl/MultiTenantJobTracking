using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<IDataResult<List<DepartmentViewModel>>> GetDepartmentsByTenantId(GetDepartmentsQuery getDepartmentsQuery);

    }
}
