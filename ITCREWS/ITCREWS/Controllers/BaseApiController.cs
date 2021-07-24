using CrewCore.Helpers;
using CrewCore.Model;
using CrewCore.Web;
using ITCREWS.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
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
        protected bool G_LOGIN = false;
        protected string G_AccessToken = "";
        private CookieHelper _cookie;
        private readonly IHttpContextAccessor _context;
    
        public BaseApiController(IHttpContextAccessor context, CookieHelper cookie )
        {
            _context = context;
            var appCofig = new AppConfig()
            {
                CookieDomain = "Cookie",
                Domain = "Domain",
                SiteCookieDomain = "SiteCookieDomain",
                _settings = new Dictionary<string, string>() { { "SEEDKEY", "dlwkdruathdWJD!skd923Z@#Q9ak0803" } }
            };
            _cookie = cookie;

        }
        public BaseApiController()
        {

        }
        [HttpPost]
        [EnableCors("it-crews")]
        public async Task<ICommonResponse> Post([FromBody] T body)
        {
            if (CheckAuth() == false)
            {
                return MakeErrorResponse(401, "Invalid unauthorized");
            }
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
            if (CheckAuth() == false)
            {
                return MakeErrorResponse(401, "Invalid unauthorized");
            }
            if (ModelState.IsValid == false)
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
            //쿠키로 부터 토큰 가져오기
            string accessToken = _cookie.Get("AccessToken");

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                TokenResultModel auth = null;
          
                 auth = CreateAuthCookie(accessToken);
                

                //토큰이 유효한 경우
                if (auth != null)
                {
                    G_LOGIN = true;
                    G_AccessToken = accessToken;
                }

            }
            else
            {
                return false;
            }

            return true;
        }
        public TokenResultModel CreateAuthCookie(string accessToken)
        {
            try
            {
                //토큰 유효성 체크
                var token = ValidateToken(accessToken);

                //토큰 만료
                if (token == null)
                {
                    return null;
                }
                //토큰 갱신
                var nowUnixDatetime = HttpUtil.ConvertToUnixTimestamp(DateTime.UtcNow);

                if ((token.payload.exp - nowUnixDatetime) < 300)
                {
                    HttpUtil.RefreshToken(Request.HttpContext, _cookie);
                }

                return token;
            }
            catch (Exception ex)
            {
                //에러 로그
                LogHelper.Error(ex.Message);
            }

            return null;
        }

        public TokenResultModel ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            //인증기간 만료/ 잘못된 토큰 로그아웃(쿠키 삭제)
            TokenResultModel trModel = JsonConvert.DeserializeObject<TokenResultModel>(token);
            //각 토큰 value  복호화 실패시(구현요망)
            if (!trModel.errCode.Equals(0))
            {
                if (trModel.errCode == -1000)
                {
                    //알수없는 토큰
                }
                trModel.payload.exp = 0;

                _cookie.Set("AccessToken", JsonConvert.SerializeObject(trModel));
                return null;
            }
            return trModel;
        }
        public abstract Task<ICommonResponse> Process(T body);
    }
}
