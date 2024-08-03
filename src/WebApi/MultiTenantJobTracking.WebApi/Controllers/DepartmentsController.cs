using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("get-departments")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> GetDepartments([FromQuery]Guid TenantId) {

            var result = await departmentService.GetDepartmentsByTenantId(new GetDepartmentsQuery { TenantId=TenantId});
            return Ok(result);
        }


        [HttpPost("create-department")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {

            var result = await departmentService.CreateDepartment(createDepartmentCommand);
            return Ok(result);
        }

    }
}
