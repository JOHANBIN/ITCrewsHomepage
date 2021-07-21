using CrewModel;
using CrewRepository;
using CrewRepository.Interface;
using CrewService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService
{
    public class SignService : ISignService
    {
        ISignRepository userInfoRepository;
        public SignService(ISignRepository signRepository)
        {
            this.userInfoRepository = signRepository;
        }
        public async Task<bool> CheckDuplicateEmail(string email)
        {
            return await userInfoRepository.CheckDuplicateEmail(email);
        }
        public async Task<bool> CheckEmailAuth(string email,string authCode)
        {
            return await userInfoRepository.CheckEmailAuth( email,authCode);
        }

        public async Task<bool> Insert(UserInfoModel userInfo)
        {
            return await userInfoRepository.Insert(userInfo);
        }
        public async Task<UserInfoModel> Get(string userId)
        {
            return await userInfoRepository.Get(userId);
        }

        public async Task<string> GetEmailAuth(string email)
        {
            return await userInfoRepository.GetEmailAuth(email);

        }
        public async Task<bool> UpdateEmailAuthFlag(string email, string authCode)
        {
            return await userInfoRepository.UpdateEmailAuthFlag(email, authCode);

        }
    }
}
