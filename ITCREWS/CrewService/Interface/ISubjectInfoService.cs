using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService.Interface
{
    public interface ISubjectInfoService
    {
        Task<Tuple<long, List<SubjectInfoModel>>> GetList(int pageIndex, int rows, string type, string searchWord);

        Task<SubjectInfoModel> Get(long subjectId);

        Task<bool> Create(SubjectInfoModel model);

        Task<bool> Edit(SubjectInfoModel model);

        Task<bool> Delete(long subjectId);
    }
}
