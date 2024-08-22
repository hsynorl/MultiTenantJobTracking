using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class TenantUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
