using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers.API
{
    public class ForgotPasswordController : APIController<ForgotPassword>
    {
        public override async Task<ICommonResponse> Process(long userNo, ForgotPassword body)
        {
            return new ForgotPasswordResponse();
        }
    }
}
