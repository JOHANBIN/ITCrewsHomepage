using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewService.Interface;
using ITCREWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers.API
{
    public class GetMenuListController : APIController<GetMenuList>
    {
        private IMenuService menuService;
        public GetMenuListController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        public override async Task<ICommonResponse> Process(long userNo, GetMenuList body)
        {
            var menus = await GetSortingMenu(body.Type);
            if(menus == null)
            {
                return MakeErrorResponse(400, $"Invalid Parameter");
            }

            return new GetMenuListResponse()
            {
                MenuList = menus
            };
        }
        private async Task<List<CrewModel.MenuModel>> GetSortingMenu(string type)
        {
            var menus = await menuService.GetMenus(type);

            var newMenus = new List<CrewModel.MenuModel>();
            foreach (var menu in menus)
            {
                var model = new CrewModel.MenuModel
                {
                    MenuId = menu.MenuId,
                    Title = menu.Title,
                    Type = menu.Type,
                };
                
                if (model.ParentId == 0)
                {
                    newMenus.Add(model);
                    GetChildMenus(newMenus, model);
                }
            }

            return newMenus;
        }
        private void GetChildMenus(List<CrewModel.MenuModel> menus, CrewModel.MenuModel target)
        {
            foreach (var menu in menus)
            {
                if (target.MenuId == menu.MenuId)
                {
                    continue;
                }
                if (target.MenuId == menu.ParentId)
                {
                    GetChildMenus(menus, menu);
                    target.ChildMenus.Add(menu);
                }
            }
        }
    }
}
