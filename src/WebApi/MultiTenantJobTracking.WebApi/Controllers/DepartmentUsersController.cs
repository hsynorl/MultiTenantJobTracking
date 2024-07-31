using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.DepartmentUser.Command;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentUsersController : ControllerBase
    {
        private readonly IDepartmentUserService departmentUserService;

        public DepartmentUsersController(IDepartmentUserService departmentUserService)
        {
            this.departmentUserService = departmentUserService;
        }

        [HttpPost("create-department-user")]
        public async Task<IActionResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            var result=await departmentUserService.CreateDepartmentUser(createDepartmentUserCommand);
            return Ok(result);
        }
        
        [HttpGet("get-department-user")]
        public async Task<IActionResult> GetDepartmentUser([FromQuery] Guid UserId)
        {
            var result = await departmentUserService.GetDepartmentUsers(UserId);
            return Ok(result);
        }

    }
}
