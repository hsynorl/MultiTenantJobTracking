using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Tenant.Command;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService tenantService;

        public TenantsController(ITenantService tenantService)
        {
            this.tenantService = tenantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant(CreateTenantCommand createTenantCommand) {

            var result = await tenantService.CreateTenant();
            return Ok(result);
        }
    }
}
