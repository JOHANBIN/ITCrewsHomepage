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
    public class DeleteReplyController : APIController<DeleteReply>
    {
        private IReplyService replyService;
        public DeleteReplyController(IReplyService replyService)
        {
            this.replyService = replyService;
        }
        public override async Task<ICommonResponse> Process(long userNo, DeleteReply body)
        {
            if(await replyService.Get(body.Id) == null)
            {
                return MakeErrorResponse(400, $"not found reply - {body.Id}");
            }
            var deleted =  await replyService.Delete(body.Id);

            if(deleted == false)
            {
                return new DeleteReplyResponse()
                {
                    Result = "N",
                    ErrorDesc = $"delete failed! reply - {body.Id}"
                };
            }

            return new DeleteReplyResponse()
            {
                Result = "Y"
            };
        }
    }
}
