using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewRepository.Interface
{
    public  interface IMenuRepository
    {
        Task<bool> Create(MenuModel menuModel, long userId);
        Task<bool> Delete(long seqNo);
        Task<bool> Update(MenuModel menuModel, long userNo);
        Task<MenuModel> Get(long seqNo);
        Task<List<MenuModel>> GetList(string type);
    }
}
