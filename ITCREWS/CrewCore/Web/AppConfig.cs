using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CrewCore.Web
{
    /// <summary>
    /// 설정정보
    /// </summary>
    public class AppConfig
    {
        public string Domain { get; set; }
        public string CookieDomain { get; set; }
        public string SiteCookieDomain { get; set; }


        public string this[string key]
        {
            get { return _settings[key]; }
            set { _settings[key] = value; }
        }

        public Dictionary<string, string> _settings { get; set; } = new Dictionary<string, string>();
    }
}
