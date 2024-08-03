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
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            var result=await departmentUserService.CreateDepartmentUser(createDepartmentUserCommand);
            return Ok(result);
        }

        [HttpGet("get-department-user")]
        [Authorize(Roles = $"{nameof(UserType.User)},{nameof(UserType.DepartmanAdmin)},{nameof(UserType.TenantAdmin)}")]
        public async Task<IActionResult> GetUserDepartment([FromQuery] Guid UserId)
        {
            var result = await departmentUserService.GetUserDepartment(UserId);
            return Ok(result);
        }
        [HttpGet("get-users-by-department-id")]
        [Authorize(Roles = $"{nameof(UserType.TenantAdmin)},{nameof(UserType.DepartmanAdmin)}")]
        public async Task<IActionResult> GetUsersByDepartmentId([FromQuery] Guid DepartmentId)
        {
            var result = await departmentUserService.GetUsersByDepartmentId(DepartmentId);
            return Ok(result);
        }
    }
}
