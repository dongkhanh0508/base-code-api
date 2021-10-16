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
        public class BusinessController : ControllerBase
        {
            private readonly IBusinessService _businessService;         

            public BusinessController(IBusinessService businessService)
            {
                _businessService = businessService;              
            }

            /// <summary>
            /// Get Business
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<BusinessViewModel>>> GetBusiness([FromQuery] PagingRequest request)
            {               
                var rs =await _businessService.GetBusiness(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get Business By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpGet("{id}")]
            public async Task<ActionResult<BusinessViewModel>> GetBusinessById(int id)
            {
                var rs = await _businessService.GetBusinessById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new Business
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPost]
            public async Task<ActionResult<BusinessViewModel>> PostBusiness([FromBody] PostBusinessRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _businessService.PostBusiness(model, userId);
                try
                {                  
                    await _businessService.SaveAsync();
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
            /// Update Business
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPut("{id}")]
            public async Task<ActionResult<BusinessViewModel>> PutBusiness(int id,[FromBody] PutBusinessRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _businessService.UpdateBusiness(id, model, userId);
                    await _businessService.SaveAsync();
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
            /// Delete Business
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<BusinessViewModel>> DeleteBusiness(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _businessService.DeleteBusiness(id);
                    await _businessService.SaveAsync();
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
