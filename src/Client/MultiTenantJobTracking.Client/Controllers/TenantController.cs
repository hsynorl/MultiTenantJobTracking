using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class TenantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
