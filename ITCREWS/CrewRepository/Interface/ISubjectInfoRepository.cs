using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewRepository.Interface
{
    public interface ISubjectInfoRepository
    {
        Task<bool> Create(SubjectInfoModel model);
        Task<bool> Delete(long subjId);
        Task<bool> Edit(SubjectInfoModel model);
        Task<Tuple<long, List<SubjectInfoModel>>> Get(int pageIndex, string type, int row, string searchWord);

        Task<SubjectInfoModel> Get(long subjId);
    }
}
