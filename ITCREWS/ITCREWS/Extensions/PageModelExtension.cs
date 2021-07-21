using ITCREWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Extensions
{
    public static class PageModelExtension
    {
        private static readonly int PageListCount = 5;
        public static void SetPageModel(this IPageModel pageModel, int currentPage, int rowCount, long totalSize)
        {
            var totalPages = (int)totalSize / rowCount;
            if (totalSize % rowCount > 0)
                totalPages++;
            var minPage = (currentPage - 1) / PageListCount * PageListCount + 1;
            var maxPage = minPage + PageListCount - 1;

            pageModel.PageListCount = PageListCount;
            pageModel.CurrentPage = currentPage;
            pageModel.TotalPage = totalPages;
            pageModel.MinPage = minPage;
            pageModel.MaxPage = totalPages < maxPage ? totalPages : maxPage;
        }
    }
}
