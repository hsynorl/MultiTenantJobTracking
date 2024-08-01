using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Commands;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantUsersController : ControllerBase
    {
        private readonly ITenantUserService tenantUserService;

        public TenantUsersController(ITenantUserService tenantUserService)
        {
            this.tenantUserService = tenantUserService;
        }
        [HttpPost("create-tenant-user")]
        public async Task<IActionResult> CreateTenantUser(CreateTenantUserCommand createTenantUserCommand)
        {
            var result=await tenantUserService.CreateTenantUser(createTenantUserCommand);
            return Ok(result);
        }
    }
}
