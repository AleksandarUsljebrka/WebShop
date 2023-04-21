using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopBackend.Model
{
    public enum UserType {ADMIN, CUSTOMER, SALESMAN };
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public UserType Type { get; set; }
    }
}
