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

    public class LicencesController : ControllerBase
    {
        private readonly ILicenceService licenceService;

        public LicencesController(ILicenceService licenceService)
        {
            this.licenceService = licenceService;
        }


        [HttpPost("create-licence")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> CreateLicence([FromQuery]Guid TenantId, [FromQuery]LicenceTime licenceTime)
        {
            var result=await licenceService.CreateLicence(new CreateLicenceCommand { LicenceTime=licenceTime,TenantId=TenantId});    
            return Ok(result);
        }
        [HttpPost("renew-licence")]
        [Authorize(Roles = nameof(UserType.TenantAdmin))]
        public async Task<IActionResult> RenewLicense([FromQuery] Guid TenantId, [FromQuery] LicenceTime licenceTime)
        {
            var result = await licenceService.RenewLicense(new()
            {
                TenantId=TenantId,
                LicenceTime=licenceTime
            });
            return Ok(result);
        }
    }
}
