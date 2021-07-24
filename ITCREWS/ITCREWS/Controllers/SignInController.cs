using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewCore.Helpers;
using CrewCore.Model;
using CrewCore.Web;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;

namespace ITCREWS.Controllers.API
{
    public class SignInController : BaseApiController<SignIn>
    {
        ISignService _signService;
        private CookieHelper _cookie;

        private readonly PasswordHasher hash = new PasswordHasher();
        private IHttpContextAccessor _context;
        public SignInController(IHttpContextAccessor context, CookieHelper cookie, ISignService signService) :base(context, cookie)
        {
            _context = context;
            _cookie = cookie;
            _signService = signService;
        }

        public override async Task<ICommonResponse> Process(SignIn body)
        {
            var appCofig = new AppConfig()
            {
                CookieDomain = "Cookie",
                Domain = "Domain",
                SiteCookieDomain = "SiteCookieDomain",
                _settings = new Dictionary<string, string>() { { "SEEDKEY", "dlwkdruathdWJD!skd923Z@#Q9ak0803" } }
            };
            try
            {
                _cookie = new CookieHelper(_context,new CryptoHelper(appCofig), appCofig);
                //아이디 확인
                var userInfo = await _signService.Get(body.UserId);

                if (userInfo == null)
                {
                    //아이디 없음
                    return MakeErrorResponse(400, $"not found UserId - {body.UserId}");
                }

                //pw확인
                var rst = hash.VerifyHashedPassword(userInfo.Password, body.Password);

                if (rst.Equals(Microsoft.AspNet.Identity.PasswordVerificationResult.Success))
                {
                    // 성공 시 AccessToken 발행
                    var preToken = new TokenResultModel()
                    {
                        payload = { cn = userInfo.UserNo, id = userInfo.UserId.ToString(), exp = (int)HttpUtil.ConvertToUnixTimestamp(DateTime.UtcNow) + 1800 }
                    };
                    var changeToken = JsonConvert.SerializeObject(preToken);
                    _cookie.Set( "AccessToken", changeToken);
                    return new SignInResponse() { Result = "Y" };
                }
                else
                {
                    return new SignInResponse() {Result="N" ,ErrorDesc = "Not Match Id OR PW" };
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e.Message);
                return MakeErrorResponse(400, $"{e.Message} - {body.UserId}");
            }

        }



    }
}
