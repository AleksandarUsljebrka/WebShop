using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.DTO;

namespace WebShop.Interface
{
    public interface IUserService
    {
        public bool UserExists(string username, string role);
        public RegistrationDTO RegisterUser(RegistrationDTO registrationDTO);
        public string HashPassword(string password);
    }
}
