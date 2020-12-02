using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.WebApi.ViewModels.Account;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.WebApi.Mapper
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<IdentityUser<int>, RegisterViewModel>().ReverseMap();
        }
    }
}
