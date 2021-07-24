using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewCore.Helpers;
using CrewCore.Web;
using CrewModel;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers.API
{
    public class SignUpController : BaseApiController<SignUp>
    {
        ISignService _signService;
        private readonly PasswordHasher hash=new PasswordHasher();
        private IHttpContextAccessor _context;

        public SignUpController(IHttpContextAccessor context, CookieHelper cookie, ISignService signService) : base(context, cookie)
        {
            //_context = context;
            _signService = signService;
        }
        public override async Task<ICommonResponse> Process(SignUp body)
        {
            UserInfoModel userInfo = new UserInfoModel();
            try
            {
                string fromAddress = "ItCrewInfo@gamil.com";
                string title = "Hi";
                string url = "http://localhost:51952/CheckEmailAuth?Email=";
                Random num = new Random();

                long AuthCode = num.Next(10000000, 99999999);
                string bodyText =url + body.Email+ "&AuthCOde="+ AuthCode;

                //이메일 체크 성공
                if (Common.CheckEmail(body.Email)&& body.CheckEmail==true)
                {
                    //이메일 전송
                    Mail mail = new Mail(fromAddress, body.Email);
                    await mail.SendEmail(title, bodyText);

                    userInfo.Password = hash.HashPassword(body.Password);
                    userInfo.Email = body.Email;
                    userInfo.AuthCode = AuthCode;

                    //DB에 저장
                    await _signService.Insert(userInfo);
                }
                else
                {
                    //이메일 형식 실패시
                }

                return new SignUpResponse();
            }
            catch(Exception e)
            {
                //예외처리
                return new SignUpResponse();
            }



        }

 
    }
}
