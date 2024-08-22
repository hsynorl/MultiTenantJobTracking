using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class DepartmentUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
