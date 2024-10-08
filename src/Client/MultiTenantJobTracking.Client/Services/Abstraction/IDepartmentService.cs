﻿using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IDepartmentService
    {
        Task<IResponseResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<IDataResult<List<DepartmentViewModel>>> GetDepartmentsByTenantId(GetDepartmentsQuery getDepartmentsQuery);
    }
}
