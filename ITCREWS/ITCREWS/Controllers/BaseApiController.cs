using CrewCore.Helpers;
using CrewCore.Web;
using ITCREWS.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Controllers
{
    [Route("[controller]")]
    public abstract class BaseApiController<T> : ControllerBase where T : ICommonRequest
    {
        [HttpPost]
        [EnableCors("it-crews")]
        public async Task<ICommonResponse> Post([FromBody] T body)
        {
            if (ModelState.IsValid == false)
            {
                return MakeErrorResponse(400, "Invalid Request");
            }
            
            var result = await Process(body);

            return result;
        }
        
        [HttpGet]
        [EnableCors("it-crews")]
        public async Task<ICommonResponse> Get([FromQuery] T body)
        {
            if(ModelState.IsValid == false)
            {
                return MakeErrorResponse(400, "Invalid Request");
            }
            var result = await Process(body);

            return result;
        }
        public CommonResponse MakeErrorResponse(int statusCode, string errorMessage)
        {
            //todo
            //사용자 닉네임
            LogHelper.Error($"user Id : {"dummy"} Error Code : {statusCode} Message : {errorMessage}");
            HttpContext.Response.StatusCode = statusCode;
            return new CommonResponse()
            {
                ErrorDesc = errorMessage
            };
        }
        public CommonResponse MakeErrorResponse(string userId, int statusCode, string errorMessage)
        {
            //todo
            //사용자 닉네임
            LogHelper.Error($"user Id : {userId} Error Code : {statusCode} Message : {errorMessage}");
            HttpContext.Response.StatusCode = statusCode;
            return new CommonResponse()
            {
                ErrorDesc = errorMessage
            };
        }
        protected virtual bool CheckAuth() 
        {
            //블랙 리스트등 사용에 가능
            return true;
        }
        public abstract Task<ICommonResponse> Process(T body);
    }
}
