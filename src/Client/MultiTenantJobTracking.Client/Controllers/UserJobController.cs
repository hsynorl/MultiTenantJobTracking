using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class UserJobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
