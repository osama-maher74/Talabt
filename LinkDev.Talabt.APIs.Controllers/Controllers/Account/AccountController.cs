using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.APIs.Controllers.Base;
using LinkDev.Talabat.Application.Abstraction.Models.Auth;
using LinkDev.Talabat.Application.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabt.APIs.Controllers.Controllers.Account
{
    public class AccountController:BaseApiController
    {
        private readonly IServiceManger serviceManger;

        public AccountController(IServiceManger serviceManger)
        {
            this.serviceManger = serviceManger;
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await serviceManger.AuthService.LoginAsync(loginDto);
         
            return Ok(user);
        }
        [HttpPost("register")]
        public async  Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await serviceManger.AuthService.RegisterAsync(registerDto);
            return Ok(user);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await serviceManger.AuthService.GetCurrentUser(User);
            return Ok(user);
        }

    }
}
