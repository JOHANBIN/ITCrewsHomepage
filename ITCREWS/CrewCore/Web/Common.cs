using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrewCore.Web
{
    public static class Common 
    {


        public static bool CheckEmail(string email)
        {
            bool result=false;
            if (!string.IsNullOrEmpty(email))
            {
                result=Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            return result;
        }

       
    }
}