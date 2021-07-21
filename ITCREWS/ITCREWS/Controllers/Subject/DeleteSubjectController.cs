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
    public class DeleteSubjectController : APIController<DeleteSubject>
    {
        private ISubjectInfoService subjectInfoService;
        public DeleteSubjectController(ISubjectInfoService subjectInfoService)
        {
            this.subjectInfoService = subjectInfoService;
        }
        public override async Task<ICommonResponse> Process(long userNo, DeleteSubject body)
        {
            if (await subjectInfoService.Get(body.SubjId) == null)
            {
                return MakeErrorResponse(400, $"not found subject - {body.SubjId}");
            }
            var deleted = await subjectInfoService.Delete(body.SubjId);
            if(deleted == false)
            {
                return new DeleteSubjectResponse()
                {
                    Result = "N",
                    ErrorDesc = $"delete failed! subject id - {body.SubjId}"
                };
            }

            return new DeleteSubjectResponse()
            {
                Result = "Y"
            };
        }
    }
}
