using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interface;
using WebShopBackend.DTO;
using WebShopBackend.Infrastructure;
using WebShopBackend.Model;

namespace WebShopBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        
        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("registration")]
        public IActionResult Register([FromBody] RegistrationDTO registrationDto)
        {
            try
            {
                string username = registrationDto.Username;
                string role = registrationDto.Role;
                if (_userService.UserExists(username, role))
                {
                    return BadRequest("Username already exists.");
                }

                var result = _userService.RegisterUser(registrationDto);

                if (result == null)
                {
                    return BadRequest("There was an error during registration.Result = null");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message+"--------"+ex.StackTrace+"--------"+ex.InnerException);
            }
        }

    }
}
