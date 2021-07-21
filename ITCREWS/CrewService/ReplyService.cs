using CrewModel;
using CrewRepository.Interface;
using CrewService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService
{
    public class ReplyService : IReplyService
    {
        private IReplyRepository replyRepository;
        public ReplyService(IReplyRepository replyRepository)
        {
            this.replyRepository = replyRepository;
        }

        public async Task<Tuple<long>> Create(ReplyModel replyModel)
        {
            return await replyRepository.Create(replyModel);
        }

        public async Task<bool> Delete(long replyId)
        {
            return await replyRepository.Delete(replyId);
        }

        public async Task<bool> Edit(ReplyModel replyModel)
        {
            return await replyRepository.Edit(replyModel);
        }

        public async Task<List<ReplyModel>> GetList(long subjectId)
        {
            var list = await replyRepository.GetList(subjectId);
            return list;
        }

        public async Task<ReplyModel> Get(long replyId)
        {
            return await replyRepository.Get(replyId);
        }
    }
}
