using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentAdminsController : ControllerBase
    {
        private readonly IDepartmentAdminService departmentAdminService;

        public DepartmentAdminsController(IDepartmentAdminService departmentAdminService)
        {
            this.departmentAdminService = departmentAdminService;
        }

        [HttpPost("create-department-admin")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]

        public async Task<IActionResult> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand)
        {
            var result=await departmentAdminService.CreateDepartmentAdmin(createDepartmentAdminCommand);
            return Ok(result);
        }

    }
}
