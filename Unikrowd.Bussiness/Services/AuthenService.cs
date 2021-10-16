using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.DTOs.Responses;
using Unikrowd.Bussiness.Exceptions;
using Unikrowd.Bussiness.Utils;
using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;
using Unikrowd.Data.Repositories;

namespace Unikrowd.Bussiness.Services
{
    public interface IAuthenService
    {
        Task<JwtResponse> Login(AuthenRequest request);

        // Task<JwtResponse> Lo(AuthenRequest request);
    }

    public class AuthenService : IAuthenService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthenService(IAccountRepository _accountRepository, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            this._accountRepository = _accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public async Task<JwtResponse> Login(AuthenRequest request)
        {
            var account = await _accountRepository.GetSingleByConditionAsync(x => x.Username == request.Username);
            if (account != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(request.Password, account.Password);
                if (!verified) throw new CustomException(HttpStatusCode.Unauthorized, GeneralMessages.Unauthorized, "");
                var jwtModel = _mapper.Map<Account, GenerateJwtModel>(account);
                string jwt = JwtHelper.GenerateJwtTokenAgent(jwtModel, _config["AppSettings:Secret"], _config["AppSettings:Issuer"]);
                return new JwtResponse
                {
                    Token = jwt,
                    RefestToken = "not impl"
                };
            }
            else
            {
                throw new CustomException(HttpStatusCode.Unauthorized, GeneralMessages.Unauthorized, "");
            }
        }
    }
}