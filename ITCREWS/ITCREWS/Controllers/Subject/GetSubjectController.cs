using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ITCREWS.Controllers.API
{
    public class GetSubjectController : APIController<GetSubject>
    {
        private ISubjectInfoService subjectInfoService;
        private IReplyService replyService;
        public GetSubjectController(ISubjectInfoService subjectInfoService, IReplyService replyService)
        {
            this.subjectInfoService = subjectInfoService;
            this.replyService = replyService;
        }

        public override async Task<ICommonResponse> Process(long userNo, GetSubject body)
        {
            var response = new GetSubjectResponse();

            var subject = await subjectInfoService.Get(body.SubjId);

            if(subject == null)
            {
                return MakeErrorResponse(406, $"Invalid Parameter");
            }

            response.SubjId = subject.Id;
            response.Title = subject.Title;
            response.Desc = subject.Desc;
            response.ChgDate = subject.ChangeDateTime;
            response.AuthorNo = subject.UserNo;
            response.AuthorId = subject.UserId;
            response.ReplyList = await GetSortingReply(body.SubjId);
            response.AuthorImg = subject.UserImage;
            return response;
        }
        private async Task<List<CrewModel.ReplyModel>> GetSortingReply(long subjectId)
        {
            var replies = await replyService.GetList(subjectId);
            if(replies == null)
            {
                replies = new List<CrewModel.ReplyModel>();
            }
            var newReplies = new List<CrewModel.ReplyModel>();
            foreach (var reply in replies)
            {
                var model = new CrewModel.ReplyModel
                {
                    AuthorId = reply.AuthorId,
                    AuthorNo = reply.AuthorNo,
                    ChangeDate = reply.ChangeDate,
                    Desc = reply.Desc,
                    ParentId = reply.ParentId,
                    ReplyId = reply.ReplyId,
                    AuthorImg = reply.AuthorImg,
                    SubjectId = reply.SubjectId
                };

                if (model.ParentId == 0)
                {
                    newReplies.Add(model);
                    GetChildReply(replies, model);
                }
            }

            return newReplies;
        }
        private void GetChildReply(List<CrewModel.ReplyModel> replies, CrewModel.ReplyModel target)
        {
            foreach (var reply in replies)
            {
                if (target.ReplyId == reply.ReplyId)
                {
                    continue;
                }
                if(target.ReplyId == reply.ParentId)
                {
                    GetChildReply(replies, reply);
                    target.ChildReply.Add(reply);
                }
                
            }
        }
    }
}
