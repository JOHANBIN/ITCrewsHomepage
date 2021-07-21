using System;
using System.Collections.Generic;
using System.Text;
using static Shared.SystemEnums;

namespace CrewModel
{
    public class SubjectQueryModel
    {
        public List<string> Categories { get; set; } = new List<string>();

        public string Key { get; set; }

        public string Keyword { get; set; }

        public SortingType Sorting { get; set; }
    }
}
