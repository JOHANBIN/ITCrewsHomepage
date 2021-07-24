using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService.Interface
{
    public interface IReplyService
    {
        public Task<Tuple<long>> Create(ReplyModel replyModel);
        public Task<bool> Edit(ReplyModel replyModel);

        public Task<bool> Delete(long replyId);
        public Task<List<ReplyModel>> GetList(long subjectId);

        public Task<ReplyModel> Get(long replyId);

        public Task<Tuple<int>> GetCount(long subjectId);
    }
}
