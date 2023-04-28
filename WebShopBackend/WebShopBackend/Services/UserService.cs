using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShop.Interface;
using WebShopBackend.DTO;
using WebShopBackend.Infrastructure;
using WebShopBackend.Model;

namespace WebShopBackend.Services
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly WebShopDbContext _dbContext;
        public UserService(IMapper mapper, WebShopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public bool UserExists(string username, string role)
        {
            if(role.Contains("Customer"))
                return _dbContext.Customers.Any(c => c.Username == username);
            else if(role.Contains("Salesman"))
                return _dbContext.Salesmen.Any(s => s.Username == username);
            return false;
        }
        public RegistrationDTO RegisterUser(RegistrationDTO registrationDTO)
        {
            
                if (registrationDTO.Role.Contains("Customer"))
                {
                    Customer customer = _mapper.Map<Customer>(registrationDTO);
                    customer.Password = HashPassword(customer.Password);
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                    return _mapper.Map<RegistrationDTO>(registrationDTO);
                }
                else if (registrationDTO.Role.Contains("Salesman"))
                {
                    Salesman salesman = _mapper.Map<Salesman>(registrationDTO);
                    salesman.Password = HashPassword(salesman.Password);
                    _dbContext.Salesmen.Add(salesman);
                    _dbContext.SaveChanges();
                    return _mapper.Map<RegistrationDTO>(registrationDTO);
                }
                else
                {
                    throw new Exception("Invalid role specified.");
                }
           
        }

        public  string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
       
    }
}
