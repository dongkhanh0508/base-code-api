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
        public class DocumentsController : ControllerBase
        {
            private readonly IDocumentService _documentService;         

            public DocumentsController(IDocumentService documentService)
            {
                _documentService = documentService;              
            }

            /// <summary>
            /// Get Document
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]           
            [HttpGet]
            public async Task<ActionResult<PagedResults<DocumentViewModel>>> GetDocuments([FromQuery] PagingRequest request)
            {               
                var rs =await _documentService.GetDocuments(request);                                
                return Ok(rs);
            }
            /// <summary>
            /// Get Document By Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpGet("{id}")]
            public async Task<ActionResult<DocumentViewModel>> GetDocumentById(int id)
            {
                var rs = await _documentService.GetDocumentById(id);
                return Ok(rs);
            }
            /// <summary>
            /// Add new Document
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPost]
            public async Task<ActionResult<DocumentViewModel>> PostDocument([FromBody] PostDocumentRequest model)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var rs = await _documentService.PostDocument(model, userId);
                try
                {                  
                    await _documentService.SaveAsync();
                    return Ok(rs);
                }
                catch(Exception e)
                {                   
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
               
            }
            /// <summary>
            /// Update Document
            /// </summary>
            /// <param name="id"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpPut("{id}")]
            public async Task<ActionResult<DocumentViewModel>> PutDocument(int id,[FromBody] PutDocumentRequest model)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _documentService.UpdateDocument(id, model, userId);
                    await _documentService.SaveAsync();
                    return Ok(rs);
                }
                catch (Exception e)
                {                    
                    throw new CustomException(HttpStatusCode.BadRequest, GeneralMessages.BadRequest, e.InnerException?.Message);
                }
                
            }
            /// <summary>
            /// Delete Document
            /// </summary>
            /// <param name="id"></param>          
            /// <returns></returns>
            [Authorize(Roles = AuthorRole.Admin + "," + AuthorRole.Business + "," + AuthorRole.Investor)]
            [HttpDelete("{id}")]
            public async Task<ActionResult<DocumentViewModel>> DeleteDocument(int id)
            {
                try
                {
                    int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                    var rs = await _documentService.DeleteDocument(id);
                    await _documentService.SaveAsync();
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
