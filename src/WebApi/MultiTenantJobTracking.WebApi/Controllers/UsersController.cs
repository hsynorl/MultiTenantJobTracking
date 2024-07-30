﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.User.Command;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await userService.CreateUser(createUserCommand);
            return Ok(result);  
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await userService.Login(loginCommand);
            return Ok(result);
        }
    }
}
