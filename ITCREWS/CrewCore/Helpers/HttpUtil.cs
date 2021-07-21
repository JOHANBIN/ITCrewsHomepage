using CrewCore.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrewCore.Helpers
{
    public static class HttpUtil
    {

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        //토큰 초기화
        public static bool RefreshToken(HttpContext context, CookieHelper cookieHelper)
        {
            try
            {
                string strAccessToken = cookieHelper.Get( "AccessToken");
                TokenResultModel trModel = JsonConvert.DeserializeObject<TokenResultModel>(strAccessToken);
                //토큰시간 연장
                trModel.payload.exp = (long)ConvertToUnixTimestamp(DateTime.UtcNow) + 1800;

                strAccessToken = JsonConvert.SerializeObject(trModel);

                cookieHelper.Set("AccessToken", strAccessToken);
                return true;

            }
            catch (Exception e)
            {
               
                return false;

            }
        }
    }
}
