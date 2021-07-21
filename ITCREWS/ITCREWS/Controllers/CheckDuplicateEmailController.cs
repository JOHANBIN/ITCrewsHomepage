using CrewService.Interface;
using ITCREWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records;

namespace ITCREWS.Controllers
{
    public class CheckDuplicateEmailController : BaseApiController<CheckDuplicateEmail>
    {
        ISignService _signService;
        public CheckDuplicateEmailController(ISignService signService)
        {
            _signService = signService;
        }
        public override async Task<ICommonResponse> Process(CheckDuplicateEmail body)
        {
            string email = body.Email;
            try
            {
                bool reuslt = await _signService.CheckDuplicateEmail(email);
                if (reuslt)
                {
                    return new CheckDuplicateEmailResponse() { IsSuccess = true, Result = "Email_Check_OK" };
                }
                else
                {
                    return new CheckDuplicateEmailResponse() { IsSuccess = false, ErrorDesc = "Email_Check_Fail" };
                }
            }
            catch (Exception e)
            {
                return new CheckDuplicateEmailResponse() { IsSuccess=false, ErrorDesc = e.Message };
            }

        }
    }
    
}
