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
        public class CampaignsController : ControllerBase
        {
            private readonly ICampaignService _campaignService;
            private readonly ICampaignPackageService _campaignPackageService;

            public CampaignsController(ICampaignService campaignService, ICampaignPackageService campaignPackageService)
            {
                _campaignService = campaignService;
                _campaignPackageService = campaignPackageService;
            }

            /// <summary>
            /// Get Campaign
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<CampaignViewModel>>> GetCampaigns([FromQuery] PagingRequest request)
            {               
                var rs =await _campaignService.GetCampaigns(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get Campaign By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpGet("{id}")]
            public async Task<ActionResult<CampaignViewModel>> GetCampaignById(int id)
            {
                var rs = await _campaignService.GetCampaignById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new Campaign
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpPost]
            public async Task<ActionResult<CampaignViewModel>> PostCampaign([FromBody] PostCampaignRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _campaignService.PostCampaign(model, userId);
                try
                {                  
                    await _campaignService.SaveAsync();
                    return Ok(rs);
                }
                catch(Exception e)
                {                   
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
               
            }
            /// <summary>
            /// Update Campaign
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpPut("{id}")]
            public async Task<ActionResult<CampaignViewModel>> PutCampaign(int id,[FromBody] PutCampaignRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _campaignService.UpdateCampaign(id, model, userId);
                    await _campaignService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {                    
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
                
            }
            /// <summary>
            /// Delete Campaign
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<CampaignViewModel>> DeleteCampaign(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _campaignService.DeleteCampaign(id);
                    await _campaignService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }

            }

            /* --- Campaign package --- */

            /// <summary>
            /// Get CampaignPackage 
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpGet("packages")]
            public async Task<ActionResult<PagedResults<CampaignPackageViewModel>>> GetCampaignPackages([FromQuery] PagingRequest request)
            {
                var rs = await _campaignPackageService.GetCampaignPackages(request);
                return Ok(rs);
            }
            /// <summary>
            /// Get CampaignPackage By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpGet("packages/{id}")]
            public async Task<ActionResult<CampaignPackageViewModel>> GetCampaignPackageById(int id)
            {
                var rs = await _campaignPackageService.GetCampaignPackageById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new CampaignPackage
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpPost("packages")]
            public async Task<ActionResult<CampaignPackageViewModel>> PostCampaignPackage([FromBody] PostCampaignPackageRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _campaignPackageService.PostCampaignPackage(model, userId);
                try
                {
                    await _campaignPackageService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }

            }
            /// <summary>
            /// Update CampaignPackage
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpPut("packages/{id}")]
            public async Task<ActionResult<CampaignPackageViewModel>> PutCampaignPackage(int id, [FromBody] PutCampaignPackageRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _campaignPackageService.UpdateCampaignPackage(id, model, userId);
                    await _campaignPackageService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }

            }
            /// <summary>
            /// Delete CampaignPackage
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Business)]
            [HttpDelete("packages/{id}")]
            public async Task<ActionResult<CampaignPackageViewModel>> DeleteCampaignPackage(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _campaignPackageService.DeleteCampaignPackage(id);
                    await _campaignPackageService.SaveAsync();
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
