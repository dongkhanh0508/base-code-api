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
                // Investor
                CreateMap<Investor, InvestorViewModel>();
                CreateMap<PostInvestorRequest, Investor>();
                CreateMap<PutInvestorRequest, Investor>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Business
                CreateMap<Investor, InvestorViewModel>();
                CreateMap<PostInvestorRequest, Investor>();
                CreateMap<PutInvestorRequest, Investor>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Campaign
                CreateMap<Campaign, CampaignViewModel>();
                CreateMap<PostCampaignRequest, Campaign>();
                CreateMap<PutCampaignRequest, Campaign>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Document
                CreateMap<Document, DocumentViewModel>();
                CreateMap<PostDocumentRequest, Document>();
                CreateMap<PutDocumentRequest, Document>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Free
                CreateMap<Fee, FeeViewModel>();
                CreateMap<FeeRequest, Fee>();
                CreateMap<FeeRequest, Fee>().ForMember(des => des.UpdateAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Industry
                CreateMap<Industry, IndustryViewModel>();
                CreateMap<IndustryRequest, Industry>();
                CreateMap<IndustryRequest, Industry>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Location
                CreateMap<Location, LocationViewModel>();
                CreateMap<LocationRequest, Location>();
                CreateMap<LocationRequest, Location>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // News
                CreateMap<News, NewsViewModel>();
                CreateMap<NewsRequest, News>();
                CreateMap<NewsRequest, News>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
                // Payment
                CreateMap<Payment, PaymentViewModel>();
                CreateMap<PaymentRequest, Payment>();
                CreateMap<PaymentRequest, Payment>().ForMember(des => des.UpdatedAt, act => act.MapFrom(src => DateTime.UtcNow.AddHours(7))).ReverseMap();
            }
        }
    }
}