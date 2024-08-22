using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class LicenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
