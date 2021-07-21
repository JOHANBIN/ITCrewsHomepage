using System;
using System.Collections.Generic;
using System.Text;

namespace CrewModel
{
    public class UserInfoModel
    {
        public long UserNo { get; set; }

        public string UserId { get; set; }

        public string Type { get; set; }

        public string Password { get; set; }

        public string AutoLogCheck { get; set; }
    
        public long AuthCode { get; set; }

        public string Email { get; set; }

        public long LastCheckUserNo { get; set; }

        public DateTime ChangeDateTime { get; set; }

        public string ActiveFlag { get; set; }
    }
}
