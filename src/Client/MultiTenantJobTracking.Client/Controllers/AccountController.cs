using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Client.Models;
using MultiTenantJobTracking.Client.Services.Abstraction;
using System.Diagnostics;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public async Task<IActionResult> Login()
        {
            var result = await userService.Login(new()
            {
                EmailAddress = "string",
                Password="string"
            
            }) ;
            var sdasd = result;
            return View();
        }
    }
}
