using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITCREWS.Models;
using CrewService.Interface;
using Shared;
using ITCREWS.Extensions;

namespace ITCREWS.Controllers
{
    public class CommunityController : Controller
    {
        private ISubjectInfoService communityService;
        private const int Rows = 10;
        public CommunityController(ISubjectInfoService communityService)
        {
            this.communityService = communityService;
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] GetSubjectList communityPage)
        {
            if (communityPage.PageIndex <= 0)
            {
                communityPage.PageIndex = 1;
            }
            if (string.IsNullOrEmpty(communityPage.Query.Keyword) == true)
            {
                communityPage.Query.Keyword = "";
            }

            var list = await communityService.GetList(communityPage.PageIndex, Rows, communityPage.Type.ToString(), communityPage.Query.Keyword);
            if(list == null)
            {
                LogHelper.Debug("load failed! community page");
            }
            var viewModel = new CommunityViewModel();
            PageModelExtension.SetPageModel(viewModel, communityPage.PageIndex, Rows, list.Item1);
            viewModel.List = list.Item2;
            viewModel.SearchWord = communityPage.Query.Keyword;

            return View(viewModel);
        }

        //Front가 구성되면 API로 대체될 수도 있음
        public async Task<IActionResult> Detail([FromQuery] GetSubject getSubject)
        {
            var data = await communityService.Get(getSubject.SubjId);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
