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
        public class NewsController : ControllerBase
        {
            private readonly INewsService _newsService;         

            public NewsController(INewsService newsService)
            {
                _newsService = newsService;              
            }

            /// <summary>
            /// Get News
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<NewsViewModel>>> GetAllNews([FromQuery] PagingRequest request)
            {               
                var rs =await _newsService.GetAllNews(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get News By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpGet("{id}")]
            public async Task<ActionResult<NewsViewModel>> GetNewsById(int id)
            {
                var rs = await _newsService.GetNewsById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new News
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPost]
            public async Task<ActionResult<NewsViewModel>> PostNews([FromBody] NewsRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _newsService.PostNews(model, userId);
                try
                {                  
                    await _newsService.SaveAsync();
                    return Ok(rs);
                }
                catch(Exception e)
                {                   
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
               
            }
            /// <summary>
            /// Update News
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPut("{id}")]
            public async Task<ActionResult<NewsViewModel>> PutNews(int id,[FromBody] NewsRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _newsService.UpdateNews(id, model, userId);
                    await _newsService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {                    
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
                
            }
            /// <summary>
            /// Delete News
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<NewsViewModel>> DeleteNews(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _newsService.DeleteNews(id);
                    await _newsService.SaveAsync();
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
