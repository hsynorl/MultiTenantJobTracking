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

    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("create-user")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await userService.CreateUser(createUserCommand);
            return Ok(result);  
        }
        [HttpPost("create-tenant-admin-user")]
        [Authorize(Roles = nameof(UserType.GeneralAdmin))]
        public async Task<IActionResult> CreateTenantAdminUser(CreateTenantAdminUserCommand createTenantAdminUserCommand)
        {
            var result = await userService.CreateTenantAdminUser(createTenantAdminUserCommand);
            return Ok(result);
        }

        [HttpPost("create-department-admin-user")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateDepartmentAdminUser(CreateDepartmentAdminUserCommand createDepartmentAdminUserCommand)
        {
            var result = await userService.CreateDepartmentAdminUser(createDepartmentAdminUserCommand);
            return Ok(result);
        }
        [HttpGet("get-users-without-departments")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> GetUsersWithoutDepartments([FromQuery] Guid TenantId)
        {
            var result = await userService.GetUsersWithoutDepartments(TenantId);
            return Ok(result);
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await userService.Login(loginCommand);
            return Ok(result);
        }
    }
}
