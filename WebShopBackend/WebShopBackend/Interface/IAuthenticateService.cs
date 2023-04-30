﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.DTO;

namespace WebShopBackend.Interface
{
    public interface IAuthenticateService
    {
        public string Authenticate(LoginDTO loginDTO);

    }
}
