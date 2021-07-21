using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITCREWS.Controllers
{
    public static class CommonController 
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