using CrewModel;
using CrewRepository.Interface;
using CrewService.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrewService
{
    public class MenuService : IMenuService
    {
        IMenuRepository menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        public async Task<List<MenuModel>> GetMenus(string type)
        {
            return await menuRepository.GetList(type);
        }
    }
}
