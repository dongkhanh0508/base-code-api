using AutoMapper;
using System;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.MapperViewModels;
using Unikrowd.Data.Entity;

namespace Unikrowd.API.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                // Account - authen
                CreateMap<Account, AccountViewModel>();
                CreateMap<Account, GenerateJwtModel>().ForMember(des => des.Name,
                act => act.MapFrom(src => src.Username));
                CreateMap<PostAccountRequest, Account>();
                CreateMap<PutAccountRequest, Account>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
            }
        }
    }
}