using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Unikrowd.API.Models;
using Unikrowd.Data.Entity;

namespace Unikrowd.API.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {

                CreateMap<Account, AccountViewModel>();               
            }
        }
    }
}
