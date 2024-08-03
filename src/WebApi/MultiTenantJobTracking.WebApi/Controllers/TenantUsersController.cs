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
    public class TenantUsersController : ControllerBase
    {
        private readonly ITenantUserService tenantUserService;

        public TenantUsersController(ITenantUserService tenantUserService)
        {
            this.tenantUserService = tenantUserService;
        }
        [HttpPost("create-tenant-admin")]
        [Authorize(Roles = nameof(UserType.GeneralAdmin))]
        public async Task<IActionResult> CreateTenantUser([FromQuery]Guid TenantId, [FromQuery]Guid UserId)
        {
            var result=await tenantUserService.CreateTenantUser(new CreateTenantUserCommand
            {
                TenantId=TenantId,
                UserId=UserId
            });
            return Ok(result);
        }
    }
}
