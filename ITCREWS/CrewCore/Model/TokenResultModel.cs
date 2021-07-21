using System;
using System.Collections.Generic;
using System.Text;

namespace CrewCore.Model
{
   public  class TokenResultModel
    {
        public int errCode { get; set; }
        public string errMessage { get; set; }
        public PayLoadModel payload { get; set; }
    }
}
