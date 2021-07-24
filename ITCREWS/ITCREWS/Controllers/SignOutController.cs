using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewCore.Helpers;
using CrewCore.Web;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ITCREWS.Controllers.API
{
    public class SignOutController : BaseApiController<SignOut>
    {
        private CookieHelper _cookie;
        private IHttpContextAccessor _context;
        public SignOutController(IHttpContextAccessor context ,CookieHelper cookie) : base(context, cookie)
        {
            _context = context;
            _cookie = cookie;
        }
        public override async Task<ICommonResponse> Process(SignOut body)
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
                _cookie.Expire("AccessToken");
                return new SignOutResponse() { Result="SignOut Success"};

            }
            catch(Exception e)
            {
                LogHelper.Error(e.Message);
                return new SignOutResponse() { ErrorDesc = "SignOut Faill" };

            }

        }
    }
}
