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
    public class CreateMenuController : APIController<CreateMenu>
    {
        private IMenuService menuService;
        public CreateMenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        public override async Task<ICommonResponse> Process(long userNo, CreateMenu body)
        {
           
            return new CreateMenuResponse()
            {
                Result = "Y"
            };
        }
        
    }
}
