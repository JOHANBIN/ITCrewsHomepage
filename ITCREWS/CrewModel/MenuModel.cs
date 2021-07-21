using System;
using System.Collections.Generic;
using System.Text;

namespace CrewModel
{
    public class MenuModel
    {
        public int MenuId { get; set; }

        //메뉴명
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Type { get; set; }

        public long ParentId { get; set; }

        public string Url { get; set; }

        public List<MenuModel> ChildMenus { get; set; } = new List<MenuModel>();
    }
}
