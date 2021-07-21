using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService.Interface
{
    public interface ISignService
    {
        Task<bool> CheckDuplicateEmail(string email);
        Task<bool> Insert(UserInfoModel userInfo);
        Task<string> GetEmailAuth(string email);
        Task<bool> CheckEmailAuth(string email,string auth);
        Task<bool> UpdateEmailAuthFlag(string email,string authCode);

        Task<UserInfoModel> Get(string userId);
    }
}
