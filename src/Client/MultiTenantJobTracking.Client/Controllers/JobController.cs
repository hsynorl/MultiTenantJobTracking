using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
