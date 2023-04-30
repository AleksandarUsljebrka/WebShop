using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebShop.Interface;
using WebShopBackend.DTO;
using WebShopBackend.Interface;
using WebShopBackend.Model;

namespace WebShopBackend.Services
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly IConfigurationSection _secretKey;

        public AuthenticateService(IConfiguration config, IUserService userService)
        {
            _userService = userService;   
            _secretKey = config.GetSection("SecretKey");

        }
        public string Authenticate(LoginDTO loginDto)
        {
            User user;
            user = _userService.SearchUser(loginDto.Username);
            if (user == null)
                return null;

            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                List<Claim> claims = new List<Claim>();
               
                if (user is Admin)
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                if (user is Customer)
                    claims.Add(new Claim(ClaimTypes.Role, "customer")); 
                if (user is Salesman)
                    claims.Add(new Claim(ClaimTypes.Role, "salesman")); 

                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44398", //url servera koji je izdao token
                    claims: claims, 
                    expires: DateTime.Now.AddMinutes(20), 
                    signingCredentials: signinCredentials 
                );
                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            else
            {
                return null;
            }
        }
    }
}
