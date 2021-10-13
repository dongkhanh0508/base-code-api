using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikrowd.API.Models;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.Services;
using Unikrowd.Data.Entity;

namespace Unikrowd.API.Controllers
{
    namespace TradeMap.API.Controllers
    {
        [Route(Helpers.SettingVersionApi.ApiVersion)]
        [ApiController]
        public class AccountsController : ControllerBase
        {
            private readonly IAccountService _accountService;
            private readonly IMapper _mapper;

            public AccountsController(IAccountService accountService, IMapper mapper)
            {
                _accountService = accountService;
                _mapper = mapper;
            }

            /// <summary>
            /// Get Account
            /// </summary>
            /// <returns></returns>
            //[Authorize(Roles = Role.Brand + "," + Role.Admin)]
            [AllowAnonymous]
            [HttpGet]
            public async Task<ActionResult<PagedResults<AccountViewModel>>> GetAccounts([FromQuery] PagingRequest request)
            {               
                var query =await _accountService.GetAllPaging(request);                
                var rs = new PagedResults<AccountViewModel>
                {
                    PageSize = query.PageSize,
                    Results = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountViewModel>>(query.Results),
                    PageNumber = query.PageNumber,
                    TotalNumberOfPages = query.TotalNumberOfPages,
                    TotalNumberOfRecords = query.TotalNumberOfRecords
                };
                return Ok(rs);
            }
        }
    }
 }
