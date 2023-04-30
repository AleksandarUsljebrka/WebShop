using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.DTO;

namespace WebShopBackend.Interface
{
    public interface IRegistrationService
    {
        public RegistrationDTO RegisterUser(RegistrationDTO registrationDTO);
        public string HashPassword(string password);
    }
}
