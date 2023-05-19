﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly IConfigurationSection _secretKey;
        public UserService(IMapper mapper, WebShopDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _secretKey = config.GetSection("SecretKey");

        }
     

        public LoginDTO SearchUser(string username)
        {
            LoginDTO loginDtoBack = new LoginDTO();
            loginDtoBack.Password = null;
            loginDtoBack.Username = null;

            var customer = _dbContext.Customers.FirstOrDefault(c => c.Username == username);
            var salesman = _dbContext.Salesmen.FirstOrDefault(s => s.Username == username);
            var admin = _dbContext.Admins.FirstOrDefault(a => a.Username == username);

            if (customer != null)
            {
                loginDtoBack.Password = customer.Password;
                loginDtoBack.Username = customer.Username;
            }
            if (salesman != null)
            {
                loginDtoBack.Password = salesman.Password;
                loginDtoBack.Username = salesman.Username;
            }
            if (admin != null)
            {
                loginDtoBack.Password = admin.Password;
                loginDtoBack.Username = admin.Username;
            }

            return loginDtoBack;

        }
        public bool UserExists(string username, string role)
        {
            if (role.Contains("Customer"))
                return _dbContext.Customers.Any(c => c.Username == username);
            else if (role.Contains("Salesman"))
                return _dbContext.Salesmen.Any(s => s.Username == username);
            return false;
        }
    }
}
