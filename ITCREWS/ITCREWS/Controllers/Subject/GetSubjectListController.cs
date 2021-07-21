using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers.API
{
    public class GetSubjectListController : APIController<GetSubjectList>
    {
        private ISubjectInfoService subjectInfoService;
        public GetSubjectListController(ISubjectInfoService subjectInfoService)
        {
            this.subjectInfoService = subjectInfoService;
        }
        public override async Task<ICommonResponse> Process(long userNo, GetSubjectList body)
        {
            var result = await subjectInfoService.GetList(body.PageIndex, 10, body.Type.ToString(), body.Query.Keyword);
            if(result == null)
            {
                return MakeErrorResponse(400, $"Invalid Parameter");
            }

            return new GetSubjectListResponse()
            {
                SubjectList = result.Item2,
                CurrentPageIndex = body.PageIndex,
                TotalCount = result.Item1
            };
        }
    }
}
