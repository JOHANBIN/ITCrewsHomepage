using CrewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrewService.Interface
{
    public interface IMenuService
    {
        public Task<List<MenuModel>> GetMenus(string type);
    }
}
