using System;

namespace CrewModel
{
    public class SubjectInfoModel
    {
        public long Seq { get; set; }
        public long Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public long UserNo { get; set; }
        public string UserId { get; set; }
        public DateTime ChangeDateTime { get; set; }

        public SubjectFtModel SubjectFtModel { get; set; } = new SubjectFtModel();
    }
}
