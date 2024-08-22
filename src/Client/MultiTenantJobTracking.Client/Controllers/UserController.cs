using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Client.Models;
using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace MultiTenantJobTracking.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            // Kullanıcının mevcut session'undan çıkış yap
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Kullanıcıyı başlangıç sayfasına yönlendir
            return RedirectToAction("Login", "User");
        }
        [AllowAnonymous]

        public async Task<IActionResult> Submit(LoginCommand loginCommand)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.Login(loginCommand);
                if (result is null)
                {
                    TempData["ToastMessage"] = "Girilen bilgileri kontrol ediniz";
                    TempData["IsError"] = true;
                    return RedirectToAction("Login");
                }
                var claims = new List<Claim>
                {
                     new Claim("Token", result.Result.Token)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = result.Result.TokenExpire
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

    }
}
