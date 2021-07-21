using System;
using System.Collections.Generic;
using System.Text;

namespace CrewModel
{
    public class UserLoginInfoModel
    {
        public long UserNo { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public long LastChangeUser { get; set; }

        public DateTime ChangeDateTime { get; set; }

        public string ActiveFlag { get; set; }
    }
}
