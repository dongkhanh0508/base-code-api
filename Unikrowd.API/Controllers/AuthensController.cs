using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.DTOs.Responses;
using Unikrowd.Bussiness.Services;
using Unikrowd.Data.Entity;

namespace Unikrowd.API.Controllers
{
    namespace TradeMap.API.Controllers
    {
        [Route(Helpers.SettingVersionApi.ApiVersion)]
        [ApiController]
        public class AuthensController : ControllerBase
        {
            private readonly IAuthenService _authenService;
            private readonly IMapper _mapper;

            public AuthensController(IAuthenService authenService, IMapper mapper)
            {
                _authenService = authenService;
                _mapper = mapper;
            }

            /// <summary>
            /// Login with username and pasword
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>          
            [AllowAnonymous]
            [HttpPost("login")]
            public async Task<ActionResult<JwtResponse>> GetAccounts([FromBody] AuthenRequest request)
            {
                JwtResponse rs = await _authenService.Login(request);               
                return Ok(rs);
            }
        }
    }
 }
