using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Department.Command;
using MultiTenantJobTracking.Common.Models.Department.Query;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("get-departments")]
        public async Task<IActionResult> GetDepartments([FromQuery]Guid TenantId) {

            var result = await departmentService.GetDepartments(new GetDepartmentsQuery { TenantId=TenantId});
            return Ok(result);
        }


        [HttpPost("create-department")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {

            var result = await departmentService.CreateDepartment(createDepartmentCommand);
            return Ok(result);
        }

    }
}
