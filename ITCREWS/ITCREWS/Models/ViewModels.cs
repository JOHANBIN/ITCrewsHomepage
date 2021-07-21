using CrewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Models
{
    public interface IPageModel
    {
        int CurrentPage { get; set; }
        int MaxPage { get; set; }
        int MinPage { get; set; }
        int PageListCount { get; set; }
        int TotalPage { get; set; }
    }

    public class CommunityViewModel : IPageModel
    {
        public List<SubjectInfoModel> List { get; set; }

        public int MaxPage { get; set; }

        public int MinPage { get; set; }

        public int CurrentPage { get; set; }

        public int PageListCount { get; set; }

        public int TotalPage { get; set; }

        public string SearchWord { get; set; }
    }
}
