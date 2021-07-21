using CrewCore.Web;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrewCore.Helpers
{
    public class CookieHelper
    {
        private readonly AppConfig _config;
        private readonly CryptoHelper _crypto;
        private readonly IHttpContextAccessor _context;
        public CookieHelper(IHttpContextAccessor context, CryptoHelper crypto, AppConfig config) {
            _context = context;
            _crypto = crypto;
            _config = config;
        }

        /// <summary>
        /// 쿠키 가져오기
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isDecrypt"></param>
        /// <returns></returns>
        public string Get( string name,bool isDecrypt = false)
        {
            string cookie = _context.HttpContext.Request.Cookies[name];

            if(isDecrypt && !string.IsNullOrEmpty(cookie))
            {
                cookie = _crypto.Decrypt(cookie);
            }
            return cookie ?? string.Empty;
        }

        public void Set( string name, string val, bool isEncrypt=false, int minutes=0, string domain="")
        {
            if(isEncrypt && !string.IsNullOrWhiteSpace(val))
            {
                val = _crypto.Encrypt(val);
            }

            _context.HttpContext.Response.Cookies.Append(name, val?.Trim() ?? string.Empty, new CookieOptions() { 
            Domain=string.IsNullOrWhiteSpace(domain) ? _config.CookieDomain : domain,
            Expires = minutes>0 ? (DateTime?)DateTime.Now.AddMinutes(minutes):null
            });
        }

        public void Expire( params string[] keys)
        {
            foreach (var cookie in _context.HttpContext.Request.Cookies.Where(x => keys.Equals(x.Key)))
            {
                _context.HttpContext.Response.Cookies.Delete(cookie.Key, new CookieOptions()
                {
                    Domain = _config.SiteCookieDomain,
                    Expires = DateTime.Now.AddDays(-10)
                });
            }

            
        }
    }
}
