using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.DTO;
using WebShopBackend.Model;

namespace WebShop.Interface
{
    public interface IUserService
    {
        public bool UserExists(string username, string role);
        public LoginDTO SearchUser(string username);
    }
}
