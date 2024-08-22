using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class JobLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
