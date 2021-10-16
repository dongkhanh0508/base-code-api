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
        public class InvestorsController : ControllerBase
        {
            private readonly IInvestorService _investorService;         

            public InvestorsController(IInvestorService investorService)
            {
                _investorService = investorService;              
            }

            /// <summary>
            /// Get Investor
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<InvestorViewModel>>> GetInvestors([FromQuery] PagingRequest request)
            {               
                var rs =await _investorService.GetInvestors(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get Investor By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpGet("{id}")]
            public async Task<ActionResult<InvestorViewModel>> GetInvestorById(int id)
            {
                var rs = await _investorService.GetInvestorById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new Investor
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPost]
            public async Task<ActionResult<InvestorViewModel>> PostInvestor([FromBody] PostInvestorRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _investorService.PostInvestor(model, userId);
                try
                {                  
                    await _investorService.SaveAsync();
                    return Ok(rs);
                }
                catch(Exception e)
                {                   
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
               
            }
            /// <summary>
            /// Update Investor
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPut("{id}")]
            public async Task<ActionResult<InvestorViewModel>> PutInvestor(int id,[FromBody] PutInvestorRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _investorService.UpdateInvestor(id, model, userId);
                    await _investorService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {                    
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
                
            }
            /// <summary>
            /// Delete Investor
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<InvestorViewModel>> DeleteInvestor(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _investorService.DeleteInvestor(id);
                    await _investorService.SaveAsync();
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
