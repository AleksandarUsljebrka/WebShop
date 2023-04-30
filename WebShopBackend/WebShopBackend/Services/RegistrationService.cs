using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShopBackend.DTO;
using WebShopBackend.Infrastructure;
using WebShopBackend.Interface;
using WebShopBackend.Model;

namespace WebShopBackend.Services
{
    public class RegistrationService:IRegistrationService
    {

        private readonly IMapper _mapper;
        private readonly WebShopDbContext _dbContext;
        private readonly IConfigurationSection _secretKey;
        public RegistrationService(IMapper mapper, WebShopDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _secretKey = config.GetSection("SecretKey");

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

        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

    }
}
