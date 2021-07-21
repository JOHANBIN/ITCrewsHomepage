using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrewModel;
using CrewRepository.Interface;
using CrewService.Interface;

namespace CrewService
{
    public class SubjectInfoService : ISubjectInfoService
    {
        ISubjectInfoRepository subjectInfoRepository;
        ISubjectFtRepository subjectFtRepository;

        public SubjectInfoService(ISubjectInfoRepository subjectInfoRepository, ISubjectFtRepository subjectFtRepository)
        {
            this.subjectInfoRepository = subjectInfoRepository;
            this.subjectFtRepository = subjectFtRepository;
        }

        public async Task<Tuple<long, List<SubjectInfoModel>>> GetList(int pageIndex, int rows, string type, string searchWord)
        {
            return await subjectInfoRepository.Get(pageIndex, type, rows, searchWord);
        }

        public async Task<SubjectInfoModel> Get(long subjId)
        {
            var subjectInfoModel = await subjectInfoRepository.Get(subjId);
            if(subjectInfoModel == null)
            {
                return null;
            }

            //없을 수도 있다.
            var ftModel = await subjectFtRepository.Get(subjId);

            if (ftModel.SubjectId != -1)
            {
                var upserted = await subjectFtRepository.UpsertReadCount(subjId, ftModel.ReadCount + 1);

                if (upserted == false)
                {
                    return null;
                }
            }

            ftModel.ReadCount += 1;

            subjectInfoModel.SubjectFtModel = ftModel;

            return subjectInfoModel;
        }

        public async Task<bool> Create(SubjectInfoModel model)
        {
            return await subjectInfoRepository.Create(model);
        }

        public async Task<bool> Edit(SubjectInfoModel model)
        {
            return await subjectInfoRepository.Edit(model);
        }

        public async Task<bool> Delete(long subjectId)
        {
            return await subjectInfoRepository.Delete(subjectId);
        }

    }
}
