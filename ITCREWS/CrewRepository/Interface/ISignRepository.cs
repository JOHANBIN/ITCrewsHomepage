using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewRepository.Interface
{
    public interface ISignRepository
    {
        Task<bool> Insert(UserInfoModel userInfoModel);
        Task<bool> Edit(UserInfoModel userInfoModel);

        Task<bool> Delete(long userNo);

        Task<UserInfoModel> Get(string userId);
        Task<bool> CheckDuplicateEmail(string email);
        Task<bool> CheckEmailAuth(string email, string AuthCode);
        Task<string> GetEmailAuth(string email);
        Task<bool> UpdateEmailAuthFlag(string email,string AuthCode);
    }
}
