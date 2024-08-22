using Microsoft.AspNetCore.Mvc;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class JobCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
