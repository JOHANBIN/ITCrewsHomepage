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
    public class EditReplyController : APIController<EditReply>
    {

        private IReplyService replyService;
        public EditReplyController(IReplyService replyService)
        {
            this.replyService = replyService;
        }
        public override async Task<ICommonResponse> Process(long userNo, EditReply body)
        {
            var load = await replyService.Get(body.Id);
            if (load == null)
            {
                return MakeErrorResponse(400, $"not found reply - {body.Id}");
            }
            if(load.AuthorNo != body.UserId)
            {
                return MakeErrorResponse(400, $"not the same author - { body.UserId}");
            }

            var result = await replyService.Edit(new CrewModel.ReplyModel()
            {
                ReplyId = body.Id,
                AuthorNo = body.UserId,
                Desc = body.Desc,
                ChangeDate = DateTime.Now
            });

            if(result == false)
            {
                return new EditReplyResponse()
                {
                    Result = "N",
                    ErrorDesc = $"edit subject reply failed! id - {body.Id}"
                };
                
            }

            return new EditReplyResponse()
            {
                Result = "Y"
            };
        }
    }
}
