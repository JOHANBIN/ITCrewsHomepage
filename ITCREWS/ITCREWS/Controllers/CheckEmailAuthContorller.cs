using CrewCore.Helpers;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Controllers
{
    public class CheckEmailAuthController : BaseApiController<CheckEmailAuth>
    {

        ISignService _signService;
        public CheckEmailAuthController(IHttpContextAccessor context, CookieHelper cookie, ISignService signService) : base(context, cookie)
        {
            
            _signService = signService;
        }

        public override async Task<ICommonResponse> Process(CheckEmailAuth body)
        {
            try
            {
                // Auth조회
                string authcode = await _signService.GetEmailAuth(body.Email);
                if (authcode == null)
                {
                    return new CheckEmailAuthResponse() { ErrorDesc = "authCode is null" };
                }
                //Auth 체크
                if (authcode.Equals(body.AuthCode))
                {
                    //Auth Flag 변경
                    await _signService.UpdateEmailAuthFlag(body.Email, body.AuthCode);
                    return new CheckEmailAuthResponse() { Result = "Auth Check OK" };

                }
                else
                {
                    return new CheckEmailAuthResponse() { ErrorDesc = "The authentication number does not match." };

                }
            }
            catch (Exception e)
            {
                return new CheckEmailAuthResponse() { ErrorDesc = $"Auth Check Error : {e.Message}" };
            }


        }
    }
}
