using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers.API
{
    public class CreateSubjectController : APIController<CreateSubject>
    {
        private ISubjectInfoService communityService;
        public CreateSubjectController(ISubjectInfoService communityService)
        {
            this.communityService = communityService;
        }
        public override async Task<ICommonResponse> Process(long userNo, CreateSubject body)
        {
            var result = await this.communityService.Create(new CrewModel.SubjectInfoModel()
            {
                Title = body.Title,
                Desc = body.Desc,
                Type = body.Type.ToString(),
                ChangeDateTime = DateTime.Now,
                UserNo = userNo
            });

            if(result == false)
            {
                return new CreateSubjectResponse()
                {
                    Result = "N",
                    ErrorDesc = $"make subject failed!"
                };
            }

            return new CreateSubjectResponse()
            {
                Result = "Y"
            };
        }
    }
}
