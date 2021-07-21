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
        ISignService signService;
        private CookieHelper _cookie;

        private readonly PasswordHasher hash = new PasswordHasher();
        private IHttpContextAccessor _context;
        public SignInController(IHttpContextAccessor context)
        {
            _context = context;
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
                var result = await signService.Get(body.UserId);

                //pw확인
                var rst = hash.VerifyHashedPassword(result.Password, body.Password);

                if (rst.Equals(Microsoft.AspNet.Identity.PasswordVerificationResult.Success))
                {
                    var userInfo = await signService.Get(body.UserId);
                    // 성공 시 AccessToken 발행
                    var preToken = new TokenResultModel()
                    {
                        payload = { cn = userInfo.UserNo, id = userInfo.ToString(), exp = (int)HttpUtil.ConvertToUnixTimestamp(DateTime.UtcNow) + 1800 }
                    };
                    var changeToken = JsonConvert.SerializeObject(preToken);
                    _cookie.Set( "AccessToken", changeToken);
                    return new SignInResponse() { Result = "SignIn Success" };
                }
                else
                {
                    return new SignInResponse() { ErrorDesc = "Not Match Id OR PW" };
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e.Message);
                return new SignInResponse() { ErrorDesc = "SignIn Faill" };
            }

        }



    }
}
