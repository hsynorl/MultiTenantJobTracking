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

    public class DepartmentUsersController : ControllerBase
    {
        private readonly IDepartmentUserService departmentUserService;

        public DepartmentUsersController(IDepartmentUserService departmentUserService)
        {
            this.departmentUserService = departmentUserService;
        }

        [HttpPost("create-department-user")]
        [Authorize(nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            var result=await departmentUserService.CreateDepartmentUser(createDepartmentUserCommand);
            return Ok(result);
        }
        
        [HttpGet("get-department-user")]
        public async Task<IActionResult> GetUserDepartment([FromQuery] Guid UserId)
        {
            var result = await departmentUserService.GetUserDepartment(UserId);
            return Ok(result);
        }

    }
}
