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
    public class CreateReplyController : APIController<CreateReply>
    {

        private IReplyService replyService;
        private ISubjectInfoService subjectInfoService;
        public CreateReplyController(IReplyService replyService, ISubjectInfoService subjectInfoService)
        {
            this.replyService = replyService;
            this.subjectInfoService = subjectInfoService;
        }
        public override async Task<ICommonResponse> Process(long userNo, CreateReply body)
        {
            var loadSubject = await subjectInfoService.Get(body.SubjectId);

            if(loadSubject == null)
            {
                return MakeErrorResponse(400, $"not found subject - {body.SubjectId}");
            }

            var result = await replyService.Create(new CrewModel.ReplyModel() 
            {
                SubjectId = body.SubjectId,
                AuthorNo = body.UserId,
                Desc = body.Desc,
                ChangeDate = DateTime.Now,
                ParentId = body.ParentId,
            });

            if(result == null)
            {
                return new CreateReplyResponse()
                {
                    Result = "N",
                    ErrorDesc = $"create reply failed! id - {body.SubjectId}"
                };
            }

            return new CreateReplyResponse()
            {
                ReplyId = result.Item1,
                Result = "Y"
            };
        }
    }
}
