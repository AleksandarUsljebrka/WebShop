using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.DTO;
using WebShopBackend.Model;

namespace WebShopBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, RegistrationDTO>().ReverseMap();
            CreateMap<Salesman, RegistrationDTO>().ReverseMap();

        }
    }
}
