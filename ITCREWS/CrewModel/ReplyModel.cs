using System;
using System.Collections.Generic;
using System.Text;

namespace CrewModel
{
    public class ReplyModel
    {
        public long SubjectId { get; set; }
        public long ReplyId { get; set; }

        public string AuthorId { get; set; }

        public long AuthorNo { get; set; }

        public DateTime ChangeDate { get; set; }

        public string Desc { get; set; }

        public long ParentId { get; set; }

        public List<ReplyModel> ChildReply { get; set; } = new List<ReplyModel>();
    }
}
