using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interface;
using WebShopBackend.DTO;

namespace WebShopBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
           
            return Ok("Doesn't work yet");
        }
    }
}
