using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikrowd.API.Helpers;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.Exceptions;
using Unikrowd.Bussiness.MapperViewModels;
using Unikrowd.Bussiness.Services;
using Unikrowd.Data.Entity;
using static Unikrowd.Bussiness.CommonModels.CommonEnums;

namespace Unikrowd.API.Controllers
{
    namespace TradeMap.API.Controllers
    {
        [Route(SettingVersionApi.ApiVersion)]
        [ApiController]
        public class AccountsController : ControllerBase
        {
            private readonly IAccountService _accountService;         

            public AccountsController(IAccountService accountService, IMapper mapper)
            {
                _accountService = accountService;              
            }

            /// <summary>
            /// Get Account
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<AccountViewModel>>> GetAccounts([FromQuery] PagingRequest request)
            {               
                var rs =await _accountService.GetAllPaging(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get Account By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpGet("{id}")]
            public async Task<ActionResult<AccountViewModel>> GetAccountById(int id)
            {
                var rs = await _accountService.GetAccountById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new account
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPost]
            public async Task<ActionResult<AccountViewModel>> PostAccount([FromBody] PostAccountRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _accountService.PostAccount(model, userId);
                try
                {                  
                    await _accountService.SaveAsync();
                    return Ok(rs);
                }
                catch(Exception e)
                {
                    if ((bool)(e.InnerException?.Message.Contains("duplicate")))
                    {
                        throw new CustomException(HttpStatusCode.Conflict, GeneralMessages.Duplicate, "");
                    }
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
               
            }
            /// <summary>
            /// Update account
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPut("{id}")]
            public async Task<ActionResult<AccountViewModel>> PutAccount(int id,[FromBody] PutAccountRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _accountService.UpdateAccount(id, model, userId);
                    await _accountService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {
                    if ((bool)(e.InnerException?.Message.Contains("duplicate")))
                    {
                        throw new CustomException(HttpStatusCode.Conflict, GeneralMessages.Duplicate, "");
                    }
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
                
            }
            /// <summary>
            /// Delete account
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<AccountViewModel>> DeleteAccount(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _accountService.DeleteAccount(id);
                    await _accountService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }

            }
        }
    }
 }
