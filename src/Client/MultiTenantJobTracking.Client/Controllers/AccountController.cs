using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Client.Models;
using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using System.Diagnostics;
using System.Reflection;

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

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Submit(LoginCommand loginCommand)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.Login(loginCommand);
                if (result is null)
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

    }
}
