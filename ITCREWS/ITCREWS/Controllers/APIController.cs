using CrewCore.Helpers;
using CrewCore.Model;
using CrewCore.Web;
using ITCREWS.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Controllers
{
    public abstract class APIController<T> : BaseApiController<T> where T : ICommonRequest
    {
        protected bool G_LOGIN = false;
        protected string G_AccessToken = "";
        private CookieHelper _cookie;
        private IHttpContextAccessor _context;
        public APIController()
        {
            _context = new HttpContextAccessor();
            var appCofig = new AppConfig()
            {
                CookieDomain = "Cookie",
                Domain = "Domain",
                SiteCookieDomain = "SiteCookieDomain",
                _settings = new Dictionary<string, string>() { { "SEEDKEY", "dlwkdruathdWJD!skd923Z@#Q9ak0803" } }
            };
            _cookie = new CookieHelper(_context,new CryptoHelper(appCofig), appCofig);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public override async Task<ICommonResponse> Process(T body)
        {
            if (CheckAuth() == false)
            {
                return MakeErrorResponse(401, "Invalid unauthorized");
            }
            
            var testUser = 0;
            return await Process(testUser, body);
        }

        protected override bool CheckAuth()
        {
            //쿠키로 부터 토큰 가져오기
            string accessToken = _cookie.Get( "AccessToken");

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                TokenResultModel auth = null;
                if (HttpContext.Items["__auth__"] != null)
                {
                    auth = (TokenResultModel)HttpContext.Items["__auth__"];
                }
                else
                {
                    auth = CreateAuthCookie(accessToken);
                }

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
                    HttpUtil.RefreshToken(Request.HttpContext,_cookie);
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
            if (!trModel.errCode.Equals(0))
            {
                if (trModel.errCode == -1000)
                {
                    //알수없는 토큰
                }
                trModel.payload.exp =0;

                _cookie.Set( "AccessToken", JsonConvert.SerializeObject(trModel));
                return null;
            }
            return trModel;
        }
        public abstract Task<ICommonResponse> Process(long userNo, T Body);
    }
}
