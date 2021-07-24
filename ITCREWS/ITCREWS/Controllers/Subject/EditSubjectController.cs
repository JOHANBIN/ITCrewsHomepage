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
    public class EditSubjectController : APIController<EditSubject>
    {
        private ISubjectInfoService subjectInfoService;
        public EditSubjectController(ISubjectInfoService subjectInfoService)
        {
            this.subjectInfoService = subjectInfoService;
        }
        public override async Task<ICommonResponse> Process(long userNo, EditSubject body)
        {
            var loadSubject = await this.subjectInfoService.Get(body.SubjId);
            if (loadSubject == null)
            {
                return MakeErrorResponse(400, $"not found subject - {body.SubjId}");
            }

            if(loadSubject.UserNo != userNo)
            {
                return MakeErrorResponse(400, $"not the same author - { userNo }");
            }
            
            var result = await this.subjectInfoService.Edit(new CrewModel.SubjectInfoModel()
            {
                Title = body.Title,
                Desc = body.Desc,
                ChangeDateTime = DateTime.Now,
                UserNo = userNo,
                Id = body.SubjId
            });


            if (result == false)
            {
                return new EditSubjectResponse()
                {
                    Result = "N",
                    ErrorDesc = $"edit subject failed! subject - {body.SubjId}"
                };
            }
            return new EditSubjectResponse()
            {
                Result = "Y",
            };
        }
    }
}
