using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interface;
using WebShopBackend.DTO;
using WebShopBackend.Interface;

namespace WebShopBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticateService _authService;
        public LoginController(IAuthenticateService authService, IUserService userService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            var token = _authService.Authenticate(loginDto);
            if (token == null)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }
            return Ok(new { token });
        }

    }
}
