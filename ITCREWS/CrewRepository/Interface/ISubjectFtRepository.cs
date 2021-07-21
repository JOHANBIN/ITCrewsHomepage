using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewRepository.Interface
{
    public interface ISubjectFtRepository
    {
        public Task<SubjectFtModel> Get(long subjectId);
        public Task<bool> UpsertReadCount(long subjectId, int updateCount);

        public Task<bool> UpsertFavCount(long subjectId, int updateCount);
    }
}
